// Exceeding requirement: I made the prompts and questions not repeat until all of them have been used once during the program session.
class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        ListingActivity listingActivity = new ListingActivity();
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;
        int totalSecondsCompleted = 0;
        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View session stats");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                breathingActivity.Run();
                breathingCount++;
                totalSecondsCompleted += breathingActivity.Duration;
                PauseBeforeMenu();
            }
            else if (choice == "2")
            {
                reflectionActivity.Run();
                reflectionCount++;
                totalSecondsCompleted += reflectionActivity.Duration;
                PauseBeforeMenu();
            }
            else if (choice == "3")
            {
                listingActivity.Run();
                listingCount++;
                totalSecondsCompleted += listingActivity.Duration;
                PauseBeforeMenu();
            }
            else if (choice == "4")
            {
                ShowStats(breathingCount, reflectionCount, listingCount, totalSecondsCompleted);
            }
            else if (choice != "5")
            {
                Console.WriteLine();
                Console.WriteLine("Please choose a valid menu option.");
                PauseBeforeMenu();
            }
        }
    }

    private static void ShowStats(int breathingCount, int reflectionCount, int listingCount, int totalSecondsCompleted)
    {
        Console.Clear();
        Console.WriteLine("Session Stats");
        Console.WriteLine();
        Console.WriteLine($"Breathing sessions: {breathingCount}");
        Console.WriteLine($"Reflection sessions: {reflectionCount}");
        Console.WriteLine($"Listing sessions: {listingCount}");
        Console.WriteLine($"Total mindful seconds completed: {totalSecondsCompleted}");
        PauseBeforeMenu();
    }

    private static void PauseBeforeMenu()
    {
        Console.WriteLine();
        Console.Write("Press enter to return to the menu.");
        Console.ReadLine();
    }
}
