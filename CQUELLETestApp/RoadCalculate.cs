using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace CQUELLETestApp;

public class RoadCalculate
{
    private static readonly Range TimeOfWorkDay = 8..17;
    private readonly TimeSpan _endOfWorkDay = TimeSpan.FromHours(TimeOfWorkDay.End.Value);
    private readonly TimeSpan _startOfWorkDay = TimeSpan.FromHours(TimeOfWorkDay.Start.Value);
    
}