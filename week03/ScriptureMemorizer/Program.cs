using System;

class Program
{
    static void Main(string[] args)
    {
        Reference ref1 = new Reference("John", 3, 16);
        Reference ref2 = new Reference("John", 3, 16, 18);
        Scripture scripture = new Scripture(ref1, "For God so loved the world");
        Scripture scripture2 = new Scripture(ref2, "For He so loved the world");

        Console.WriteLine(scripture.GetDisplayText());
    }
}

//Code by Luis Regnier 🧑‍💻