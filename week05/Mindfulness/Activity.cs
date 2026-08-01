
public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        DisplayStartingMessage();
        _duration = GetDuration();
        PrepareToBegin();
        PerformActivity();
        DisplayEndingMessage();
    }

    private void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine("Mindfulness Activity");
        Console.WriteLine("-------------------");
        Console.WriteLine($"Activity: {_name}");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like to do this activity? ");
    }

    private int GetDuration()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }

            Console.Write("Please enter a positive whole number: ");
        }
    }

    protected void PrepareToBegin()
    {
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        PauseWithCountdown(3, "Starting in");
        Console.WriteLine();
    }

    protected void PauseWithCountdown(int seconds, string message)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write($"\r{message} {i}...");
            Thread.Sleep(1000);
        }

        Console.Write("\r");
    }

    protected void PauseWithSpinner(int seconds, string message)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] spinnerFrames = { "|", "/", "-", "\\" };
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write($"\r{message} {spinnerFrames[index]}");
            Thread.Sleep(250);
            index = (index + 1) % spinnerFrames.Length;
        }

        Console.Write("\r");
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Console.WriteLine();
        PauseWithCountdown(3, "Finishing in");
        Console.WriteLine($"You completed the {_name} activity for {_duration} seconds.");
        Console.WriteLine();
        Thread.Sleep(1000);
    }

    protected abstract void PerformActivity();
}