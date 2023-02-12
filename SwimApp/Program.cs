using System;
using System.Collections.Generic;

namespace SwimApp
{
    class Program
    {

        //global variables

        static List<string> teamA = new List<string>();

        static List<string> teamB = new List<string>();

        static List<string> teamReserve = new List<string>();

        static void OneSwimmer()
        {

            //start of code, asking user for name input

            Console.WriteLine("Input Swimmer's Name:");

            string swimmerName = Console.ReadLine();

            Console.WriteLine($"Swimmer Name: {swimmerName}");

            float sumTotalTime = 0;

            //loop four times
            for (int i = 0; i < 4; i++)

            {
             int minutes, seconds, totalTime = 0;
                //Generate random number between 1 and 4, 0 and 59.(inclusive)

                Random randomNumber = new Random();

                minutes = randomNumber.Next(1, 4);

                seconds = randomNumber.Next(0, 59);

                totalTime = (minutes * 60) + seconds;

                Console.WriteLine($"Swimmer Time {i + 1}: {minutes} min {seconds} seconds\nTotal time in seconds: {seconds}\n");

                //calculating average time

                sumTotalTime = sumTotalTime + totalTime;


            }

            float avgTime = sumTotalTime / 4;

            //assign the swimmer to a team
            //nested if statement
            if (avgTime <= 160)
            {
                teamA.Add(swimmerName);
            }
            else if (avgTime <= 210)
            {
                teamB.Add(swimmerName);
            }
            {
                teamReserve.Add(swimmerName);
            }

            Console.WriteLine($"Avg time : {avgTime}");

        }

        static void Main(string[] args)
        {
            OneSwimmer();
        }
    }
} 