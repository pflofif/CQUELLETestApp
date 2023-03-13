namespace CQUELLETestApp;

public class RoadCalculate
{
    private static readonly Range TimeOfWorkDay = 8..17;
    private readonly TimeSpan _endOfWorkDay = TimeSpan.FromHours(TimeOfWorkDay.End.Value);
    private readonly TimeSpan _startOfWorkDay = TimeSpan.FromHours(TimeOfWorkDay.Start.Value);

    private DateTime CalculateTransitOutTime(DateTime orderDate)
    {
        const int timeInTranzit = 1;
        return orderDate.AddHours(timeInTranzit).TimeOfDay >= _endOfWorkDay
            ? new DateTime(orderDate.Year, orderDate.Month, orderDate.Day + 1, TimeOfWorkDay.Start.Value,
                orderDate.Minute, 0)
            : orderDate.AddHours(timeInTranzit);
    }

    private DateTime AddDaysToWeekday(DateTime orderDate)
        => orderDate.DayOfWeek switch
        {
            DayOfWeek.Saturday => new DateTime(orderDate.Year, orderDate.Month, orderDate.Day + 2
                , TimeOfWorkDay.Start.Value, 0, 0),
            DayOfWeek.Sunday => new DateTime(orderDate.Year, orderDate.Month, orderDate.Day + 1
                , TimeOfWorkDay.Start.Value, 0, 0),
            _ => orderDate
        };

    private DateTime CalculateArrivalTimeWithWeekends(DateTime orderDate) =>
        CalculateArrivalTimeWithoutWeekends(AddDaysToWeekday(orderDate));

    private DateTime CalculateArrivalTimeWithoutWeekends(DateTime orderTime)
    {
        const int timeInRoad = 2;
        var timeAfterRoad = orderTime.AddHours(timeInRoad);

        if (timeAfterRoad.TimeOfDay >= _endOfWorkDay || orderTime.TimeOfDay >= _endOfWorkDay)
        {
            return
                new DateTime(orderTime.Year, orderTime.Month, orderTime.Day + 1,
                    TimeOfWorkDay.Start.Value + timeInRoad,
                    0, 0);
        }

        return orderTime.TimeOfDay < _startOfWorkDay
            ? new DateTime(orderTime.Year, orderTime.Month, orderTime.Day,
                TimeOfWorkDay.Start.Value + timeInRoad, 0, 0)
            : timeAfterRoad;
    }

    public DateTime CalculateTime(DateTime date)
    {
        var transitPointArrivalTime = CalculateArrivalTimeWithWeekends(date);
        var transitOutTime = CalculateTransitOutTime(transitPointArrivalTime);
        return CalculateArrivalTimeWithoutWeekends(transitOutTime);
    }
}