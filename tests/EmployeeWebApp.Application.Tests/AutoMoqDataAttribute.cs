using AutoFixture;
using AutoFixture.AutoMoq;

namespace EmployeeWebApp.Application.Tests;

public class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute() : base(() => new Fixture().Customize(new AutoMoqCustomization()))
    {
    }
}