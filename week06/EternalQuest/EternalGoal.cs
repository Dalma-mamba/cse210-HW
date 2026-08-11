namespace week06.EternalQuest;

class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string title, string description, int points)
        : base(title, description, points)
    {
        _timesRecorded = 0;
    }

    public override bool IsComplete => false;

    public override int RecordEvent()
    {
        _timesRecorded++;
        return _points;
    }

    public override string GetStatus()
    {
        return $"[ ] (Recorded {_timesRecorded} times)";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{Escape(_title)}|{Escape(_description)}|{_points}|{_timesRecorded}";
    }

    public static EternalGoal FromData(string[] parts)
    {
        string title = Unescape(parts[1]);
        string description = Unescape(parts[2]);
        int points = int.Parse(parts[3]);
        int timesRecorded = int.Parse(parts[4]);
        var goal = new EternalGoal(title, description, points)
        {
            _timesRecorded = timesRecorded
        };
        return goal;
    }
}
