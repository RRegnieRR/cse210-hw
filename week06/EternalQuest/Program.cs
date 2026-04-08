// Creativity: I added a level system that gives the player a title
// based on total points, and it also tells the player how many
// points are needed to reach the next level.
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest");
            Console.WriteLine($"Score: {manager.GetScore()} points");
            Console.WriteLine($"Level: {manager.GetLevelDescription()}");
            Console.WriteLine(manager.GetPointsToNextLevel());
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                CreateGoal(manager);
            }
            else if (choice == "2")
            {
                ListGoals(manager);
            }
            else if (choice == "3")
            {
                SaveGoals(manager);
            }
            else if (choice == "4")
            {
                LoadGoals(manager);
            }
            else if (choice == "5")
            {
                RecordEvent(manager);
            }
            else if (choice == "6")
            {
                break;
            }
            else
            {
                PauseWithMessage("Invalid choice.");
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        int points = ReadInt("What is the amount of points associated with this goal? ");

        Goal goal = null;

        if (choice == "1")
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (choice == "2")
        {
            goal = new EternalGoal(name, description, points);
        }
        else if (choice == "3")
        {
            int targetCount = ReadInt("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = ReadInt("What is the bonus for accomplishing it that many times? ");
            goal = new ChecklistGoal(name, description, points, targetCount, bonus);
        }

        if (goal == null)
        {
            PauseWithMessage("Invalid goal type.");
            return;
        }

        manager.AddGoal(goal);
        PauseWithMessage("Goal created.");
    }

    static void ListGoals(GoalManager manager)
    {
        Console.WriteLine("Your goals are:");
        Console.WriteLine();
        manager.DisplayGoals();
        Pause();
    }

    static void SaveGoals(GoalManager manager)
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            manager.Save(filename);
            PauseWithMessage("Goals saved.");
        }
        catch (Exception ex)
        {
            PauseWithMessage($"Unable to save file: {ex.Message}");
        }
    }

    static void LoadGoals(GoalManager manager)
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            manager.Load(filename);
            PauseWithMessage("Goals loaded.");
        }
        catch (Exception ex)
        {
            PauseWithMessage($"Unable to load file: {ex.Message}");
        }
    }

    static void RecordEvent(GoalManager manager)
    {
        if (manager.GetGoalCount() == 0)
        {
            PauseWithMessage("There are no goals to record yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        Console.WriteLine();
        manager.DisplayGoals();
        Console.WriteLine();

        int goalNumber = ReadInt("Which goal did you accomplish? ");
        Goal goal = manager.GetGoalByNumber(goalNumber);

        if (goal == null)
        {
            PauseWithMessage("Invalid goal number.");
            return;
        }

        int pointsEarned = manager.RecordEvent(goal);
        PauseWithMessage($"Event recorded. You earned {pointsEarned} points.");
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a whole number.");
        }
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }

    static void PauseWithMessage(string message)
    {
        Console.WriteLine(message);
        Pause();
    }
}
