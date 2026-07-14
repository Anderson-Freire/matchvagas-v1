using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.Jobs.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("jobs")]
    public sealed class JobController(IJobService jobService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllJobs(CancellationToken cancellationToken)
        {
            var result = await jobService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetJobById(Guid id, CancellationToken cancellationToken)
        {
            var result = await jobService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobInputDto createJobDto,
            CancellationToken cancellationToken)
        {
            var result = await jobService.CreateAsync(createJobDto, cancellationToken);
            return CreatedAtAction(nameof(GetJobById), new { id = result.Id }, result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteJob(Guid id, CancellationToken cancellationToken)
        {
            await jobService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}