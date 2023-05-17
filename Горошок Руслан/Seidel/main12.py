def gauss_seidel(A, b, x0, tol, max_iter):
    n = len(A)
    if len(A) != len(b) or len(A[0]) != len(x0):
        raise ValueError("Incompatible dimensions between matrix A, vector b, and initial guess x0.")

    x = x0.copy()
    for iteration in range(max_iter):
        x_new = x.copy()
        for i in range(n):
            s1 = sum(A[i][j] * x_new[j] for j in range(i))
            s2 = sum(A[i][j] * x[j] for j in range(i + 1, n))
            x_new[i] = (b[i] - s1 - s2) / A[i][i]
        if all(abs(x_new[i] - x[i]) < tol for i in range(n)):
            return x_new
        x = x_new
        rounded_x = [round(value, 3) for value in x]
        print(f"Iteration {iteration + 1}: {rounded_x}")
    raise ValueError("Gauss-Seidel method did not converge within the maximum number of iterations.")


# Example usage:
A = [[4, 1, 2], [3, 5, 1], [1, 1, 3]]
b = [4, 7, 3]
x0 = [0, 0, 0]

tolerance = 1e-3
max_iterations = 100

solution = gauss_seidel(A, b, x0, tol=tolerance, max_iter=max_iterations)
rounded_solution = [round(value, 3) for value in solution]
print("Solution:", rounded_solution)

