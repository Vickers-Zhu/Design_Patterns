using System;
using System.Collections.Generic;

namespace DataFrames
{
    class Program
    {
        static void PrintDataFrame(IEnumerable<Record> pdf)//...
        {
            foreach (Record obs in pdf)
            {
                Console.WriteLine(obs.Name + ", " + obs.Surname + ", " + obs.Gender + ", " + 
                    obs.Age);
            }
        }

        static Tuple<string, double> Mode(IEnumerable<Record> pdf)
        {
            double dif = 0;
            double length = 0;
            foreach(Record obs in pdf)
            {
                length++;
                if (obs.Gender == "M")
                    dif++;
                else dif--;
            }
            if (dif > 0)
                return new Tuple<string, double>("M", (length + dif) / (2 * length));
            else
                return new Tuple<string, double>("F", (length - dif) / (2 * length));
        }



        static List<Record> ConcatenationWithCondition(IEnumerable<Record> ldf, IEnumerable<Record> fdf, Func<Record, bool> f)
        {
            List<Record> results = new List<Record>();
            foreach (Record obs in ldf)
            {
                if (f(obs))
                    results.Add(obs);
            }
            foreach (Record obs in fdf)
            {
                if (f(obs))
                    results.Add(obs);
            }
            return results;

        }

        static void Main(string[] args)
        {
            List < Record > people = new List<Record>()
            {
                new Record("Keanu", "Reeves", "M", 25),
                new Record("Agent", "Smith", "M", 35),
                new Record("Carrie-Anne", "Moss", "F", 25),
                new Record("Gloria", "Foster", "M", 123),
                new Record("Belinda", "McClory", "F", 27)
            };
            ListDataFrame ldf = new ListDataFrame(people);
            PrintDataFrame(ldf);

            Tuple<string, double> res = Mode(ldf);
            Console.WriteLine($"mode = {res.Item1}, percent = {res.Item2}");

            FileDataFrame fdf = new FileDataFrame("dataFrame1.txt");
            PrintDataFrame(fdf);
            Tuple<string, double> res2 = Mode(fdf);
            Console.WriteLine($"mode = {res2.Item1}, percent = {res2.Item2}");
            Console.WriteLine("\nConcatenation\n");
            Func<Record, bool> f = r => r.Gender == "F";
            PrintDataFrame(new ListDataFrame(ConcatenationWithCondition(ldf, fdf, f)));
            FileDataFrame fdf2 = new FileDataFrame(ConcatenationWithCondition(ldf, fdf, f), "dataFrame2.txt");
            Console.ReadKey();
        }
    }
}
