using Xunit;
using Microsoft.AspNetCore.Mvc;
using SampleJenkinsDeploy.Controllers;

namespace SampleJenkinsDeploy.Tests;

public class WeatherForecastControllerTests
{
    [Fact]
    public void Get_ReturnsFiveForecasts()
    {
        // Arrange
        var controller = new WeatherForecastController(null);

        // Act
        var result = controller.Get();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Count());
    }

    [Fact]
    public void GetVersion_ReturnsValidResponse()
    {
        // Arrange
        var controller = new WeatherForecastController(null);

        // Act
        var result = controller.GetVersion() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }
}