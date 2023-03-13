using System.Globalization;

namespace CQUELLETestApp;

public class DateService
{
    private readonly string _dateFormat;
    private readonly IOSystemProvider _ioProvider;

    public DateService(string dateFormat, IOSystemProvider ioProvider)
    {
        _dateFormat = dateFormat;
        _ioProvider = ioProvider;
    }

    public DateTime InputAndGetDateTimeInFormat()
    {
        _ioProvider.WriteLine($"Enter Time in next format({_dateFormat}): ");
        var date = _ioProvider.ReadLine();
        if (string.IsNullOrWhiteSpace(date))
        {
            throw new ArgumentException(
                $"argument {nameof(date)} is empty in {nameof(InputAndGetDateTimeInFormat)} ");
        }

        return DateTime.ParseExact(date, $"{_dateFormat}", CultureInfo.InvariantCulture);
    }
}