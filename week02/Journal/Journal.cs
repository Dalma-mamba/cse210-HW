using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();
    private readonly string[] _prompts = new string[]
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What challenged me most today, and how did I respond?",
        "What am I most grateful for today?",
        "If I had one thing I could do over today, what would it be?",
        "How did I see the hand of the Lord in my life today?"
    };
    private readonly Random _random = new Random();

    public void AddEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine() ?? string.Empty;
        Console.Write("How are you feeling about this entry (e.g. happy, tired, hopeful)? ");
        string mood = Console.ReadLine() ?? "";
        string date = DateTime.Now.ToShortDateString();

        Entry entry = new Entry(date, prompt, response, mood);
        _entries.Add(entry);

        Console.WriteLine("Entry saved.\n");
    }

    public void DisplayJournal()
    {
        Console.WriteLine();

        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty. Add a new entry first.\n");
            return;
        }

        Console.WriteLine("Journal entries:");
        Console.WriteLine("----------------");

        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.ToFileLine());
                }
            }
            Console.WriteLine($"Journal saved to '{filename}'.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the journal: {ex.Message}\n");
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.\n");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            _entries.Clear();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                Entry entry = Entry.FromFileLine(line);
                _entries.Add(entry);
            }

            Console.WriteLine($"Journal loaded from '{filename}'.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the journal: {ex.Message}\n");
        }
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Length);
        return _prompts[index];
    }
}
