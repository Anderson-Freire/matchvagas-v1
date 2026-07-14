using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.Location.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("locations")]
    public sealed class LocationController(ILocationService locationService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await locationService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await locationService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(
            [FromBody] CreateLocationInputDto createLocationDto,
            CancellationToken cancellationToken)
        {
            var result = await locationService.CreateAsync(createLocationDto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteLocation(Guid id, CancellationToken cancellationToken)
        {
            await locationService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}