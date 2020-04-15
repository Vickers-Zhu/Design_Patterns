using System;
using Problems;

namespace Solvers
{
    abstract class NetworkDevice : ISolver
    {
        protected string DeviceType { get; set; } = "NetworkDevice";

        protected readonly string model;
        private int dataLimit;

        protected NetworkDevice(string model, int dataLimit)
        {
            this.model = model;
            this.dataLimit = dataLimit;
        }

        public int DataLimit() { return dataLimit; }

        abstract public int? Solve(CPUProblem problem);

        abstract public int? Solve(GPUProblem problem);

        abstract public int? Solve(NetworkProblem problem);
    }
}