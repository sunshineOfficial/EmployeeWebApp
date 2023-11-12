using EmployeeWebApp.Application.Employees.AddEmployee;
using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;

namespace EmployeeWebApp.Application.Tests.Employees.AddEmployee;

public class AddEmployeeCommandHandlerTests
{
    /// <summary>
    /// Тест, проверяющий, что при валидной команде добавляется новый сотрудник.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task AddEmployeeCommandHandler_ValidCommand_Success(
        [Frozen] Mock<IEmployeeRepository> employeeRepositoryMock,
        [Frozen] Mock<ICompanyRepository> companyRepositoryMock,
        [Frozen] Mock<IPassportRepository> passportRepositoryMock,
        [Frozen] Mock<IDepartmentRepository> departmentRepositoryMock,
        int idMock,
        AddEmployeeCommand command,
        AddEmployeeCommandHandler handler)
    {
        // Arrange
        employeeRepositoryMock.Setup(x => x.AddEmployeeAsync(It.IsAny<Employee>())).ReturnsAsync(idMock);
        companyRepositoryMock.Setup(x => x.CompanyExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
        passportRepositoryMock.Setup(x => x.PassportExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
        departmentRepositoryMock.Setup(x => x.DepartmentExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
        
        // Act
        var id = await handler.Handle(command);
        
        // Assert
        Assert.Equal(idMock, id);
        employeeRepositoryMock.Verify(x => x.AddEmployeeAsync(It.IsAny<Employee>()), Times.Once);
    }

    /// <summary>
    /// Тест, проверяющий, что при ошибке в id компании выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task AddEmployeeCommandHandler_InvalidCompanyId_ExceptionThrown(
        [Frozen] Mock<ICompanyRepository> companyRepositoryMock,
        [Frozen] Mock<IPassportRepository> passportRepositoryMock,
        [Frozen] Mock<IDepartmentRepository> departmentRepositoryMock,
        AddEmployeeCommand command,
        AddEmployeeCommandHandler handler)
    {
        // Arrange
        companyRepositoryMock.Setup(x => x.CompanyExistsAsync(It.IsAny<int>())).ReturnsAsync(false);
        passportRepositoryMock.Setup(x => x.PassportExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
        departmentRepositoryMock.Setup(x => x.DepartmentExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
        
        // Act
        var act = () => handler.Handle(command);
        
        // Assert
        await Assert.ThrowsAsync<EmployeeCannotBeCreatedException>(act);
    }
    
    /// <summary>
    /// Тест, проверяющий, что при ошибке в id паспорта выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task AddEmployeeCommandHandler_InvalidPassportId_ExceptionThrown(
        [Frozen] Mock<ICompanyRepository> companyRepositoryMock,
        [Frozen] Mock<IPassportRepository> passportRepositoryMock,
        [Frozen] Mock<IDepartmentRepository> departmentRepositoryMock,
        AddEmployeeCommand command,
        AddEmployeeCommandHandler handler)
    {
        // Arrange
        companyRepositoryMock.Setup(x => x.CompanyExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
        passportRepositoryMock.Setup(x => x.PassportExistsAsync(It.IsAny<int>())).ReturnsAsync(false);
        departmentRepositoryMock.Setup(x => x.DepartmentExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
        
        // Act
        var act = () => handler.Handle(command);
        
        // Assert
        await Assert.ThrowsAsync<EmployeeCannotBeCreatedException>(act);
    }
    
    /// <summary>
    /// Тест, проверяющий, что при ошибке в id отдела выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task AddEmployeeCommandHandler_InvalidDepartmentId_ExceptionThrown(
        [Frozen] Mock<ICompanyRepository> companyRepositoryMock,
        [Frozen] Mock<IPassportRepository> passportRepositoryMock,
        [Frozen] Mock<IDepartmentRepository> departmentRepositoryMock,
        AddEmployeeCommand command,
        AddEmployeeCommandHandler handler)
    {
        // Arrange
        companyRepositoryMock.Setup(x => x.CompanyExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
        passportRepositoryMock.Setup(x => x.PassportExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
        departmentRepositoryMock.Setup(x => x.DepartmentExistsAsync(It.IsAny<int>())).ReturnsAsync(false);
        
        // Act
        var act = () => handler.Handle(command);
        
        // Assert
        await Assert.ThrowsAsync<EmployeeCannotBeCreatedException>(act);
    }
}