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

        static float fastestTime = 9999f;

        static string topSwimmer = "";

        static void OneSwimmer()
        {

            //start of code, asking user for name input

            Console.WriteLine("Input Swimmer's Name:");

            string swimmerName = Console.ReadLine();

            Console.WriteLine($"Swimmer Name: {swimmerName}");

            float sumTotalTime = 0;

            string allocatedTeam = "Reserve";

            //loop four times
            for (int i = 0; i < 4; i++)

            {
             int minutes, seconds, totalTime = 0;
                //Generate random number between 1 and 4, 0 and 59.(inclusive)

                Random randomNumber = new Random();

                minutes = randomNumber.Next(1, 4);

                seconds = randomNumber.Next(0, 59);

                totalTime = (minutes * 60) + seconds;

                Console.WriteLine($"Swimmer Time {i + 1}: {minutes} min {seconds} seconds\t\tTotal time in seconds: {seconds}s");

                //calculating average time

                sumTotalTime = sumTotalTime + totalTime;


            }

            float avgTime = sumTotalTime / 4;

            if (avgTime < fastestTime)
            {
                fastestTime = avgTime;

                topSwimmer = swimmerName;
            }

            //assign the swimmer to a team
            //nested if statement
            if (avgTime <= 160)
            {
                teamA.Add(swimmerName);
                allocatedTeam = "A";
            }
            else if (avgTime <= 210)
            {
                teamB.Add(swimmerName);
                allocatedTeam = "B";
            }
            {
                teamReserve.Add(swimmerName);

            }

            Console.WriteLine($"Avg time : {avgTime}");

            Console.WriteLine($"Team: {allocatedTeam}");

        }

        //returns string containing team lists
        static string CreateTeamLists()
        {
            string teamLists = "The Teams are:\n\nTeam A\n";
            //adding each team to team lists
            foreach (string swimmer in teamA)
            {
                //seperation between names
                teamLists += swimmer + "\t";
            }

            teamLists += $"\n\nwith {teamA.Count} team members(s)\n\nTeam B:";

            foreach (string swimmer in teamB)
            {
                //seperation between names
                teamLists += swimmer + "\t";
            }

            teamLists += $"with {teamB.Count} team members(s)Team Reserve:\n\n";

            foreach (string swimmer in teamReserve)
            {
                //seperation between names
                teamLists += swimmer + "\t";
            }

            teamLists += $"with {teamReserve.Count} team members(s)\n\n";

            return teamLists;
        }

        static void Main(string[] args)
        {
            string flag = "";
            while (!flag.Equals("Stop"))
            {
                OneSwimmer();

                Console.WriteLine("Press <Enter> to add another swimmer or type 'Stop' to end");

                flag = Console.ReadLine();
            }

            Console.WriteLine($"The fastest swimmer: {topSwimmer} with an average time of {fastestTime} seconds.");

            Console.WriteLine(CreateTeamLists());

        }
    }
} 