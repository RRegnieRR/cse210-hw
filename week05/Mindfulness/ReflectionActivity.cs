class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private List<string> _unusedPrompts = new List<string>();
    private List<string> _unusedQuestions = new List<string>();

    public ReflectionActivity()
        : base(
            "Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        ResetUnusedPrompts();
        ResetUnusedQuestions();
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {prompt} ---");
        Console.WriteLine();
        Console.Write("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            int pauseTime = GetTimeRemaining(endTime);

            if (pauseTime > 5)
            {
                pauseTime = 5;
            }

            if (pauseTime == 0)
            {
                break;
            }

            Console.Write($"> {question} ");
            ShowSpinner(pauseTime);
            Console.WriteLine();
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            ResetUnusedPrompts();
        }

        int promptNumber = _random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[promptNumber];
        _unusedPrompts.RemoveAt(promptNumber);
        return prompt;
    }

    private string GetRandomQuestion()
    {
        if (_unusedQuestions.Count == 0)
        {
            ResetUnusedQuestions();
        }

        int questionNumber = _random.Next(_unusedQuestions.Count);
        string question = _unusedQuestions[questionNumber];
        _unusedQuestions.RemoveAt(questionNumber);
        return question;
    }

    private void ResetUnusedPrompts()
    {
        _unusedPrompts = new List<string>(_prompts);
    }

    private void ResetUnusedQuestions()
    {
        _unusedQuestions = new List<string>(_questions);
    }
}
