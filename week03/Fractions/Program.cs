
using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());  // Output: 1/1
        Console.WriteLine(f1.GetDecimalValue());    // Output: 1.0

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());  // Output: 5/1
        Console.WriteLine(f2.GetDecimalValue());    // Output: 5.0

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());  // Output: 3/4
        Console.WriteLine(f3.GetDecimalValue());    // Output: 0.75

   
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());  // Output: 1/3
        Console.WriteLine(f4.GetDecimalValue());    // Output: 0.3333...

        // Demonstrate Setters and Getters
        f4.SetTop(7);
        f4.SetBottom(8);
        Console.WriteLine($"Updated Fraction: {f4.GetFractionString()}");  // Output: 7/8
        Console.WriteLine($"Decimal: {f4.GetDecimalValue()}");             // Output: 0.875
    }
}
