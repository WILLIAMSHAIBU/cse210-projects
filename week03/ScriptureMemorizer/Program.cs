using System;

// Scripture Memorizer Program
// Features that exceed core requirements:
// - Prevents hiding already hidden words
// - Uses multiple constructors for Reference
// - Uses encapsulated classes for structure and behavior
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";

        Scripture scripture = new Scripture(reference, scriptureText);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            if (!scripture.AllWordsHidden())
            {
                scripture.HideRandomWords(3);
            }

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }
        }
    }
}
