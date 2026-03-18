using System;

class Program
{
    static void Main(string[] args)
    {
        Reference ref1 = new Reference("John", 3, 16, 16);
        Scripture scripture = new Scripture(ref1, "For God so loved the world");

        Console.WriteLine(scripture.GetDisplayText());
        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            scripture.HideRandomWords(3);
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}

//Code by Luis Regnier 🧑‍💻