using System;
using System.Collections.Generic;
using System.IO;


public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsComplete = false;
    }

    public abstract void RecordEvent();
    public abstract string Status();
}

// Simple goal class
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        IsComplete = true;
    }

    public override string Status()
    {
        return IsComplete ? "[X]" : "[ ]";
    }
}


public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        IsComplete = false; // Never complete
    }

    public override string Status()
    {
        return "[Eternal]";
    }
}


public class ChecklistGoal : Goal
{
    public int RequiredTimes { get; set; }
    public int CompletedTimes { get; set; }

    public ChecklistGoal(string name, int points, int requiredTimes) : base(name, points)
    {
        RequiredTimes = requiredTimes;
        CompletedTimes = 0;
    }

    public override void RecordEvent()
    {
        if (CompletedTimes < RequiredTimes)
        {
            CompletedTimes++;
            if (CompletedTimes == RequiredTimes)
            {
                IsComplete = true;
            }
        }
    }

    public override string Status()
    {
        return $"{CompletedTimes}/{RequiredTimes}";
    }
}

public class EternalQuest
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in goals)
        {
            if (goal.Name == goalName)
            {
                goal.RecordEvent();
                score += goal.Points;
                break;
            }
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.Name} - {goal.Status()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {score}");
    }

    public int CalculateLevel()
    {
        return score / 1000; // Example: Level up for every 1000 points
    }

    public void DisplayBadges()
    {
        if (score >= 5000)
        {
            Console.WriteLine("Badge: Master Achiever");
        }
        else if (score >= 2000)
        {
            Console.WriteLine("Badge: Dedicated Worker");
        }
        else if (score >= 1000)
        {
            Console.WriteLine("Badge: Novice Achiever");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points},{goal.IsComplete},{goal.Status()}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                score = int.Parse(reader.ReadLine());
                goals.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    var goalType = parts[0];
                    var name = parts[1];
                    var points = int.Parse(parts[2]);
                    var isComplete = bool.Parse(parts[3]);

                    if (goalType == nameof(SimpleGoal))
                    {
                        var goal = new SimpleGoal(name, points) { IsComplete = isComplete };
                        goals.Add(goal);
                    }
                    else if (goalType == nameof(EternalGoal))
                    {
                        var goal = new EternalGoal(name, points) { IsComplete = isComplete };
                        goals.Add(goal);
                    }
                    else if (goalType == nameof(ChecklistGoal))
                    {
                        var requiredTimes = int.Parse(parts[4]);
                        var completedTimes = int.Parse(parts[5]);
                        var goal = new ChecklistGoal(name, points, requiredTimes) { IsComplete = isComplete, CompletedTimes = completedTimes };
                        goals.Add(goal);
                    }
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        var program = new EternalQuest();

        program.AddGoal(new SimpleGoal("Run Marathon", 1000));
        program.AddGoal(new EternalGoal("Read Scriptures", 100));
        program.AddGoal(new ChecklistGoal("Attend Temple", 50, 10));

        program.RecordEvent("Read Scriptures");
        program.RecordEvent("Attend Temple");

        program.DisplayGoals();
        program.DisplayScore();
        Console.WriteLine($"Current Level: {program.CalculateLevel()}");
        program.DisplayBadges();

        program.SaveToFile("goals.txt");
        program.LoadFromFile("goals.txt");

        program.DisplayGoals();
        program.DisplayScore();
        Console.WriteLine($"Current Level: {program.CalculateLevel()}");
        program.DisplayBadges();
    }
}
