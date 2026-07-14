using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.JobSkills.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("jobs/{jobId:guid}/skills")]
    public sealed class JobSkillController(IJobSkillService jobSkillService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllByJobId(Guid jobId, CancellationToken cancellationToken)
        {
            var result = await jobSkillService.GetAllByJobIdAsync(jobId, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobSkill(Guid jobId,
            [FromBody] CreateJobSkillInputDto createJobSkillDto,
            CancellationToken cancellationToken)
        {
            var result = await jobSkillService.CreateAsync(jobId, createJobSkillDto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{skillId:guid}")]
        public async Task<IActionResult> DeleteJobSkill(Guid jobId, Guid skillId,
            CancellationToken cancellationToken)
        {
            await jobSkillService.DeleteAsync(jobId, skillId, cancellationToken);
            return NoContent();
        }
    }
}