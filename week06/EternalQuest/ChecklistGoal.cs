class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonus;
    private int _amountCompleted;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted >= _targetCount)
        {
            return 0;
        }

        _amountCompleted++;

        if (_amountCompleted == _targetCount)
        {
            return GetPoints() + _bonus;
        }

        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _targetCount;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Completed {_amountCompleted}/{_targetCount} times";
    }

    protected override string GetGoalStatus()
    {
        return IsComplete() ? "[X]" : "[ ]";
    }

    protected override string GetGoalData()
    {
        return $"{_amountCompleted}|{_targetCount}|{_bonus}";
    }

    protected override string GetTypeName()
    {
        return "ChecklistGoal";
    }
}
