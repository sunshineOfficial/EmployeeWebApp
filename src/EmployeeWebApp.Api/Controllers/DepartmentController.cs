using EmployeeWebApp.Application.Departments.AddDepartment;
using EmployeeWebApp.Application.Departments.DeleteDepartment;
using EmployeeWebApp.Application.Departments.GetDepartment;
using EmployeeWebApp.Application.Departments.UpdateDepartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApp.Api.Controllers;

/// <summary>
/// Контроллер отделов.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Добавляет отдел.
    /// </summary>
    /// <param name="command"><see cref="AddDepartmentCommand"/>.</param>
    /// <returns>Id отдела.</returns>
    [HttpPost]
    public async Task<IActionResult> AddDepartmentAsync(AddDepartmentCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(id);
    }

    /// <summary>
    /// Получает отдел.
    /// </summary>
    /// <param name="id">Id отдела.</param>
    /// <returns>Отдел с указанным id.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartmentAsync(int id)
    {
        var query = new GetDepartmentQuery { Id = id };

        var department = await _mediator.Send(query);

        return Ok(department);
    }

    /// <summary>
    /// Изменяет отдел по id.
    /// </summary>
    /// <param name="id">Id отдела.</param>
    /// <param name="command"><see cref="UpdateDepartmentCommand"/>.</param>
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateDepartmentAsync(int id, UpdateDepartmentCommand command)
    {
        command.Id = id;

        await _mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// Удаляет отдел по id.
    /// </summary>
    /// <param name="id">Id отдела.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartmentAsync(int id)
    {
        var command = new DeleteDepartmentCommand { Id = id };

        await _mediator.Send(command);

        return Ok();
    }
}