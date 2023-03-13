using System.Globalization;
using CQUELLETestApp;
using FluentAssertions;

namespace CQUELLET.Tests;

public class RoadCalculateTests
{
    [Theory]
    [InlineData("10.03.2023 08:00", "10.03.2023 13:00")]
    [InlineData("10.03.2023 10:10", "10.03.2023 15:10")]
    [InlineData("13.03.2023 16:10", "14.03.2023 13:00")]
    [InlineData("13.03.2023 14:35", "14.03.2023 10:35")]
    public void CalculateTime_ShouldReturnCorrectResult_WhenGetWorkDay(string orderDate, string expectedDate)
    {
        //Arrange
        var roadCalculate = new RoadCalculate();
        //Act
        var result =
            roadCalculate.CalculateTime(
                DateTime.ParseExact(orderDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture));
        var resultString = result.ToString("dd.MM.yyyy HH:mm");
        //Assert
        resultString.Should().Be(expectedDate);
    }

    [Theory]
    [InlineData("11.03.2023 13:10", "13.03.2023 13:00")]
    [InlineData("12.03.2023 16:10", "13.03.2023 13:00")]
    [InlineData("18.03.2023 16:10", "20.03.2023 13:00")]
    [InlineData("19.03.2023 16:10", "20.03.2023 13:00")]
    public void CalculateTime_ShouldReturnCorrectResult_WhenGetWeekend(string orderDate, string expectedDate)
    {
        //Arrange
        var roadCalculate = new RoadCalculate();
        //Act
        var result =
            roadCalculate.CalculateTime(
                DateTime.ParseExact(orderDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture));
        var resultString = result.ToString("dd.MM.yyyy HH:mm");
        //Assert
        resultString.Should().Be(expectedDate);
    }
}