import numpy as np


def jacoby(A, b, max_iter, eps):
    x0 = np.array([0 for i in range(len(b))])
    n, m = A.shape
    Diagonal = np.zeros((n, n))
    Rest = np.zeros((n, n))
    for i in range(n):
        for j in range(n):
            if i == j:
                Diagonal[i][j] = A[i][j]
            else:
                Rest[i][j] = A[i][j]
    Diagonal_inv = np.linalg.inv(Diagonal)
    T = -Diagonal_inv.dot(Rest)
    c = Diagonal_inv.dot(b)
    x = x0
    for i in range(max_iter):
        x_new = T.dot(x) + c
        if np.linalg.norm(x_new - x) < eps:
            break
        x = x_new
    return x


A = np.array([[4, 2, 2],
              [2, 3, 2],
              [-1, 1, 1]])
b = np.array([8, 7, 1])
max_iter = 1000
eps = float(input("Введіть eps: "))
print("Віповідь:")
print(jacoby(A, b, max_iter, eps))
