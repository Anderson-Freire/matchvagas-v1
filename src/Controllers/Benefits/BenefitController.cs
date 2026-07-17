using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.Benefits.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("benefits")]
    public sealed class BenefitController(IBenefitService benefitService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBenefits(CancellationToken cancellationToken)
        {
            var result = await benefitService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBenefit([FromBody] CreateBenefitInputDto createBenefitDto,
            CancellationToken cancellationToken)
        {
            var result = await benefitService.CreateAsync(createBenefitDto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBenefit(Guid id, CancellationToken cancellationToken)
        {
            await benefitService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}