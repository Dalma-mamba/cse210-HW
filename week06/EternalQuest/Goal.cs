namespace week06.EternalQuest;

public abstract class Goal
{
    protected string _title;
    protected string _description;
    protected int _points;

    protected Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    public string Title => _title;
    public string Description => _description;

    public abstract bool IsComplete { get; }
    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string GetStringRepresentation();

    protected static string Escape(string text)
    {
        return text.Replace("%", "%25").Replace("|", "%7C").Replace("\n", "%0A").Replace("\r", "%0D");
    }

    protected static string Unescape(string text)
    {
        return text.Replace("%0D", "\r").Replace("%0A", "\n").Replace("%7C", "|").Replace("%25", "%");
    }
}
