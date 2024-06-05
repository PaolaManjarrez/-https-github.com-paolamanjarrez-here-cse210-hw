using System;
using System.Collections.Generic;

abstract class Activity
{
    private string date;
    private int duration;

    public Activity(string date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public string Date => date;
    public int Duration => duration;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();
        return $"{Date} {this.GetType().Name} ({Duration} min): Distance: {distance:F2} km, Speed: {speed:F2} kph, Pace: {pace:F2} min per km";
    }
}

class Running : Activity
{
    private double distance;

    public Running(string date, int duration, double distance)
        : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / Duration) * 60;
    }

    public override double GetPace()
    {
        return Duration / distance;
    }
}

class Cycling : Activity
{
    private double speed;

    public Cycling(string date, int duration, double speed)
        : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * Duration) / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }
}

class Swimming : Activity
{
    private int laps;
    private const double LAP_LENGTH_METERS = 50;

    public Swimming(string date, int duration, int laps)
        : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * LAP_LENGTH_METERS / 1000;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        return (distance / Duration) * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return Duration / distance;
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 4.8),
            new Cycling("03 Nov 2022", 30, 20),
            new Swimming("03 Nov 2022", 30, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
