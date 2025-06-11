using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        string choice;
        do
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest");
            Console.WriteLine("Score: " + score);
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
            }
        } while (choice != "6");
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1": goals.Add(new SimpleGoal(name, desc, points)); break;
            case "2": goals.Add(new EternalGoal(name, desc, points)); break;
            case "3":
                Console.Write("Target Count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus Points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].Name} - {goals[i].Description}");
        }
        Console.WriteLine("\nPress Enter to return to menu...");
        Console.ReadLine();
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("\nEnter goal number to record: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            int points = goals[index].RecordEvent();
            score += points;
            Console.WriteLine($"Recorded! You earned {points} points.");
        }
        else Console.WriteLine("Invalid selection.");
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(score);
            foreach (var goal in goals)
                writer.WriteLine(goal.GetSaveData());
        }
        Console.WriteLine("Goals saved.");
        Console.ReadLine();
    }

    static void LoadGoals()
    {
        if (!File.Exists("goals.txt")) return;
        string[] lines = File.ReadAllLines("goals.txt");
        score = int.Parse(lines[0]);
        goals.Clear();
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string[] data = parts[1].Split(",");
            switch (parts[0])
            {
                case "SimpleGoal":
                    goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]))
                    {
                        // Completing a simple goal on load
                        _completed = bool.Parse(data[3])
                    });
                    break;
                case "EternalGoal":
                    goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;
                case "ChecklistGoal":
                    var cg = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[5]), int.Parse(data[3]));
                    cg.SetCurrentCount(int.Parse(data[4]));
                    goals.Add(cg);
                    break;
            }
        }
        Console.WriteLine("Goals loaded.");
        Console.ReadLine();
    }
}
