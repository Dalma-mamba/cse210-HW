using System;
using System.Collections.Generic;

// Exceeds the core requirements by presenting a small library of scriptures and
// choosing one at random, so the practice experience feels more varied.
class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Psalm", 23, 1, 4), "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters. He restoreth my soul: he leadeth me in the paths of righteousness for his name's sake.")
        };

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Press Enter to hide a few words, or type 'quit' to end the program.");

        while (true)
        {
            string input = Console.ReadLine();

            if (input != null && input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                break;
            }

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide a few more words, or type 'quit' to end the program.");
        }
    }
}