
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool finished = false;

        Console.WriteLine("Welcome to Eternal Quest!");
        Console.WriteLine("Track your goals, earn points, and celebrate progress on your personal quest.");

        while (!finished)
        {
            Console.WriteLine();
            Console.WriteLine($"Current Score: {manager.Score}");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Exit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    RecordEvent(manager);
                    break;
                case "3":
                    manager.DisplayGoals();
                    break;
                case "4":
                    SaveGoals(manager);
                    break;
                case "5":
                    LoadGoals(manager);
                    break;
                case "6":
                    finished = true;
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    break;
            }
        }

        Console.WriteLine("Thanks for playing Eternal Quest. Keep going on your quest!");
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("The following goal types are available:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select a goal type: ");
        string type = Console.ReadLine();

        Console.Write("Enter the goal title: ");
        string title = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();

        int points = PromptForInt("Enter the points earned for this goal: ");

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(title, description, points));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(title, description, points));
                break;
            case "3":
                int targetCount = PromptForInt("Enter how many times this goal must be completed: ");
                int bonus = PromptForInt("Enter the bonus points awarded when this goal is complete: ");
                manager.AddGoal(new ChecklistGoal(title, description, points, targetCount, bonus));
                break;
            default:
                Console.WriteLine("Unknown goal type selected.");
                return;
        }

        Console.WriteLine("Goal created successfully!");
    }

    static void RecordEvent(GoalManager manager)
    {
        if (manager.Goals.Count == 0)
        {
            Console.WriteLine("No goals available to record. Create one first.");
            return;
        }

        manager.DisplayGoals();
        int goalNumber = PromptForInt("Enter the number of the goal to record: ");

        if (goalNumber < 1 || goalNumber > manager.Goals.Count)
        {
            Console.WriteLine("That goal number is not valid.");
            return;
        }

        Goal goal = manager.Goals[goalNumber - 1];
        int beforeScore = manager.Score;
        bool success = manager.RecordGoalEvent(goalNumber - 1);
        if (!success)
        {
            Console.WriteLine("Unable to record the goal event.");
            return;
        }

        int earned = manager.Score - beforeScore;
        if (earned > 0)
        {
            Console.WriteLine($"Event recorded! You earned {earned} points.");
            if (goal.IsComplete)
            {
                Console.WriteLine("Congratulations! You completed the goal and earned a completion bonus.");
            }
        }
        else
        {
            Console.WriteLine("This goal was already complete, so no points were earned.");
        }
    }

    static void SaveGoals(GoalManager manager)
    {
        Console.Write("Enter the filename to save goals: ");
        string filename = Console.ReadLine();

        try
        {
            manager.Save(filename);
            Console.WriteLine($"Goals saved to {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to save goals: {ex.Message}");
        }
    }

    static void LoadGoals(GoalManager manager)
    {
        Console.Write("Enter the filename to load goals from: ");
        string filename = Console.ReadLine();

        try
        {
            manager.Load(filename);
            Console.WriteLine($"Goals loaded from {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to load goals: {ex.Message}");
        }
    }

    static int PromptForInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string response = Console.ReadLine();
            if (int.TryParse(response, out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a valid integer.");
        }
    }
}
