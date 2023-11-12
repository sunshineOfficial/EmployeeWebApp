using EmployeeWebApp.Application.Passports.AddPassport;
using EmployeeWebApp.Application.Passports.DeletePassport;
using EmployeeWebApp.Application.Passports.GetPassport;
using EmployeeWebApp.Application.Passports.UpdatePassport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApp.Api.Controllers;

/// <summary>
/// Контроллер паспортов.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PassportController : ControllerBase
{
    private readonly IMediator _mediator;

    public PassportController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Добавляет паспорт.
    /// </summary>
    /// <param name="command"><see cref="AddPassportCommand"/>.</param>
    /// <returns>Id паспорта.</returns>
    [HttpPost]
    public async Task<IActionResult> AddPassportAsync(AddPassportCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(id);
    }

    /// <summary>
    /// Получает паспорт.
    /// </summary>
    /// <param name="id">Id паспорта.</param>
    /// <returns>Паспорт с указанным id.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPassportAsync(int id)
    {
        var query = new GetPassportQuery { Id = id };

        var passport = await _mediator.Send(query);

        return Ok(passport);
    }

    /// <summary>
    /// Изменяет паспорт по id.
    /// </summary>
    /// <param name="id">Id паспорта.</param>
    /// <param name="command"><see cref="UpdatePassportCommand"/>.</param>
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePassportAsync(int id, UpdatePassportCommand command)
    {
        command.Id = id;

        await _mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// Удаляет паспорт по id.
    /// </summary>
    /// <param name="id">Id паспорта.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePassportAsync(int id)
    {
        var command = new DeletePassportCommand { Id = id };

        await _mediator.Send(command);

        return Ok();
    }
}