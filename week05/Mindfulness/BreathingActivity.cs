using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int cycleCount = 0;

        while (DateTime.Now < endTime)
        {
            int remainingSeconds = (int)Math.Max(1, (endTime - DateTime.Now).TotalSeconds);
            int step = Math.Min(3, remainingSeconds);

            Console.WriteLine();
            Console.WriteLine("Breathe in...");
            PauseWithCountdown(step, "Inhale");

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Breathe out...");
            PauseWithCountdown(Math.Min(3, (int)Math.Max(1, (endTime - DateTime.Now).TotalSeconds)), "Exhale");
            cycleCount++;
        }

        Console.WriteLine();
        Console.WriteLine($"You completed {cycleCount + 1} breathing cycles.");
    }
}
