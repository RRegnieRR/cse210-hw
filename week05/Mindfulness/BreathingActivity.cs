class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            int breatheInSeconds = GetTimeRemaining(endTime);

            if (breatheInSeconds > 4)
            {
                breatheInSeconds = 4;
            }

            if (breatheInSeconds == 0)
            {
                break;
            }

            Console.Write("Breathe in...");
            ShowCountDown(breatheInSeconds);
            Console.WriteLine();
            Console.WriteLine();

            int breatheOutSeconds = GetTimeRemaining(endTime);

            if (breatheOutSeconds > 6)
            {
                breatheOutSeconds = 6;
            }

            if (breatheOutSeconds == 0)
            {
                break;
            }

            Console.Write("Breathe out...");
            ShowCountDown(breatheOutSeconds);
            Console.WriteLine();
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
