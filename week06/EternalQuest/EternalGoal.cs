class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    protected override string GetGoalStatus()
    {
        return "[ ]";
    }

    protected override string GetGoalData()
    {
        return "NA";
    }

    protected override string GetTypeName()
    {
        return "EternalGoal";
    }
}
