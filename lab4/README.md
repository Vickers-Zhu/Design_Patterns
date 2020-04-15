# OOD_4_visitor
Solving IT problems

##############################
Problems

We are given an abstract class Problem - the base of all problems in the system. Each problem has
the following:

- Name;
- Solved - information whether the problem has already been solved;
- Result;
- Computation - calculates the result of the problem.

There are 3 types of problems, each requiring different resources:

- CPUProblem - can be solved using a CPU. Requires a given number of threads.
- GPUProblem - can be solved using a GPU. Solving the problem causes the GPU temperature to rise by
  a given amount.
- NetworkProblem - can be solved using a network connection. Solving the problem requires a given
  amount of data to be transferred.
  
We also define an additional type of problem - CompositeProblem, which is composed of subproblems.
Attempting to solve a CompositeProblem using an ISolver means attempting to solve all of remaining
unsolved subproblems using the given ISolver. When all of the subproblems become solved, their
results should be combined using resultCombiner and the combined result should be saved as the
CompositeProblem's result.

##############################	
Solvers

We need to model components which can solve the types of problems specified above.

There are 3 types of solvers:

- CPU - can solve problems of type CPUProblem. A CPU has a specified number of threads and can only
  solve problems for which it has enough threads.
- GPU - can solve problems of type GPUProblem. A GPU tracks its temperature and can only solve
  a problem if the temperature at the start of the computation is not greater than MaxTemperature.
  If the temperature is greate than MaxTemperature, the problem is not solved and the temperature
  decreases by coolingFactor.
  A GPU can also solve problems of type CPUProblem. In this case, the temperature increases by
  the number of required cores * CPUProblemTemperatureMultiplier.
- NetworkDevice - an abstract component which can solve problems of type NetworkProblem. It can
  only solve the problem if it has enough remaining transfer left. There are two types of
  NetworkDevice:
    - Ethernet - always solves a problem if there's enough transfer left.
	- WiFi - when solving a problem, it has a chance of disconnecting, which causes the solving
	  process to fail.
	  Disconnecting can be simulated with: if (rng.NextDouble() < packetLossChance) { ... }

##############################
Main

The Main methods creates problems and solvers. It then attempts to solve each problem using each of
the solvers.

##############################
Task

1. Add code responsible for problem solving (CPUProblem, GPUProblem, NetworkProblem) according to
   the rules described above.
   You program should output (Console.WriteLine) information whenever a solver attempts to solve
   a problem. The output should include the solver's model and information whether the problem was
   solved.
2. Complete TrySolveProblem in Program.cs.
3. Add code for solving CompositeProblem according to the rules described above.

Your solution should allow for easy creation of new solvers (ISolver). It should be possible to add
a new solver without modifying existing classes. Adding a new type of problem may require modifying
existing classes.

Make sure to get acquainted with the provided code and take advantage of already implemented fields
and methods.

##############################
You are allowed to:

- Add new fields and methods to existing classes/interfaces;
- Add new classes (although it is not required to solve the task).

##############################
You are NOT allowed to:

- Change access modifiers (public, protected, private) of existing fields/properties/methods;
- Use explicit type checking with if, switch etc.
