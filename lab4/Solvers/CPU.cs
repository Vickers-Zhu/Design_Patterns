using System;
using Problems;

namespace Solvers
{
    class CPU : ISolver
    {
        private readonly string model;
        private readonly int threads;

        public CPU(string model, int threads)
        {
            this.model = model; 
            this.threads = threads;
        }

        public int? Solve(CPUProblem problem)
        {
            if (problem.RequiredThreads <= threads)
            {
                Console.WriteLine($"CPU {model} solve {problem.Name}");
                return problem.RequiredThreads;
            }
            else {
                Console.WriteLine($"CPU {model} is without enough threads to solve {problem.Name}");
                return null;
            } 
        }

        public int? Solve(GPUProblem problem)
        {
            Console.WriteLine($"CPU {model} cannot solve {problem.Name}");
            return null;
        }

        public int? Solve(NetworkProblem problem)
        {
            Console.WriteLine($"CPU {model} cannot solve {problem.Name}");
            return null;
        }
    }
}