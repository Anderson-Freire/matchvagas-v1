using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Dtos.Companies.Input;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("companies")]
    public sealed class CompanyController(ICompanyService companyService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies(CancellationToken cancellationToken)
        {
            var result = await companyService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCompanyById(Guid id, CancellationToken cancellationToken)
        {
            var result = await companyService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyInputDto createCompanyDto,
            CancellationToken cancellationToken)
        {
            var result = await companyService.CreateAsync(createCompanyDto, cancellationToken);
            return CreatedAtAction(nameof(GetCompanyById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] UpdateCompanyInputDto updateCompanyDto,
            CancellationToken cancellationToken)
        {
            var result = await companyService.UpdateAsync(id, updateCompanyDto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id, CancellationToken cancellationToken)
        {
            await companyService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}