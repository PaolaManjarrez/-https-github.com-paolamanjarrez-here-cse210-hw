using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    public abstract class MindfulnessActivity
    {
        protected int duration;

        public void StartMessage(string activityName, string description)
        {
            Console.WriteLine($"Starting {activityName} activity.");
            Console.WriteLine(description);
            Console.Write("Enter the duration of the activity in seconds: ");
            duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
            PauseWithAnimation(3);
        }

        public void EndMessage(string activityName)
        {
            Console.WriteLine($"Good job! You have completed the {activityName} activity for {duration} seconds.");
            PauseWithAnimation(3);
        }

        protected void PauseWithAnimation(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        public abstract void PerformActivity();
    }

    public class BreathingActivity : MindfulnessActivity
    {
        public override void PerformActivity()
        {
            StartMessage("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
            for (int i = 0; i < duration / 2; i++)
            {
                Console.WriteLine("Breathe in...");
                PauseWithAnimation(4);
                Console.WriteLine("Breathe out...");
                PauseWithAnimation(4);
            }
            EndMessage("Breathing");
        }
    }

    public class ReflectionActivity : MindfulnessActivity
    {
        private List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public override void PerformActivity()
        {
            StartMessage("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine(prompt);
            PauseWithAnimation(3);
            foreach (string question in questions)
            {
                Console.WriteLine(question);
                PauseWithAnimation(5);
            }
            EndMessage("Reflection");
        }
    }

    public class ListingActivity : MindfulnessActivity
    {
        private List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public override void PerformActivity()
        {
            StartMessage("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine(prompt);
            PauseWithAnimation(3);
            Console.WriteLine("Start listing items:");
            List<string> items = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < endTime)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrEmpty(item))
                {
                    items.Add(item);
                }
            }
            Console.WriteLine($"You listed {items.Count} items.");
            EndMessage("Listing");
        }
    }

       class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                MindfulnessActivity activity = null;

                switch (choice)
                {
                    case 1:
                        activity = new BreathingActivity();
                        break;
                    case 2:
                        activity = new ReflectionActivity();
                        break;
                    case 3:
                        activity = new ListingActivity();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again.");
                        continue;
                }

                activity.PerformActivity();
            }
        }
    }
}
