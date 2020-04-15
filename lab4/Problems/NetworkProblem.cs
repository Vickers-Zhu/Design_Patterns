using System;
using Solvers;

namespace Problems
{
    class NetworkProblem : Problem
    {
        public int DataToTransfer { get; set; }

        public NetworkProblem(string name, Func<int> computation, int dataToTransfer) : base(name, computation)
        {
            DataToTransfer = dataToTransfer;
        }

        public void Subtract(int data)
        {
            DataToTransfer -= data;
            Console.WriteLine($"{Name} date left to transfer: {DataToTransfer}");
        }

        public override void Accept(ISolver solver)
        {
            if (solver.Solve(this).HasValue)
            {
                TryMarkAsSolved(Computation());
            }
        }
    }
}