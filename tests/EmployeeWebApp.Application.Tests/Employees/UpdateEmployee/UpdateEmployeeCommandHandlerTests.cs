using EmployeeWebApp.Application.Employees.UpdateEmployee;
using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;

namespace EmployeeWebApp.Application.Tests.Employees.UpdateEmployee;

public class UpdateEmployeeCommandHandlerTests
{
    /// <summary>
    /// Тест, проверяющий, что при валидной команде обновляется сотрудник.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task UpdateEmployeeCommandHandler_ValidCommand_Success(
        [Frozen] Mock<IEmployeeRepository> employeeRepositoryMock,
        UpdateEmployeeCommand command,
        UpdateEmployeeCommandHandler handler)
    {
        // Arrange
        employeeRepositoryMock.Setup(x => x.EmployeeExistsAsync(command.Id)).ReturnsAsync(true);
        
        // Act
        await handler.Handle(command);
        
        // Assert
        employeeRepositoryMock.Verify(x => x.UpdateEmployeeAsync(command.Id, It.IsAny<Employee>()), Times.Once);
    }
    
    /// <summary>
    /// Тест, проверяющий, что при ошибке в id сотрудника выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task UpdateEmployeeCommandHandler_EmployeeNotFound_ExceptionThrown(
        [Frozen] Mock<IEmployeeRepository> employeeRepositoryMock,
        UpdateEmployeeCommand command,
        UpdateEmployeeCommandHandler handler)
    {
        // Arrange
        employeeRepositoryMock.Setup(x => x.EmployeeExistsAsync(command.Id)).ReturnsAsync(false);
        
        // Act
        var act = () => handler.Handle(command);
        
        // Assert
        await Assert.ThrowsAsync<EmployeeNotFoundException>(act);
    }
}