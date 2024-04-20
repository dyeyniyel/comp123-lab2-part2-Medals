using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_02_lab_06_Medal_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create a medal object
            Medal m1 = new Medal("Horace Gwynne", "Boxing", MedalColor.Gold, 2012, true);
            //print the object
            Console.WriteLine(m1);
            //print only the name of the medal holder
            Console.WriteLine(m1.Name);
            //create another object
            Medal m2 = new Medal("Michael Phelps", "Swimming", MedalColor.Gold, 2012, false);
            //print the updated m2
            Console.WriteLine(m2);

            //create a list to store the medal objects
            List<Medal> medals = new List<Medal>() { m1, m2 };
            medals.Add(new Medal("Ryan Cochrane", "Swimming", MedalColor.Silver, 2012, false));
            medals.Add(new Medal("Adam van Koeverden", "Canoeing", MedalColor.Silver, 2012, false));
            medals.Add(new Medal("Rosie MacLennan", "Gymnastics", MedalColor.Gold, 2012, false));
            medals.Add(new Medal("Christine Girard", "Weightlifting", MedalColor.Bronze, 2012, false));
            medals.Add(new Medal("Charles Hamelin", "Short Track", MedalColor.Gold, 2014, true));
            medals.Add(new Medal("Alexandre Bilodeau", "Freestyle skiing", MedalColor.Gold, 2012, true));
            medals.Add(new Medal("Jennifer Jones", "Curling", MedalColor.Gold, 2014, false));
            medals.Add(new Medal("Charle Cournoyer", "Short Track", MedalColor.Bronze, 2014, false));
            medals.Add(new Medal("Mark McMorris", "Snowboarding", MedalColor.Bronze, 2014, false));
            medals.Add(new Medal("Sidney Crosby ", "Ice Hockey", MedalColor.Gold, 2014, false));
            medals.Add(new Medal("Brad Jacobs", "Curling", MedalColor.Gold, 2014, false));
            medals.Add(new Medal("Ryan Fry", "Curling", MedalColor.Gold, 2014, false));
            medals.Add(new Medal("Antoine Valois-Fortier", "Judo", MedalColor.Bronze, 2012, false));
            medals.Add(new Medal("Brent Hayden", "Swimming", MedalColor.Bronze, 2012, false));


            //prints a numbered list of 16 medals.
            Console.WriteLine("\n\nAll 16 medals");
            for (int i = 0; i < medals.Count; i++) //using for loop to list down all 16 medals. 
            {
                Console.WriteLine($"{ i + 1}) { medals[i].ToString()}"); //List will start at number 1
            }

            //prints a numbered list of 16 names (ONLY)
            Console.WriteLine("\n\nAll 16 names");
            for (int i = 0; i < medals.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {medals[i].Name}");
            }

            //prints a numbered list of 9 gold medals
            Console.WriteLine("\n\nAll 9 gold medals");
            int goldMedalsCount = 0; //setting variable so that the numbered list will not get the initial index value. The value will be ascending (i.e, 1,2,3,...)
            for (int i = 0; i < medals.Count; i++)
            {
                if (medals[i].Color == MedalColor.Gold) //for loop so that the numbered list will be in chronological order
                {
                    goldMedalsCount++;
                    Console.WriteLine($"{goldMedalsCount}) {medals[i]}");
                }
            }

            //prints a numbered list of 9 medals in 2012
            Console.WriteLine("\n\nAll 9 medals in 2012");
            int medalsCount2012 = 0;
            for (int i = 0; i < medals.Count; i++)
            {
                if (medals[i].Year == 2012) //this will only extract the list for medals obtained in 2012
                {
                    medalsCount2012++;
                    Console.WriteLine($"{medalsCount2012}) {medals[i]}");
                }
            }

            //prints a numbered list of 4 gold medals in 2012
            Console.WriteLine("\n\nAll 4 gold medals in 2012");
            int goldMedalsCount2012 = 0;
            for (int i = 0; i < medals.Count; i++)
            {
                if ((medals[i].Year == 2012) && (medals[i].Color == MedalColor.Gold)) //this will only extract the list for medals which are gold and obtained in 2012
                {
                    goldMedalsCount2012++;
                    Console.WriteLine($"{goldMedalsCount2012}) {medals[i]}");
                }
            }

            //prints a numbered list of 3 world record medals
            Console.WriteLine("\n\nAll 3 world record medals");
            int worldRecordCount = 0;
            for (int i = 0; i < medals.Count; i++)
            {
                if (medals[i].IsRecord == true)   //this will only extract the list of world record medals
                {
                    worldRecordCount++;
                    Console.WriteLine($"{worldRecordCount}) {medals[i]}");
                }
            }

            //saving all the medal to file Medals.txt
            Console.WriteLine("\n\nSaving to file Medals.txt");
            using (StreamWriter savetofile = new StreamWriter("Medals.txt")) //using StreamWriter to print the list of medals on the Medals.txt file
            {
                for (int i = 0; i < medals.Count; i++)
                {
                    savetofile.WriteLine($"{i + 1}) {medals[i]}");
                }
            }
            Console.ReadKey();  
        }
    }
    
    //declare enum for medal color
    public enum MedalColor
    {
        Bronze,
        Silver,
        Gold
    }

    internal class Medal
    {
        //properties with setter absent on all
        public string Name { get; }
        public string TheEvent { get; }
        public MedalColor Color { get; }
        public int Year { get; }
        public bool IsRecord { get; }

        //constructor with 5 arguments
        public Medal(string name, string theEvent, MedalColor color, int year, bool isRecord)
        {
            Name = name;
            TheEvent = theEvent;
            Color = color;
            Year = year;
            IsRecord = isRecord;
        }

        //method to  overrides the ToString of the object class
        public override string ToString()
        {
            return $"{Year} - {TheEvent}{(IsRecord ? "(R)" : "")} {Name}({Color})";
        }
    }
}

