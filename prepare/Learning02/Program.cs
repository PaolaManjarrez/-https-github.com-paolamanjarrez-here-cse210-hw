using System;
using System;
using System.Collections.Generic;

class Job
{
    public string JobTitle { get; set; }
    public string Company { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

class Resume
{
    public string Name { get; set; }
    public List<Job> Jobs { get; set; }

    public Resume()
    {
        Jobs = new List<Job>();
    }

    public void Display()
    {
        Console.WriteLine("Resume of: " + Name);
        Console.WriteLine("Jobs:");

        foreach (var job in Jobs)
        {
            Console.WriteLine("Title: " + job.JobTitle);
            Console.WriteLine("Company: " + job.Company);
            Console.WriteLine("Start Date: " + job.StartDate.ToString("MMMM yyyy"));
            Console.WriteLine("End Date: " + job.EndDate.ToString("MMMM yyyy"));
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job
        {
            JobTitle = "Software Engineer",
            Company = "Microsoft",
            StartDate = new DateTime(2019, 1, 1),
            EndDate = new DateTime(2022, 12, 31)
        };

        Job job2 = new Job
        {
            JobTitle = "Manager",
            Company = "Apple",
            StartDate = new DateTime(2022, 1, 1),
            EndDate = new DateTime(2023, 12, 31)
        };

        Resume myResume = new Resume
        {
            Name = "Allison Rose"
        };

        myResume.Jobs.Add(job1);
        myResume.Jobs.Add(job2);

        myResume.Display();
    }
}
