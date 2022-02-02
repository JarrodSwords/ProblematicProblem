using System;
using System.Collections.Generic;

namespace ProblematicProblem
{
    public class Program
    {
        private static readonly List<string> activities = new List<string>
        {
            "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting"
        };

        private static Random rng;

        #region Static Interface

        public static void Main(string[] args)
        {
            Console.Write(
                "Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: "
            );

            var userInput = Console.ReadLine() ?? "";
            var isGeneratingActivity = userInput.ToLower() == "yes";

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            var userName = Console.ReadLine();

            Console.WriteLine();
            Console.Write("What is your age? ");
            int.TryParse(Console.ReadLine(), out var userAge);

            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            userInput = Console.ReadLine() ?? "";
            var isDisplayingList = userInput == "Sure";

            if (isDisplayingList)
            {
                foreach (var activity in activities)
                    Console.Write($"{activity} ");

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                userInput = Console.ReadLine() ?? "";
                var isAddingToList = userInput.ToLower() == "yes";

                Console.WriteLine();

                while (isAddingToList)
                {
                    Console.Write("What would you like to add? ");
                    var userAddition = Console.ReadLine();

                    activities.Add(userAddition);

                    foreach (var activity in activities)
                        Console.Write($"{activity} ");

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    userInput = Console.ReadLine() ?? "";
                    isAddingToList = userInput.ToLower() == "yes";
                }
            }

            var isRunning = true;
            while (isRunning)
            {
                Console.Write("Connecting to the database");

                for (var i = 0; i < 10; i++)
                    Console.Write(". ");

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (var i = 0; i < 9; i++)
                    Console.Write(". ");

                Console.WriteLine();

                var randomNumber = rng.Next(activities.Count);

                var randomActivity = activities[randomNumber];

                if (userAge > 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }

                Console.Write(
                    $"Ah got it! {randomActivity}, your random activity is: {userName}! Is this ok or do you want to grab another activity? Keep/Redo: "
                );

                Console.WriteLine();
                isRunning = bool.Parse(Console.ReadLine());
            }
        }

        #endregion
    }
}
