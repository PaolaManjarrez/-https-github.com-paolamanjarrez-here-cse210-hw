using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
}

class SaveJournal
{
    private List<JournalEntry> entries;
    private Random random;
    private List<string> prompts;

    public SaveJournal()
    {
        entries = new List<JournalEntry>();
        random = new Random();
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    public void WriteNewEntry()
    {
        string randomPrompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(randomPrompt);
        string response = Console.ReadLine();
        entries.Add(new JournalEntry { Prompt = randomPrompt, Response = response, Date = DateTime.Now });
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}, Prompt: {entry.Prompt}, Response: {entry.Response}");
        }
    }

    public void SaveJournalToCSV()
    {
        Console.Write("Enter file name to save as CSV: ");
        string fileName = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("Date,Prompt,Response");
            foreach (var entry in entries)
            {
                writer.WriteLine($"\"{entry.Date}\",\"{entry.Prompt.Replace("\"", "\"\"")}\",\"{entry.Response.Replace("\"", "\"\"")}\"");
            }
        }
        Console.WriteLine("Journal saved successfully as CSV!");
    }

    public void LoadJournalFromCSV()
    {
        Console.Write("Enter file name to load CSV: ");
        string fileName = Console.ReadLine();
        if (File.Exists(fileName))
        {
            entries.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                // Skip header line
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    DateTime date = DateTime.Parse(parts[0].Trim('"'));
                    string prompt = parts[1].Trim('"').Replace("\"\"", "\"");
                    string response = parts[2].Trim('"').Replace("\"\"", "\"");
                    entries.Add(new JournalEntry { Date = date, Prompt = prompt, Response = response });
                }
            }
            Console.WriteLine("Journal loaded successfully from CSV!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SaveJournal journal = new SaveJournal();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a CSV file");
            Console.WriteLine("4. Load the journal from a CSV file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournalToCSV();
                    break;
                case "4":
                    journal.LoadJournalFromCSV();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }
}
