using System;

namespace Task10
{
    class Matrix
    {
        public double[,] elements;
        public int RowsCount { get; private set; }
        public int ColumnsCount { get; private set; }

        public Matrix(int RowsCount, int ColumnsCount)
        {
            elements = new double[RowsCount, ColumnsCount];
            this.RowsCount = RowsCount;
            this.ColumnsCount = ColumnsCount;
        }

        public static Matrix GetEmpty(int RowsCount, int ColumnsCount)
        {
            return new Matrix(RowsCount, ColumnsCount);
        }

        public static Matrix Add(Matrix MatrixA, Matrix MatrixB)
        {
            if (MatrixA.RowsCount != MatrixB.RowsCount || MatrixA.ColumnsCount != MatrixB.ColumnsCount)
            {
                throw new MatrixException($"Ошибка\nРазмерность первой матрицы {MatrixA.RowsCount}x{MatrixA.ColumnsCount}, " +
                    $"Размерность второй матрицы {MatrixB.RowsCount}x{MatrixB.ColumnsCount}");
            }

            Matrix MatrixC = new Matrix(MatrixA.RowsCount, MatrixA.ColumnsCount);

            for (int i = 0; i < MatrixC.RowsCount; i++)
            {
                for (int j = 0; j < MatrixC.ColumnsCount; j++)
                {
                    MatrixC.elements[i, j] = MatrixA.elements[i, j] + MatrixB.elements[i, j];
                }
            }
            return MatrixC;
        }

        public static Matrix Sub(Matrix MatrixA, Matrix MatrixB)
        {
            if (MatrixA.RowsCount != MatrixB.RowsCount || MatrixA.ColumnsCount != MatrixB.ColumnsCount)
            {
                throw new MatrixException($"Ошибка\nРазмерность первой матрицы {MatrixA.RowsCount}x{MatrixA.ColumnsCount}, " +
                    $"Размерность второй матрицы {MatrixB.RowsCount}x{MatrixB.ColumnsCount}");
            }

            Matrix MatrixC = new Matrix(MatrixA.RowsCount, MatrixA.ColumnsCount);

            for (int i = 0; i < MatrixC.RowsCount; i++)
            {
                for (int j = 0; j < MatrixC.ColumnsCount; j++)
                {
                    MatrixC.elements[i, j] = MatrixA.elements[i, j] - MatrixB.elements[i, j];
                }
            }
            return MatrixC;
        }

        public static Matrix Mul(Matrix MatrixA, Matrix MatrixB)
        {
            if (MatrixA.ColumnsCount != MatrixB.RowsCount)
            {
                throw new MulMatrixException($"Ошибка\nРазмерность первой матрицы {MatrixA.RowsCount}x{MatrixA.ColumnsCount}, " +
                    $"Размерность второй матрицы {MatrixB.RowsCount}x{MatrixB.ColumnsCount}");
            }

            Matrix MatrixC = new Matrix(MatrixA.RowsCount, MatrixB.ColumnsCount);

            for (int i = 0; i < MatrixA.RowsCount; i++)
            {
                for (int j = 0; j < MatrixB.ColumnsCount; j++)
                {
                    for (int k = 0; k < MatrixA.ColumnsCount; k++)
                    {
                        MatrixC.elements[i, j] += MatrixA.elements[i, k] * MatrixB.elements[k, j];
                    }
                }
            }
            return MatrixC;
        }
    }

    class MatrixException : Exception
    {
        public MatrixException(string message) : base(message)
        {
        }
    }

    class MulMatrixException : Exception
    {
        public MulMatrixException(string message) : base(message)
        {
        }
    }
}
