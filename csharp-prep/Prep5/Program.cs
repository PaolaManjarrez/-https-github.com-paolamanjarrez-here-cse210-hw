using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        
        string Name = PromptUserName();
        
        int Number = PromptUserNumber();
        
        int SquaredNumber = SquareNumber(Number);
        
        DisplayResult(Name, SquaredNumber);
    }
    
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        return int.Parse(input);
    }
    
    static int SquareNumber(int number)
    {
        return number * number;
    }
    
    static void DisplayResult(string Name, int SquaredNumber)
    {
        Console.WriteLine($"{Name}, the square of your number is {SquaredNumber}");
    }
}
