
class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string title, string description, int points)
        : base(title, description, points)
    {
        _completed = false;
    }

    public override bool IsComplete => _completed;

    public override int RecordEvent()
    {
        if (_completed)
        {
            return 0;
        }

        _completed = true;
        return _points;
    }

    public override string GetStatus()
    {
        return _completed ? "[X]" : "[ ]";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{Escape(_title)}|{Escape(_description)}|{_points}|{_completed}";
    }

    public static SimpleGoal FromData(string[] parts)
    {
        string title = Unescape(parts[1]);
        string description = Unescape(parts[2]);
        int points = int.Parse(parts[3]);
        bool completed = bool.Parse(parts[4]);
        var goal = new SimpleGoal(title, description, points);
        if (completed)
        {
            goal.RecordEvent();
        }

        return goal;
    }
}
