using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.Applications.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("users/{userId:guid}/applications")]
    public sealed class ApplicationController(IApplicationService applicationService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var result = await applicationService.GetAllByUserIdAsync(userId, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await applicationService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(Guid userId,
            [FromBody] CreateApplicationInputDto createApplicationDto,
            CancellationToken cancellationToken)
        {
            var result = await applicationService.CreateAsync(userId, createApplicationDto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { userId, id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateApplication(Guid id,
            [FromBody] UpdateApplicationInputDto updateApplicationDto,
            CancellationToken cancellationToken)
        {
            var result = await applicationService.UpdateAsync(id, updateApplicationDto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteApplication(Guid id, CancellationToken cancellationToken)
        {
            await applicationService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}