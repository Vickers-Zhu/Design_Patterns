using System;
using System.Collections.Generic;
using System.Linq;
using ResultsCombiners;
using Solvers;

namespace Problems
{
    class CompositeProblem : Problem
    {
        private readonly IEnumerable<Problem> problems;
        private readonly IResultsCombiner resultsCombiner;

        public CompositeProblem(string name, IEnumerable<Problem> problems,
            IResultsCombiner resultsCombiner) : base(name, () => 0)
        {
            this.problems = problems;
            this.resultsCombiner = resultsCombiner;
        }

        public override void Accept(ISolver solver)
        {
            IEnumerable<int> results = new List<int>();
            foreach(Problem problem in problems)
            {
                if (!problem.Solved)
                {
                    problem.Accept(solver);
                    if (problem.Result != null) results.Append((int)problem.Result);
                    if (problem.Solved)
                    {
                        Console.WriteLine($"Result of {problem.Name}: {problem.Result}");
                    }
                    else
                        Console.WriteLine($"{problem.Name} was not solved");
                    Console.WriteLine(string.Empty);
                }
            }
            bool solvedAll = true;
            foreach (Problem problem in problems)
            {
                if (problem.Solved == false)
                    solvedAll = false;
            }
            if(solvedAll)
                TryMarkAsSolved(resultsCombiner.CombineResults(results));
        }
    }
}