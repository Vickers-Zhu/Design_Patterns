using System;
using Problems;

namespace Solvers
{
    class GPU : ISolver
    {
        static private int MaxTemperature { get; } = 100;
        static private int CPUProblemTemperatureMultiplier { get; } = 3;

        private readonly string model;
        private int temperature;
        private int coolingFactor;

        public GPU(string model, int temperature, int coolingFactor)
        {
            this.model = model;
            this.temperature = temperature;
            this.coolingFactor = coolingFactor;
        }
        private bool DidThermalThrottle()
        {
            if (temperature > MaxTemperature)
            {
                Console.WriteLine($"GPU {model} thermal throttled");
                CoolDown();
                return true;
            }
            return false;
        }

        private void CoolDown()
        {
            temperature -= coolingFactor;
        }

        public int? Solve(CPUProblem problem)
        {
            if (temperature <= MaxTemperature)
            {
                temperature += problem.RequiredThreads * CPUProblemTemperatureMultiplier;
                Console.WriteLine($"GPU {model} solve {problem.Name}, temperature: {temperature}");
                return temperature;
            }
            else {
                DidThermalThrottle();
                return null;
            } 
        }

        public int? Solve(GPUProblem problem)
        {
            if (temperature <= MaxTemperature)
            {
                temperature += problem.GpuTemperatureIncrease;
                Console.WriteLine($"GPU {model} solve {problem.Name}, temperature: {temperature}");
                return temperature;
            }
            else {
                DidThermalThrottle();
                return null;
            } 
        }

        public int? Solve(NetworkProblem problem)
        {
            Console.WriteLine($"GPU {model} cannot solve {problem.Name}");
            return null;
        }
    }
}