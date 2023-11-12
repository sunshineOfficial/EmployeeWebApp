using EmployeeWebApp.Application.Employees.DeleteEmployee;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;

namespace EmployeeWebApp.Application.Tests.Employees.DeleteEmployee;

public class DeleteEmployeeCommandHandlerTests
{
    /// <summary>
    /// Тест, проверяющий, что при валидной команде удаляется сотрудник.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task DeleteEmployeeCommandHandler_ValidCommand_Success(
        [Frozen] Mock<IEmployeeRepository> employeeRepositoryMock,
        DeleteEmployeeCommand command,
        DeleteEmployeeCommandHandler handler)
    {
        // Arrange
        employeeRepositoryMock.Setup(x => x.EmployeeExistsAsync(command.Id)).ReturnsAsync(true);
        
        // Act
        await handler.Handle(command);
        
        // Assert
        employeeRepositoryMock.Verify(x => x.DeleteEmployeeAsync(command.Id), Times.Once);
    }

    /// <summary>
    /// Тест, проверяющий, что при ошибке в id сотрудника выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task DeleteEmployeeCommandHandler_EmployeeNotFound_ExceptionThrown(
        [Frozen] Mock<IEmployeeRepository> employeeRepositoryMock,
        DeleteEmployeeCommand command,
        DeleteEmployeeCommandHandler handler)
    {
        // Arrange
        employeeRepositoryMock.Setup(x => x.EmployeeExistsAsync(command.Id)).ReturnsAsync(false);
        
        // Act
        var act = () => handler.Handle(command);
        
        // Assert
        await Assert.ThrowsAsync<EmployeeNotFoundException>(act);
    }
}