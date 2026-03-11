using System;
using System.IO;

public class Journal
{
    private const string _delimiter = "~|~";
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToDelimitedString(_delimiter));
            }
        }
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File not found: {file}");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        _entries.Clear();

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            Entry entry = Entry.FromDelimitedString(line, _delimiter);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
    }
}
