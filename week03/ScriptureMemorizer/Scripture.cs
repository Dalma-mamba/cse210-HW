using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(wordText => new Word(wordText))
            .ToList();
        _random = new Random();
    }

    public bool IsCompletelyHidden
    {
        get { return _words.All(word => word.IsHidden); }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<int> visibleWordIndices = _words
            .Select((word, index) => new { word, index })
            .Where(wordInfo => !wordInfo.word.IsHidden)
            .Select(wordInfo => wordInfo.index)
            .ToList();

        int wordsToHide = Math.Min(numberToHide, visibleWordIndices.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = _random.Next(visibleWordIndices.Count);
            int wordIndex = visibleWordIndices[randomIndex];
            _words[wordIndex].Hide();
            visibleWordIndices.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference}\n{scriptureText}";
    }
}
