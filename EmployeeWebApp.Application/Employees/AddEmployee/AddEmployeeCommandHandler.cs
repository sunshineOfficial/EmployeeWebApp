using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace EmployeeWebApp.Application.Employees.AddEmployee;

/// <summary>
/// Обработчик команды <see cref="AddEmployeeCommand"/>.
/// </summary>
public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, int>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IPassportRepository _passportRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IValidator<AddEmployeeCommand> _validator;

    public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IPassportRepository passportRepository, IDepartmentRepository departmentRepository, IValidator<AddEmployeeCommand> validator)
    {
        _employeeRepository = employeeRepository;
        _companyRepository = companyRepository;
        _passportRepository = passportRepository;
        _departmentRepository = departmentRepository;
        _validator = validator;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="AddEmployeeCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="AddEmployeeCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Id cотрудника.</returns>
    public async Task<int> Handle(AddEmployeeCommand request, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new FluentValidationException(validationResult.ToString());
        }
        
        var companyExists = _companyRepository.CompanyExistsAsync(request.CompanyId);
        var passportExists = _passportRepository.PassportExistsAsync(request.PassportId);
        var departmentExists = _departmentRepository.DepartmentExistsAsync(request.DepartmentId);

        Task.WaitAll(companyExists, passportExists, departmentExists);

        if (!(companyExists.Result && passportExists.Result && departmentExists.Result))
        {
            throw new EmployeeCannotBeCreatedException(request.CompanyId, request.PassportId, request.DepartmentId);
        }
        
        var employee = new Employee
        {
            Name = request.Name,
            Surname = request.Surname,
            Phone = request.Phone,
            CompanyId = request.CompanyId,
            PassportId = request.PassportId,
            DepartmentId = request.DepartmentId
        };

        return await _employeeRepository.AddEmployeeAsync(employee);
    }
}