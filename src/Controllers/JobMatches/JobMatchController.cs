using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.JobMatches.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("users/{userId:guid}/job-matches")]
    public sealed class JobMatchController(IJobMatchService jobMatchService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var result = await jobMatchService.GetAllByUserIdAsync(userId, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await jobMatchService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobMatch(Guid userId,
            [FromBody] CreateJobMatchInputDto createJobMatchDto,
                CancellationToken cancellationToken)
        {
            var result = await jobMatchService.CreateAsync(userId, createJobMatchDto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { userId, id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateJobMatch(Guid id,
            [FromBody] UpdateJobMatchInputDto updateJobMatchDto,
            CancellationToken cancellationToken)
        {
            var result = await jobMatchService.UpdateAsync(id, updateJobMatchDto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteJobMatch(Guid id, CancellationToken cancellationToken)
        {
            await jobMatchService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}