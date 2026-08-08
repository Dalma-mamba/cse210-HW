
class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(string title, string description, int points, int targetCount, int bonus)
        : base(title, description, points)
    {
        _timesCompleted = 0;
        _targetCount = targetCount;
        _bonus = bonus;
    }

    public override bool IsComplete => _timesCompleted >= _targetCount;

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        _timesCompleted++;
        int reward = _points;
        if (IsComplete)
        {
            reward += _bonus;
        }

        return reward;
    }

    public override string GetStatus()
    {
        string mark = IsComplete ? "[X]" : "[ ]";
        return $"{mark} Completed {_timesCompleted}/{_targetCount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{Escape(_title)}|{Escape(_description)}|{_points}|{_timesCompleted}|{_targetCount}|{_bonus}";
    }

    public static ChecklistGoal FromData(string[] parts)
    {
        string title = Unescape(parts[1]);
        string description = Unescape(parts[2]);
        int points = int.Parse(parts[3]);
        int timesCompleted = int.Parse(parts[4]);
        int targetCount = int.Parse(parts[5]);
        int bonus = int.Parse(parts[6]);
        var goal = new ChecklistGoal(title, description, points, targetCount, bonus);
        for (int i = 0; i < timesCompleted; i++)
        {
            goal.RecordEvent();
        }

        return goal;
    }
}
