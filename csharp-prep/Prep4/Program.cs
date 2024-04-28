using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        int user;
        do
        {
            Console.Write("Enter a number: ");
            string number = Console.ReadLine();
            
            if (!int.TryParse(number, out user))
            {
                Console.WriteLine("Invalid number. Please enter a valid integer.");
                continue;
            }
            
            if (user != 0)
            {
                numbers.Add(user);
            }
        } while (user != 0);

        if (numbers.Count > 0)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"The sum is: {sum}");

            float average = (float)sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            int max = numbers.Max();
            Console.WriteLine($"The max is: {max}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}