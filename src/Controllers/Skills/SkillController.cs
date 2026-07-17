using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.Skills.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("skills")]
    public sealed class SkillController(ISkillService skillService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSkills(CancellationToken cancellationToken)
        {
            var result = await skillService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill([FromBody] CreateSkillInputDto createSkillDto,
            CancellationToken cancellationToken)
        {
            var result = await skillService.CreateAsync(createSkillDto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSkill(Guid id, CancellationToken cancellationToken)
        {
            await skillService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}