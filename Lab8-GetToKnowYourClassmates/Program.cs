using System;
using System.Collections.Generic;

    //  Author: Jeffrey Wohlfield
    //  Date:   01-27-2021

namespace Lab8_GetToKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Create lists to store all data
            List<string> names = new List<string>()
            {
                "Ramon Guarnes", "Antonio Manzari", "Joshua Carolin", "Nick D'Oria", "Jeremiah Wyeth", "Wendi Magee", "Juliana TheCoder",
                "Nathaniel Davis", "Tommy Waalkes", "Grace Seymore", "Jeffrey Wohlfield", "Josh Gallentine", "Stephen Jedlicki"
            };
            
            List<string> towns = new List<string>()
            {
                "Tigard, OR", "Beverly Hills, MI", "Novi, MI", "Canton, MI", "Crystal, MI", "Detroit, MI",
                "Denver, CO", "Berkley, MI", "Raleigh, NC", "Mesa, AZ", "Detroit, MI", "Baldwin, MI", "West Philadelphia, PA"
            };

            List<string> food = new List<string>()
            {
                "Burgers", "Focaccia Barese", "Naleski", "Tacos", "Burgers", "Salami", "Tacos", "Steak", "Chicken Curry",
                "Sweet Potato Fries", "Steak", "Falafel", "Knuckle Sandwiches"
            };

            //Console.WriteLine($"Names:\n{String.Join("\n", names)}");
            Console.WriteLine("Welcome to the Grand Circus C# class!");

            string studentName; int studentID;

            while (true)
            {
                //  Prompt for user input to pick a student
                Console.Write($"Which student would you like to lean more about? (enter a number 1-{names.Count}) ");
                string input = Console.ReadLine();

                studentID = GetStudentID(names, input);

                if(studentID == -1)
                {
                    continue;
                }

                studentName = names[studentID];
                Console.WriteLine($"Student {studentID + 1} is {studentName}. What would you like to know about " +
                    $"{studentName.Substring(0, studentName.IndexOf(" "))}?");
                    do
                    {
                        Console.Write($"(enter \"hometown\" or \"favorite food\") ");
                        string response = Console.ReadLine().ToLower();

                        if(response == "hometown")
                         {
                            Console.WriteLine($"{studentName} is from {towns[studentID]}.\n");
                         }
                        else if(response == "favorite food")
                         {
                            Console.WriteLine($"{studentName} loves {food[studentID]}.\n");
                         }
                        else
                         {
                            Console.WriteLine("That data does not exist.  Please try again.");
                            continue;
                         }

                            Console.Write("Would you like to know more? ");
                            if (Console.ReadLine().ToLower() != "y")
                            {
                            break;
                            }
                    } while (true);
                
                Console.Write("Would you like to check another student? ");
                if(Console.ReadLine().ToLower() != "y")
                {
                    break;
                }
            }
            Console.WriteLine("Goodbye!");
        }

        public static int GetStudentID(List<string> names, string input)
        {
            int selection;
            try
            {
                selection = int.Parse(input) - 1;
                string studentName = names[selection];
                return selection;

            }
            catch (FormatException e1)
            {
                Console.WriteLine("You didn't enter a number");
                Console.WriteLine(e1.Message);
                Console.WriteLine("Let's try again");
            }
            catch (ArgumentOutOfRangeException e2)
            {
                Console.WriteLine("That student does not exist");
                Console.WriteLine(e2.Message);
                Console.WriteLine("Let's try again");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine(e.Message);
                Console.WriteLine("Let's try again");
                return -1;
            }
            return -1;
        }

    }
}
