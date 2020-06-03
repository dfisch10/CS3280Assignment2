using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Assignment_2
{
    class Program
    {
        /// <summary>
        /// This is my main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var namesList = new List<String>();

            while (namesList.Count < 5)
            {
                NameInputFormatChecking(namesList);
            }

            SortInputDisplayer(namesList);
        }

        /// <summary>
        /// Takes the input from the user as to whether they want to sort by 'first' name or 'last' name, 
        /// and then runs the appropriate method (sortFirstName() or sortLastName()).
        /// Otherwise it throws a message saying only 'last' and 'first' are accepted inputs.
        /// </summary>
        /// <param name="namesList"> List of names User inputted</param>
        private static void SortInputDisplayer(List<string> namesList)
        {
            Console.WriteLine("Would you like to sort the list of names by 'first' or 'last' name?");
            
            String input = Console.ReadLine();

            while (true)
            {
                if (input == "first")
                {
                    sortFirstName(namesList);
                    break;
                }

                else if (input == "last")
                {
                    sortLastName(namesList);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("The only valid inputs are 'first' and 'last', please try again.");
                    Console.ResetColor();
                    SortInputDisplayer(namesList);
                    break;
                }
            }
        }

        /// <summary>
        /// Checks the names the user is inputting to ensure they are not entering empty/null values, not entering duplicate names, 
        /// and that there is a space between the first and last name.
        /// </summary>
        /// <param name="namesList">List of names User inputted</param>
        private static void NameInputFormatChecking(List<string> namesList)
        {
            Console.Write("Please enter a first and last name(with a space in between):");

            String name = Console.ReadLine();

            if (namesList.Contains(name.ToLower()))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You may not have duplicate names, please choose a new name.");
                Console.ResetColor();
            }

            else if (String.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Names can not be null/empty. Please try again.");
                Console.ResetColor();
            }

            else if (!name.Contains(" "))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You must include a space between your first and last names.");
                Console.ResetColor();
            }

            else
            {
                namesList.Add(name.ToLower());
            }
        }

        /// <summary>
        /// Takes the user inputted list, and reorganizes the names to be lastname, then first name, with a comma in between (I.E. lastname, firstname).
        /// Then returns the new list which is sorted by last name.
        /// </summary>
        /// <param name="namesList">List of names User inputted</param>
        private static void sortLastName(List<string> namesList)
        {
            var lastFirst = new List<String>();

            foreach (String names in namesList)
            {
                var splitNames = names.Split(' ');

                var firstName = splitNames[0];

                var lastName = splitNames[1];

                var newList = lastName + ", " + firstName;

                lastFirst.Add(newList);
            }

            lastFirst.Sort();

            foreach (String names in lastFirst)
            {
                Console.WriteLine(names);
            }
        }

        /// <summary>
        /// Takes the User inputted list and sorts it (by first name)
        /// </summary>
        /// <param name="namesList">List of names User inputted</param>
        private static void sortFirstName(List<string> namesList)
        {
            namesList.Sort();

            foreach (String names in namesList)
            {
                Console.WriteLine(names);
            }
        }
    }
}