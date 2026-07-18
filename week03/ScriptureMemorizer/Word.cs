using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden
    {
        get { return _isHidden; }
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        char[] hiddenCharacters = new char[_text.Length];

        for (int i = 0; i < _text.Length; i++)
        {
            if (char.IsLetter(_text[i]))
            {
                hiddenCharacters[i] = '_';
            }
            else
            {
                hiddenCharacters[i] = _text[i];
            }
        }

        return new string(hiddenCharacters);
    }
}
