using System;
using System.Collections.Generic;

namespace SwimApp
{
    class Program
    {

     //global variables
        static List<string> teamA = new List<string>();
        static List<string> teamB = new List<string>();
        static List<string> teamReserves = new List<string>();
        static float fastestTime = 9999f;
        static string topSwimmer = "";
        static void OneSwimmer()
        {


            string swimmerName = CheckName();
            
            Console.WriteLine($"Swimmer name: {swimmerName}");
            
            int sumTotalTime = 0;

            // Loop 4 times
            for (int i = 0; i < 4; i++)
            {
                int minutes, seconds, totalTime = 0;
                //Generate a random number between 1 and 4 (incl)
                Random randomNumber = new Random();
                minutes = randomNumber.Next(1, 4);
                seconds = randomNumber.Next(0, 59);
                totalTime = (minutes * 60) + seconds;
                Console.WriteLine($"Swimmer Time {i + 1}: {minutes}  min {seconds}  seconds\t\tTotal time in seconds: {totalTime}s");
                sumTotalTime = sumTotalTime + totalTime;

            }
            float avgTime = (float)sumTotalTime / 4;
            if (avgTime < fastestTime)
            {
                fastestTime = avgTime;
                topSwimmer = swimmerName;
            }
            string allocatedTeam = "Reserve";
            //assign the swimmer to a team
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
            else
            {
                teamReserves.Add(swimmerName);
            }
            Console.WriteLine($"Avg time: {avgTime}");
            Console.WriteLine($"Team: {allocatedTeam}");


        }
        //returns a string containing the team lists
        static string CreateTeamLists()
        {
            string teamLists = "\nThe teams are:\n\nTeam A\n";
            //add team A to team list
            foreach (string swimmer in teamA)
            {
                teamLists += swimmer + "\t";
            }
            teamLists += $"\nwith {teamA.Count} team member(s)\n\nTeam B\n";
            //add team B to team list
            foreach (string swimmer in teamB)
            {
                teamLists += swimmer + "\t";
            }
            teamLists += $"\nwith {teamB.Count} team member(s)\n\nTeam Reserves\n";
            //add team Reserves to team list
            foreach (string swimmer in teamReserves)
            {
                teamLists += swimmer + "\t";
            }
            teamLists += $"\nwith {teamReserves.Count} team member(s)\n\n";
            return teamLists;
        }
       
        static string CheckName()
        {
            while (true)
            {
                //get swimmer name
                Console.WriteLine("Enter the swimmer's name:\n");

                string name = Console.ReadLine();
                

                if (!name.Equals(""))

                {
                    //convert swimmer name to capitalized name
                    name = name[0].ToString().ToUpper() + name.Substring(1);
                    return name;
                }

                Console.WriteLine("Error! Please enter a name.\n");
            }



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
            Console.WriteLine($"The fastest swimmer was {topSwimmer} with an average time of {fastestTime} seconds");
            Console.WriteLine(CreateTeamLists());
        }
    }
} 