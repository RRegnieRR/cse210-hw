using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }

    public string ToDelimitedString(string delimiter)
    {
        return $"{_date}{delimiter}{_promptText}{delimiter}{_entryText}";
    }

    public static Entry FromDelimitedString(string line, string delimiter)
    {
        string[] parts = line.Split(new string[] { delimiter }, 3, StringSplitOptions.None);
        if (parts.Length < 3)
        {
            return null;
        }

        Entry entry = new Entry();
        entry._date = parts[0];
        entry._promptText = parts[1];
        entry._entryText = parts[2];
        return entry;
    }
}
