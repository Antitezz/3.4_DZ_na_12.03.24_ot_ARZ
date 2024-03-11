using System;
class WeekDays : IPrinter
{
    public void Print()
    {
        DayOfWeek dayOfWeek = DateTime.Today.DayOfWeek;
        Console.WriteLine($"Сегодня: {dayOfWeek}");
    }
}

