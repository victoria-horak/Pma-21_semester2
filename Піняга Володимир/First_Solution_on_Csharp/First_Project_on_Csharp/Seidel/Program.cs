using System;


class GaussSeidelSolver
{
    static double[] SolveGaussSeidel(double[,] coefficients, double[] constants, double[] initialGuess, double tolerance, int maxIterations)
    {
        int n = coefficients.GetLength(0);
        double[] currentSolution = new double[n];
        double[] nextSolution = new double[n];

       
        for (int iteration = 0; iteration < maxIterations; iteration++)
        {
           
            for (int i = 0; i < n; i++)
            {
                double sum1 = 0;
                for (int j = 0; j < i; j++)
                {
                    sum1 += coefficients[i, j] * nextSolution[j];
                }

                double sum2 = 0;
                for (int j = i + 1; j < n; j++)
                {
                    sum2 += coefficients[i, j] * initialGuess[j];
                }

                nextSolution[i] = (constants[i] - sum1 - sum2) / coefficients[i, i];
            }

            
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

           
            for (int i = 0; i < n; i++)
            {
                initialGuess[i] = nextSolution[i];
            }
        }

        throw new Exception("Gauss-Seidel method did not converge within the specified number of iterations.");
    }
    static void Main()
    {
        // Coefficients of the system of equations
        double[,] coefficients = {
            { 8, 1, 1, -1 },
            { 1, 5, -1,-1 },
            { 1, -1, 5, 1 },
            {2, 1, -1, 10}
        };

        
        double[] constants = { 9, 4, 18, 41 };

        
        double[] initialGuess = { 9, 4, 18, 41 };

       
        double tolerance = 0.0001;

        
        int maxIterations = 100;

       
        double[] solution = SolveGaussSeidel(coefficients, constants, initialGuess, tolerance, maxIterations);

        
        Console.WriteLine("Solution:");
        for (int i = 0; i < solution.Length; i++)
        {
            Console.WriteLine($"x[{i}] = {solution[i]}");
        }
    }

    
}
