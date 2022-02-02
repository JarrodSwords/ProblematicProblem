using System;
using System.Collections.Generic;
using static System.Console;
using static System.Threading.Thread;

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

        public static void PrintActivities()
        {
            foreach (var activity in activities)
            {
                Write($"{activity} ");
                Sleep(250);
            }
        }

        public static void PrintEllipsis(int count = 10)
        {
            for (var i = 0; i < count; i++)
            {
                Write(". ");
                Sleep(500);
            }
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
                PrintActivities();

                var isAddingToList = Prompt(
                    "\nWould you like to add any activities before we generate one? yes/no: ",
                    "yes"
                );

                while (isAddingToList)
                {
                    var userAddition = Prompt("\nWhat would you like to add? ");

                    activities.Add(userAddition);

                    PrintActivities();

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
                PrintEllipsis();

                Write("\nChoosing your random activity");
                PrintEllipsis();

                WriteLine();

                var index = rng.Next(activities.Count);

                var activity = activities[index - 1];

                if (userAge > 21 && activity == "Wine Tasting")
                {
                    WriteLine($"Oh no! Looks like you are too young to do {activity}");
                    WriteLine("Pick something else!");

                    activities.Remove(activity);

                    index = rng.Next(activities.Count);

                    activity = activities[index - 1];
                }

                isRunning = Prompt(
                    $"Ah got it! {username}, your random activity is: {activity}! Is this ok or do you want to grab another activity? Keep/Redo: ",
                    "redo"
                );
            }
        }

        #endregion
    }
}
