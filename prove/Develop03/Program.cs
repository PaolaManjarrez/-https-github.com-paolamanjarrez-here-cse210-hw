using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    public string Text { get; set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
}

public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string book, int chapter, int startVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = startVerse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (StartVerse == EndVerse)
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}

public class Scripture
{
    private readonly Reference reference;
    private readonly List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(reference.ToString());
        foreach (var word in words)
        {
            if (word.IsHidden)
            {
                Console.Write("_ ");
            }
            else
            {
                Console.Write(word.Text + " ");
            }
        }
        Console.WriteLine();
    }

    public void HideRandomWord()
    {
        var visibleWords = words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count == 0)
        {
            return;
        }

        Random random = new Random();
        int index = random.Next(0, visibleWords.Count);
        visibleWords[index].IsHidden = true;
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                break;
            }

            try
            {
                if (!Console.IsOutputRedirected)
                {
                    Console.Clear();
                }
                scripture.HideRandomWord();
                scripture.Display();
            }
            catch (System.IO.IOException)
            {
            }
        }

        Console.WriteLine("All words are hidden. Press any key to exit.");
        Console.ReadKey();
    }
}

