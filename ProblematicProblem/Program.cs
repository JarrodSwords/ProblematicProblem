using System;
using System.Collections.Generic;
using static System.Console;

namespace ProblematicProblem
{
    public class Program
    {
        private static readonly List<string> activities = new List<string>
        {
            "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting"
        };

        private static readonly Random rng = new Random();

        #region Static Interface

        public static bool Prompt(string prompt, string confirmText)
        {
            var userInput = Prompt(prompt);
            return string.Equals(userInput, confirmText, StringComparison.CurrentCultureIgnoreCase);
        }

        public static string Prompt(string prompt)
        {
            Write(prompt);
            return ReadLine();
        }

        public static int? PromptInt(string prompt)
        {
            Write(prompt);

            return int.TryParse(ReadLine(), out var number)
                ? (int?) number
                : null;
        }

        public static void Main(string[] args)
        {
            var isGeneratingActivity = Prompt(
                "Hello, welcome to the random activity generator!\nWould you like to generate a random activity? yes/no: ",
                "yes"
            );

            if (!isGeneratingActivity)
                Environment.Exit(1);

            var username = Prompt("\nWe are going to need your information first! What is your name? ");

            var userAge = PromptInt("\nWhat is your age? ");

            var isDisplayingActivities = Prompt(
                "\nWould you like to see the current list of activities? Sure/No thanks: ",
                "Sure"
            );

            if (isDisplayingActivities)
            {
                foreach (var activity in activities)
                    Write($"{activity} ");

                var isAddingToList = Prompt(
                    "\nWould you like to add any activities before we generate one? yes/no: ",
                    "yes"
                );

                while (isAddingToList)
                {
                    var userAddition = Prompt("\nWhat would you like to add? ");

                    activities.Add(userAddition);

                    foreach (var activity in activities)
                        Write($"{activity} ");

                    isAddingToList = Prompt(
                        "\nWould you like to add more? yes/no: ",
                        "yes"
                    );
                }
            }

            var isRunning = true;
            while (isRunning)
            {
                Write("Connecting to the database");

                for (var i = 0; i < 10; i++)
                    Write(". ");

                Write("\nChoosing your random activity");

                for (var i = 0; i < 9; i++)
                    Write(". ");

                WriteLine();

                var index = rng.Next(activities.Count);

                var randomActivity = activities[index - 1];

                if (userAge > 21 && randomActivity == "Wine Tasting")
                {
                    WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                    index = rng.Next(activities.Count);

                    randomActivity = activities[index - 1];
                }

                isRunning = Prompt(
                    $"Ah got it! {username}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ",
                    "redo"
                );
            }
        }

        #endregion
    }
}
