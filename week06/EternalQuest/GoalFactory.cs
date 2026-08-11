namespace week06.EternalQuest;

static class GoalFactory
{
    public static Goal CreateGoalFromLine(string dataLine)
    {
        string[] parts = dataLine.Split('|');
        if (parts.Length == 0)
        {
            throw new InvalidOperationException("Invalid goal line.");
        }

        return parts[0] switch
        {
            "SimpleGoal" => SimpleGoal.FromData(parts),
            "EternalGoal" => EternalGoal.FromData(parts),
            "ChecklistGoal" => ChecklistGoal.FromData(parts),
            _ => throw new InvalidOperationException($"Unknown goal type: {parts[0]}"),
        };
    }
}
