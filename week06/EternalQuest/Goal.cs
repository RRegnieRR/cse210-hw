using System;

abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    protected abstract string GetGoalStatus();
    protected abstract string GetGoalData();

    public virtual string GetDetailsString()
    {
        return $"{GetGoalStatus()} {_name} ({_description})";
    }

    public string GetStringRepresentation()
    {
        return $"{GetTypeName()}|{_name}|{_description}|{_points}|{GetGoalData()}";
    }

    protected abstract string GetTypeName();

    public static Goal CreateGoal(string line)
    {
        string[] parts = line.Split("|");

        string type = parts[0];
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);

        if (type == "SimpleGoal")
        {
            return new SimpleGoal(name, description, points, bool.Parse(parts[4]));
        }

        if (type == "EternalGoal")
        {
            return new EternalGoal(name, description, points);
        }

        if (type == "ChecklistGoal")
        {
            int amountCompleted = int.Parse(parts[4]);
            int targetCount = int.Parse(parts[5]);
            int bonus = int.Parse(parts[6]);
            return new ChecklistGoal(name, description, points, targetCount, bonus, amountCompleted);
        }

        throw new Exception("Invalid goal type");
    }
}
