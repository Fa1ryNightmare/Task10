using System;

namespace Task10
{
    class Program
    {
        static void Main()
        {
            Console.Write("Кол-во строк первой матрицы: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Кол-во столбцов первой матрицы: ");
            int m = Convert.ToInt32(Console.ReadLine());

            Matrix matrix1 = new Matrix(n, m);
            FillMatrix(matrix1);

            Console.Write("Кол-во строк второй матрицы: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Кол-во столбцов второй матрицы: ");
            m = Convert.ToInt32(Console.ReadLine());

            Matrix matrix2 = new Matrix(n, m);
            FillMatrix(matrix2);

            Console.WriteLine("Первая матрица: ");
            PrintMatrix(matrix1);
            Console.WriteLine("Вторая матрица: ");
            PrintMatrix(matrix2);

            try
            {
                Console.WriteLine("Результат сложения матриц: ");
                PrintMatrix(Matrix.Add(matrix1, matrix2));
            }
            catch (MatrixException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Результат вычитания матриц: ");
                PrintMatrix(Matrix.Sub(matrix1, matrix2));
            }
            catch (MatrixException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Результат умножения матриц: ");
                PrintMatrix(Matrix.Mul(matrix1, matrix2));
            }
            catch (MulMatrixException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("Кол-во строк нулевой матрицы: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Кол-во столбцов нулевой матрицы: ");
            m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Нулевая матрица: ");
            PrintMatrix(Matrix.GetEmpty(n, m));

            Console.ReadKey();
        }
        
        static void PrintMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.RowsCount; i++)
            {
                for (int j = 0; j < matrix.ColumnsCount; j++)
                {
                    Console.Write($"{matrix.elements[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static void FillMatrix(Matrix matrix)
        {
            Console.WriteLine("Заполните матрицу: ");
            for (int i = 0; i < matrix.RowsCount; i++)
            {
                for (int j = 0; j < matrix.ColumnsCount; j++)
                {
                    Console.Write($"M[{i + 1},{j + 1}] = ");
                    matrix.elements[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            Console.Clear();
        }
    }
}
