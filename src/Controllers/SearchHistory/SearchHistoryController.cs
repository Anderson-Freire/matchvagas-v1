using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.SearchHistories.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("users/{userId:guid}/search-history")]
    public sealed class SearchHistoryController(ISearchHistoryService searchHistoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var result = await searchHistoryService.GetAllByUserIdAsync(userId, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSearchHistory(Guid userId,
            [FromBody] CreateSearchHistoryInputDto createSearchHistoryDto,
            CancellationToken cancellationToken)
        {
            var result = await searchHistoryService.CreateAsync(userId, createSearchHistoryDto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSearchHistory(Guid id, CancellationToken cancellationToken)
        {
            await searchHistoryService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}