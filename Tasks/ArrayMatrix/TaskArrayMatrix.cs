using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ArrayMatrix
{
    class ArrayOperations
    {
        // Matrix addition: requires same dimensions (rows and columns)
        public int[,] Add(int[,] a, int[,] b)
        {
            int aRows = a.GetLength(0);
            int aCols = a.GetLength(1);
            int bRows = b.GetLength(0);
            int bCols = b.GetLength(1);

            if (aRows != bRows || aCols != bCols)
                throw new InvalidOperationException("Addition requires both matrices to have the same dimensions.");

            var res = new int[aRows, aCols];
            for (int i = 0; i < aRows; i++)
                for (int j = 0; j < aCols; j++)
                    res[i, j] = a[i, j] + b[i, j];
            return res;
        }

        // Matrix subtraction: requires same dimensions
        public int[,] Subtract(int[,] a, int[,] b)
        {
            int aRows = a.GetLength(0);
            int aCols = a.GetLength(1);
            int bRows = b.GetLength(0);
            int bCols = b.GetLength(1);

            if (aRows != bRows || aCols != bCols)
                throw new InvalidOperationException("Subtraction requires both matrices to have the same dimensions.");

            var res = new int[aRows, aCols];
            for (int i = 0; i < aRows; i++)
                for (int j = 0; j < aCols; j++)
                    res[i, j] = a[i, j] - b[i, j];
            return res;
        }

        // Matrix multiplication: number of columns in A must equal number of rows in B
        public int[,] Multiply(int[,] a, int[,] b)
        {
            int aRows = a.GetLength(0);
            int aCols = a.GetLength(1);
            int bRows = b.GetLength(0);
            int bCols = b.GetLength(1);

            if (aCols != bRows)
                throw new InvalidOperationException("Multiplication requires columns in A to equal rows in B.");

            var res = new int[aRows, bCols];
            for (int i = 0; i < aRows; i++)
            {
                for (int j = 0; j < bCols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < aCols; k++)
                        sum += a[i, k] * b[k, j];
                    res[i, j] = sum;
                }
            }
            return res;
        }
    }

    internal class TaskArrayMatrix
    {
        static int[,] ReadMatrix(int rows, int columns, string name)
        {
            var m = new int[rows, columns];
            Console.WriteLine($"Enter elements for {name} (row by row):");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns ; j++)
                {
                    while (true)
                    {
                        Console.Write($"{name}[{i},{j}]: ");
                        string s = Console.ReadLine();
                        if (int.TryParse(s, out int v))
                        {
                            m[i, j] = v;
                            break;
                        }
                        Console.WriteLine("Invalid integer. Try again.");
                    }
                }
            }
            return m;
        }

        static void PrintMatrix(int[,] m)
        {
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(m[i, j].ToString().PadLeft(6));
                }
                Console.WriteLine();
            }
        }

        public static void Main()
        {
            Console.Write("Enter rows for Matrix A: ");
            int aRows = int.Parse(Console.ReadLine());
            Console.Write("Enter columns for Matrix A: ");
            int aCols = int.Parse(Console.ReadLine());

            Console.Write("Enter rows for Matrix B: ");
            int bRows = int.Parse(Console.ReadLine());
            Console.Write("Enter columns for Matrix B: ");
            int bCols = int.Parse(Console.ReadLine());

            var a = ReadMatrix(aRows, aCols, "Matrix A");
            var b = ReadMatrix(bRows, bCols, "Matrix B");

            Console.WriteLine();
            Console.WriteLine("Matrix A:");
            PrintMatrix(a);
            Console.WriteLine("Matrix B:");
            PrintMatrix(b);
            ArrayOperations Arr  = new ArrayOperations();
            try
            {
                var sum = Arr.Add(a, b);
                Console.WriteLine();
                Console.WriteLine("A + B:");
                PrintMatrix(sum);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Addition skipped: " + ex.Message);
            }
            try
            {
                var diff = Arr.Subtract(a, b);
                Console.WriteLine();
                Console.WriteLine("A - B:");
                PrintMatrix(diff);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Subtraction skipped: " + ex.Message);
            }

            try
            {
                var prod = Arr.Multiply(a, b);
                Console.WriteLine();
                Console.WriteLine("A * B:");
                PrintMatrix(prod);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Multiplication skipped: " + ex.Message);
            }
        }
    }
}
