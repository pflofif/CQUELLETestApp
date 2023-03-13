using CQUELLETestApp;
using FluentAssertions;
using NSubstitute;

namespace CQUELLET.Tests;

public class DateServiceTests
{
    private readonly IOSystemProvider _provider = Substitute.For<IOSystemProvider>();

    public static IEnumerable<object[]> DataTestCases()
    {
        yield return new object[]
        {
            "13.02.2023 14:11", new DateTime(2023, 2, 13, 14, 11, 0)
        };
        yield return new object[]
        {
            "01.01.2020 13:00", new DateTime(2020, 1, 1, 13, 0, 0)
        };
        yield return new object[]
        {
            "31.10.2021 13:11", new DateTime(2021, 10, 31, 13, 11, 0)
        };
    }

    [Theory]
    [MemberData(nameof(DataTestCases))]
    public void InputAndGetDateTimeInFormat_ShouldReturnCorrectDateTime_WhenInputStringInCorrectFormat
        (string dateInStr, DateTime expect)
    {
        //Arrange
        _provider.ReadLine().Returns(dateInStr);
        var dateService = new DateService("dd.MM.yyyy HH:mm", _provider);
        //Act
        var result = dateService.InputAndGetDateTimeInFormat();

        //Assert
        result.Should().BeSameDateAs(expect);
    }

    [Fact]
    public void InputAndGetDateTimeInFormat_ShouldThrowException_WhenInputStringIsEmpty()
    {
        //Arrange
        _provider.ReadLine().Returns(string.Empty);
        var dateService = new DateService("dd.MM.yyyy HH:mm", _provider);

        try
        {
            //Act
            _ = dateService.InputAndGetDateTimeInFormat();
        }
        catch (Exception e)
        {
            //Assert
            e.Should().BeOfType<ArgumentException>();
        }
    }

    [Fact]
    public void InputAndGetDateTimeInFormat_ShouldThrowException_WhenInputStringIsIncorrectFormat()
    {
        //Arrange
        _provider.ReadLine().Returns("13:11:2023 14.12");
        var dateService = new DateService("dd.MM.yyyy HH:mm", _provider);

        try
        {
            //Act
            _ = dateService.InputAndGetDateTimeInFormat();
        }
        catch (Exception e)
        {
            //Assert
            e.Should().BeOfType<FormatException>();
        }
    }
}