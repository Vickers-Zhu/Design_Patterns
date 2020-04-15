using Problems;

namespace Solvers
{
    interface ISolver
    {
        int? Solve(CPUProblem problem);
        int? Solve(GPUProblem problem);
        int? Solve(NetworkProblem problem);
    }
}