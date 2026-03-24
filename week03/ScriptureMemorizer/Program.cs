// I added a system to choose the difficulty of the scripture. The user can choose between three levels: easy, medium, and hard.
class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = ChooseScriptureDifficulty();

        Console.WriteLine(scripture.GetDisplayText());

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
            Console.WriteLine(scripture.GetDisplayText());
        }
    }

    static Scripture ChooseScriptureDifficulty()
    {
        while (true)
        {
            Console.WriteLine("Choose scripture difficulty:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");

            string difficulty = Console.ReadLine();

            if (difficulty == "1")
            {
                return new Scripture(new Reference("John", 11, 35),"Jesus wept.");
            }

            if (difficulty == "2")
            {
                return new Scripture(
                    new Reference("Philippians", 4, 13),
                    "I can do all things through Christ which strengtheneth me.");
            }

            if (difficulty == "3")
            {
                return new Scripture(
                    new Reference("Proverbs", 3, 5, 6),
                    "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
            }
        }
    }
}

//Code by Luis Regnier 🧑‍💻
