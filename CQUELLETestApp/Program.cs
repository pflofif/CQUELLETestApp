using CQUELLETestApp;

var provider = new DateService("dd.MM.yyyy HH:mm", new ConsoleProvider());
var date = provider.InputAndGetDateTimeInFormat();

var calculator = new RoadCalculate();
var timeOfArrival = calculator.CalculateTime(date);

Console.WriteLine(
    $"The estimated delivery date and time is: {timeOfArrival:dd.MM.yyyy HH:mm}");

Console.ReadKey();