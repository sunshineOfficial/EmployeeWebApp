using EmployeeWebApp.Application.Companies.AddCompany;
using EmployeeWebApp.Application.Companies.DeleteCompany;
using EmployeeWebApp.Application.Companies.GetCompany;
using EmployeeWebApp.Application.Companies.UpdateCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApp.Api.Controllers;

/// <summary>
/// Контроллер компаний.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Добавляет компанию.
    /// </summary>
    /// <param name="command"><see cref="AddCompanyCommand"/>.</param>
    /// <returns>Id компании.</returns>
    [HttpPost]
    public async Task<IActionResult> AddCompanyAsync(AddCompanyCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(id);
    }

    /// <summary>
    /// Получает компанию.
    /// </summary>
    /// <param name="id">Id компании.</param>
    /// <returns>Компания с указанным id.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyAsync(int id)
    {
        var query = new GetCompanyQuery { Id = id };

        var company = await _mediator.Send(query);

        return Ok(company);
    }

    /// <summary>
    /// Изменяет компанию по id.
    /// </summary>
    /// <param name="id">Id компании.</param>
    /// <param name="command"><see cref="UpdateCompanyCommand"/>.</param>
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateCompanyAsync(int id, UpdateCompanyCommand command)
    {
        command.Id = id;

        await _mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// Удаляет компанию по id.
    /// </summary>
    /// <param name="id">Id компании.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompanyAsync(int id)
    {
        var command = new DeleteCompanyCommand { Id = id };

        await _mediator.Send(command);

        return Ok();
    }
}