using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();

            switch (choice.Trim())
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Filename to save: ");
                    string saveFile = Console.ReadLine() ?? string.Empty;
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Filename to load: ");
                    string loadFile = Console.ReadLine() ?? string.Empty;
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Please choose a valid option.\n");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}