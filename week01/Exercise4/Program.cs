using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        int userNumber = -1;

        while (userNumber != 0){
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());
            if (userNumber != 0){
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        foreach (int number in numbers){
            sum += number;
        }

        double average = (double)sum / numbers.Count;

        if (numbers.Count == 0){
            Console.WriteLine("No numbers were entered.");
            return;
        }

        int largest = numbers[0];
        foreach (int number in numbers){
            if (number > largest){
                largest = number;
            }
        }

        int smallestPositive = int.MaxValue;

        foreach (int number in numbers){
            if (number > 0 && number < smallestPositive){
                smallestPositive = number;
            }
        }

        if (smallestPositive != int.MaxValue){
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        numbers.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers){
            Console.WriteLine(number);
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}