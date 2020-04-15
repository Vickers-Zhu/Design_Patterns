using System;
using Problems;

namespace Solvers
{
    class WiFi : NetworkDevice
    {
        private readonly double packetLossChance;
        private static readonly Random rng = new Random(1597);

        public WiFi(string model, int dataLimit, double packetLossChance) : base(model, dataLimit)
        {
            DeviceType = "WiFi";
            this.packetLossChance = packetLossChance;
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
                if (rng.NextDouble() < packetLossChance)
                {
                    Console.WriteLine($"Device {DeviceType} lost packet");
                    return null;
                }
                else
                {
                    Console.WriteLine($"Device {DeviceType} solve {problem.Name}, transferd {problem.DataToTransfer}");
                    return problem.DataToTransfer;
                }
            }
            else {
                if (rng.NextDouble() < packetLossChance)
                {
                    Console.WriteLine($"Device {DeviceType} lost packet");
                    return null;
                }
                else
                {
                    Console.WriteLine($"Device {DeviceType} has transfered {DataLimit()} of {problem.Name}");
                    problem.Subtract(DataLimit());
                    return null;
                }
            }
        }
    }
}