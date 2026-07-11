using System;

class Entry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }
    public string Mood { get; }

    public Entry(string date, string prompt, string response, string mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nMood: {Mood}\nResponse: {Response}";
    }

    public string ToFileLine()
    {
        return $"{Date}~|~{Prompt}~|~{Response}~|~{Mood}";
    }

    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split("~|~");
        if (parts.Length != 4)
        {
            throw new FormatException("Journal file line is not in the expected format.");
        }

        string date = parts[0];
        string prompt = parts[1];
        string response = parts[2];
        string mood = parts[3];

        return new Entry(date, prompt, response, mood);
    }
}
