using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.FavoriteJobs.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("users/{userId:guid}/favorite-jobs")]
    public sealed class FavoriteJobController(IFavoriteJobService favoriteJobService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var result = await favoriteJobService.GetAllByUserIdAsync(userId, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFavoriteJob(Guid userId,
            [FromBody] CreateFavoriteJobInputDto createFavoriteJobDto,
            CancellationToken cancellationToken)
        {
            var result = await favoriteJobService.CreateAsync(userId, createFavoriteJobDto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{jobId:guid}")]
        public async Task<IActionResult> DeleteFavoriteJob(Guid userId, Guid jobId,
            CancellationToken cancellationToken)
        {
            await favoriteJobService.DeleteAsync(userId, jobId, cancellationToken);
            return NoContent();
        }
    }
}