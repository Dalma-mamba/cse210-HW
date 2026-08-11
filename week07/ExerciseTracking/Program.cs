using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new RunningActivity("03 Nov 2022", 30, 3.0),
            new CyclingActivity("04 Nov 2022", 45, 15.0),
            new SwimmingActivity("05 Nov 2022", 60, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

abstract class Activity
{
    private string _date;
    private int _lengthInMinutes;

    protected Activity(string date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public string Date => _date;
    public int LengthInMinutes => _lengthInMinutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    protected abstract string ActivityType { get; }

    public string GetSummary()
    {
        return $"{Date} {ActivityType} ({LengthInMinutes} min) - Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

class RunningActivity : Activity
{
    private double _distanceMiles;

    public RunningActivity(string date, int lengthInMinutes, double distanceMiles)
        : base(date, lengthInMinutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        return GetDistance() / LengthInMinutes * 60.0;
    }

    public override double GetPace()
    {
        return LengthInMinutes / GetDistance();
    }

    protected override string ActivityType => "Running";
}

class CyclingActivity : Activity
{
    private double _speedMph;

    public CyclingActivity(string date, int lengthInMinutes, double speedMph)
        : base(date, lengthInMinutes)
    {
        _speedMph = speedMph;
    }

    public override double GetDistance()
    {
        return _speedMph * LengthInMinutes / 60.0;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        return 60.0 / _speedMph;
    }

    protected override string ActivityType => "Cycling";
}

class SwimmingActivity : Activity
{
    private int _laps;
    private const double MetersPerLap = 50.0;
    private const double MilesPerMeter = 0.62 / 1000.0;

    public SwimmingActivity(string date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * MetersPerLap * MilesPerMeter;
    }

    public override double GetSpeed()
    {
        return GetDistance() / LengthInMinutes * 60.0;
    }

    public override double GetPace()
    {
        return LengthInMinutes / GetDistance();
    }

    protected override string ActivityType => "Swimming";
}