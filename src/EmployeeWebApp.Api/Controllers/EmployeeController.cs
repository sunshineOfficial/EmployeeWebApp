using EmployeeWebApp.Application.Employees.AddEmployee;
using EmployeeWebApp.Application.Employees.DeleteEmployee;
using EmployeeWebApp.Application.Employees.GetEmployee;
using EmployeeWebApp.Application.Employees.GetEmployeesByCompanyId;
using EmployeeWebApp.Application.Employees.GetEmployeesByDepartmentId;
using EmployeeWebApp.Application.Employees.UpdateEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApp.Api.Controllers;

/// <summary>
/// Контроллер сотрудников.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Добавляет сотрудника.
    /// </summary>
    /// <param name="command"><see cref="AddEmployeeCommand"/>.</param>
    /// <returns>Id паспорта.</returns>
    [HttpPost]
    public async Task<IActionResult> AddEmployeeAsync(AddEmployeeCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(id);
    }

    /// <summary>
    /// Получает сотрудника.
    /// </summary>
    /// <param name="id">Id сотрудника.</param>
    /// <returns>Cотрудник с указанным id.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeAsync(int id)
    {
        var query = new GetEmployeeQuery { Id = id };

        var employee = await _mediator.Send(query);

        return Ok(employee);
    }

    /// <summary>
    /// Изменяет сотрудника по id.
    /// </summary>
    /// <param name="id">Id сотрудника.</param>
    /// <param name="command"><see cref="UpdateEmployeeCommand"/>.</param>
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateEmployeeAsync(int id, UpdateEmployeeCommand command)
    {
        command.Id = id;

        await _mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// Удаляет сотрудника по id.
    /// </summary>
    /// <param name="id">Id сотрудника.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployeeAsync(int id)
    {
        var command = new DeleteEmployeeCommand { Id = id };

        await _mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// Получает всех сотрудников для указанной компании или отдела.
    /// </summary>
    /// <param name="companyId">Id компании.</param>
    /// <param name="departmentId">Id отдела.</param>
    /// <returns>Перечисление, содержащее всех сотрудников для указанной компании или отдела.</returns>
    [HttpGet]
    public async Task<IActionResult> GetEmployeesByCompanyIdOrDepartmentIdAsync(int companyId = 0, int departmentId = 0)
    {
        IRequest<IEnumerable<GetEmployeeResponse>> query = companyId != 0
            ? new GetEmployeesByCompanyIdQuery { CompanyId = companyId }
            : new GetEmployeesByDepartmentIdQuery { DepartmentId = departmentId };

        var employees = await _mediator.Send(query);

        return Ok(employees);
    }
}