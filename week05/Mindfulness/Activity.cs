abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    protected Random _random = new Random();

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string Name => _name;
    public int Duration => _duration;

    public abstract void Run();

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        _duration = PromptForDuration();
        Console.WriteLine();
        Console.Write("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index = (index + 1) % spinner.Count;
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            if (i >= 10)
            {
                Console.Write("\b \b");
            }
        }
    }

    protected int GetTimeRemaining(DateTime endTime)
    {
        int secondsLeft = (int)(endTime - DateTime.Now).TotalSeconds;

        if (secondsLeft < 0)
        {
            secondsLeft = 0;
        }

        return secondsLeft;
    }

    private int PromptForDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int duration) && duration > 0)
            {
                return duration;
            }

            Console.WriteLine("Please enter a whole number greater than 0.");
        }
    }
}
