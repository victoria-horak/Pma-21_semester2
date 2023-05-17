using System;

class JacobiSolver
{
    static double[] SolveJacobi(double[,] coefficients, double[] constants, double[] initialGuess, double tolerance, int maxIterations)
    {
        int n = coefficients.GetLength(0);
        double[] currentSolution = new double[n];
        double[] nextSolution = new double[n];

        // Perform iterations until convergence or maximum iterations reached
        for (int iteration = 0; iteration < maxIterations; iteration++)
        {
            // Perform one iteration
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        sum += coefficients[i, j] * initialGuess[j];
                    }
                }
                nextSolution[i] = (constants[i] - sum) / coefficients[i, i];
            }

            // Check convergence
            double maxDifference = 0;
            for (int i = 0; i < n; i++)
            {
                double difference = Math.Abs(nextSolution[i] - initialGuess[i]);
                if (difference > maxDifference)
                {
                    maxDifference = difference;
                }
            }

            if (maxDifference < tolerance)
            {
                return nextSolution;
            }

            // Update the current solution for the next iteration
            for (int i = 0; i < n; i++)
            {
                initialGuess[i] = nextSolution[i];
            }
        }

        throw new Exception("Jacobi method did not converge within the specified number of iterations.");
    }
    static void Main()
    {
        double[,] start_matrix =
        {
            { 8, 1, 1, -1 },
            { 1, 5, -1,-1 },
            { 1, -1, 5, 1 },
            {2, 1, -1, 10}
        };

        double[] constants = { 9, 4, 18, 41 };
        double[] initialGuess = { 9, 4, 18, 41 };
        double epsilon = 0.0001;
        int maxIterations = 100;

        double[] solution = SolveJacobi(start_matrix, constants, initialGuess, epsilon, maxIterations);

        Console.WriteLine("Solution:");
        for (int i = 0; i < solution.Length; i++)
        {
            Console.WriteLine($"x[{i}] = {solution[i]}");
        }
    }

    
}
