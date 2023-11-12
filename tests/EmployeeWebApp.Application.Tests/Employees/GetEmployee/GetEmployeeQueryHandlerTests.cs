using EmployeeWebApp.Application.Employees.GetEmployee;
using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;

namespace EmployeeWebApp.Application.Tests.Employees.GetEmployee;

public class GetEmployeeQueryHandlerTests
{
    /// <summary>
    /// Тест, проверяющий, что при валидной команде возвращается сотрудник.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task GetEmployeeQueryHandler_ValidCommand_Success(
        [Frozen] Mock<IEmployeeRepository> employeeRepositoryMock,
        Employee employeeMock,
        GetEmployeeQuery query,
        GetEmployeeQueryHandler handler)
    {
        // Arrange
        employeeRepositoryMock.Setup(x => x.GetEmployeeAsync(query.Id)).ReturnsAsync(employeeMock);
        
        // Act
        var employee = await handler.Handle(query);
        
        // Assert
        Assert.Equal(employeeMock.Id, employee.Id);
        Assert.Equal(employeeMock.Name, employee.Name);
        Assert.Equal(employeeMock.Surname, employee.Surname);
        Assert.Equal(employeeMock.Phone, employee.Phone);
    }

    /// <summary>
    /// Тест, проверяющий, что при ошибке в id сотрудника выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task GetEmployeeQueryHandler_EmployeeNotFound_ExceptionThrown(
        [Frozen] Mock<IEmployeeRepository> employeeRepositoryMock,
        GetEmployeeQuery query,
        GetEmployeeQueryHandler handler)
    {
        // Arrange
        employeeRepositoryMock.Setup(x => x.GetEmployeeAsync(It.IsAny<int>())).ReturnsAsync(() => null);
        
        // Act
        var act = () => handler.Handle(query);
        
        // Assert
        await Assert.ThrowsAsync<EmployeeNotFoundException>(act);
    }
}