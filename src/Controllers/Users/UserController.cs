using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.Users.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("users")]
    public sealed class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var result = await userService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            var result = await userService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserInputDto createUserDto,
            CancellationToken cancellationToken)
        {
            var result = await userService.CreateAsync(createUserDto, cancellationToken);
            return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserInputDto updateUserDto,
            CancellationToken cancellationToken)
        {
            var result = await userService.UpdateAsync(id, updateUserDto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            await userService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}