using System;
using Problems;

namespace Solvers
{
    class Ethernet : NetworkDevice
    {
        public Ethernet(string model, int dataLimit) : base(model, dataLimit)
        {
            DeviceType = "Ethernet";
        }

        public override int? Solve(CPUProblem problem)
        {
            Console.WriteLine($"Device {DeviceType} cannot solve {problem.Name}");
            return null;
        }

        public override int? Solve(GPUProblem problem)
        {
            Console.WriteLine($"Device {DeviceType} cannot solve {problem.Name}");
            return null;
        }

        public override int? Solve(NetworkProblem problem)
        {
            if (problem.DataToTransfer <= DataLimit())
            {
                Console.WriteLine($"Device {DeviceType} solve this, transferd {problem.DataToTransfer}");
                return problem.DataToTransfer;

            }
            else {
                Console.WriteLine($"Device {DeviceType} has transfered {DataLimit()} of {problem.Name}");
                problem.Subtract(DataLimit());
                return null;
            } 
        }
    }
}