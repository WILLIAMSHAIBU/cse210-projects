using System;

class Program
{
    static void Main(string[] args)
    {
         Console.WriteLine("Enter your first Name: ");
        string first_name = Console.ReadLine();

        Console.WriteLine("Enter your last Name: ");
        string last_name = Console.ReadLine();

        Console.WriteLine($"My name is {last_name}, {first_name} {last_name}");
    }
}
