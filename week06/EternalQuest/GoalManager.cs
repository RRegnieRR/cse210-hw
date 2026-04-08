using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public int GetScore()
    {
        return _score;
    }

    public int GetGoalCount()
    {
        return _goals.Count;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public Goal GetGoalByNumber(int goalNumber)
    {
        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            return null;
        }

        return _goals[goalNumber - 1];
    }

    public int RecordEvent(Goal goal)
    {
        int pointsEarned = goal.RecordEvent();
        _score += pointsEarned;
        return pointsEarned;
    }

    public void Save(string filename)
    {
        StreamWriter outputFile = new StreamWriter(filename);
        outputFile.WriteLine($"Score|{_score}");

        foreach (Goal goal in _goals)
        {
            outputFile.WriteLine(goal.GetStringRepresentation());
        }

        outputFile.Close();
    }

    public void Load(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();
        _score = 0;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split("|");

            if (parts[0] == "Score")
            {
                _score = int.Parse(parts[1]);
            }
            else
            {
                _goals.Add(Goal.CreateGoal(line));
            }
        }
    }

    public string GetLevelDescription()
    {
        if (_score >= 5000)
        {
            return "Master Disciple";
        }

        if (_score >= 2500)
        {
            return "Steady Saint";
        }

        if (_score >= 1000)
        {
            return "Growing Guide";
        }

        if (_score >= 250)
        {
            return "Faithful Beginner";
        }

        return "New Adventurer";
    }

    public string GetPointsToNextLevel()
    {
        if (_score < 250)
        {
            return $"{250 - _score} points to reach Faithful Beginner";
        }

        if (_score < 1000)
        {
            return $"{1000 - _score} points to reach Growing Guide";
        }

        if (_score < 2500)
        {
            return $"{2500 - _score} points to reach Steady Saint";
        }

        if (_score < 5000)
        {
            return $"{5000 - _score} points to reach Master Disciple";
        }

        return "You are already at the highest level";
    }
}
