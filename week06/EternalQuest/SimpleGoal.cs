class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    protected override string GetGoalStatus()
    {
        return _isComplete ? "[X]" : "[ ]";
    }

    protected override string GetGoalData()
    {
        return _isComplete.ToString();
    }

    protected override string GetTypeName()
    {
        return "SimpleGoal";
    }
}
