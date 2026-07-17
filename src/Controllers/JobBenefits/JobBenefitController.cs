using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.JobBenefits.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("jobs/{jobId:guid}/benefits")]
    public sealed class JobBenefitController(IJobBenefitService jobBenefitService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllByJobId(Guid jobId, CancellationToken cancellationToken)
        {
            var result = await jobBenefitService.GetAllByJobIdAsync(jobId, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobBenefit(Guid jobId,
            [FromBody] CreateJobBenefitInputDto createJobBenefitDto,
            CancellationToken cancellationToken)
        {
            var result = await jobBenefitService.CreateAsync(jobId, createJobBenefitDto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{benefitId:guid}")]
        public async Task<IActionResult> DeleteJobBenefit(Guid jobId, Guid benefitId,
            CancellationToken cancellationToken)
        {
            await jobBenefitService.DeleteAsync(jobId, benefitId, cancellationToken);
            return NoContent();
        }
    }
}