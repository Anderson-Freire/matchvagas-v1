using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.UserSkills.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("users/{userId:guid}/skills")]
    public sealed class UserSkillController(IUserSkillService userSkillService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var result = await userSkillService.GetAllByUserIdAsync(userId, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserSkill(Guid userId,
            [FromBody] CreateUserSkillInputDto createUserSkillDto,
            CancellationToken cancellationToken)
        {
            var result = await userSkillService.CreateAsync(userId, createUserSkillDto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{skillId:guid}")]
        public async Task<IActionResult> DeleteUserSkill(Guid userId, Guid skillId,
            CancellationToken cancellationToken)
        {
            await userSkillService.DeleteAsync(userId, skillId, cancellationToken);
            return NoContent();
        }
    }
}