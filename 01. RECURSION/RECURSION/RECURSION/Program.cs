﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RECURSION
{
    class Program
    {
        public const int Size = 8;
        public static int[,] board = new int[Size, Size];
        public static char[,] lab;

        public static HashSet<int> attackedRows = new HashSet<int>();
        public static HashSet<int> attackedColumns = new HashSet<int>();
        public static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        public static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public static List<char> path = new List<char>();


        static void Main(string[] args)
        {
            ReadLab();
            SolveLabyrint(0, 0, 'S');
        }

        public static void Solve8Queens(int row)
        {
            if (row >= Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkedAttackedFields(row, col);
                        Solve8Queens(row + 1);
                        UnMarkedAttackedFields(row, col);
                    }
                }
            }

        }

        private static void UnMarkedAttackedFields(int row, int col)
        {
            attackedRows.Remove(row);
            attackedColumns.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);
            board[row, col] = 0;
        }

        private static void MarkedAttackedFields(int row, int col)
        {
            attackedRows.Add(row);
            attackedColumns.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(col + row);
            board[row, col] = 1;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            if (attackedRows.Contains(row))
            {
                return false;
            }

            if (attackedColumns.Contains(col))
            {
                return false;
            }

            if (attackedLeftDiagonals.Contains(col-row))
            {
                return false;
            }

            if (attackedRightDiagonals.Contains(col+row))
            {
                return false;
            }

            ////leftUp
            //for (int i = 1; i < Size; i++)
            //{
            //    int currentRow = row - i;
            //    int currentCol = col - i;

            //    if (currentRow < 0 || currentRow >= Size || currentCol < 0 || currentCol >=Size)
            //    {
            //        break;
            //    }

            //    if (board[currentRow, currentCol] == 1)
            //    {
            //        return false;
            //    }
            //}

            ////RighttUp
            //for (int i = 1; i < Size; i++)
            //{
            //    int currentRow = row - i;
            //    int currentCol = col + i;

            //    if (currentRow < 0 || currentRow >= Size || currentCol < 0 || currentCol >= Size)
            //    {
            //        break;
            //    }

            //    if (board[currentRow, currentCol] == 1)
            //    {
            //        return false;
            //    }
            //}

            ////RighttDown
            //for (int i = 1; i < Size; i++)
            //{
            //    int currentRow = row + i;
            //    int currentCol = col + i;

            //    if (currentRow < 0 || currentRow >= Size || currentCol < 0 || currentCol >= Size)
            //    {
            //        break;
            //    }

            //    if (board[currentRow, currentCol] == 1)
            //    {
            //        return false;
            //    }
            //}

            ////RighttLeft
            //for (int i = 1; i < Size; i++)
            //{
            //    int currentRow = row + i;
            //    int currentCol = col - i;

            //    if (currentRow < 0 || currentRow >= Size || currentCol < 0 || currentCol >= Size)
            //    {
            //        break;
            //    }

            //    if (board[currentRow, currentCol] == 1)
            //    {
            //        return false;
            //    }
            //}

            return true;
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 1)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void Draw(int n)
        {
            if (n < 1)
            {
                return;
            }

            Console.WriteLine(new String('*', n));

            Draw(n - 1);

            Console.WriteLine(new String('#', n));

        }

        private static int Sum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            int currentSum = arr[index] + Sum(arr, index + 1);

            return currentSum;
        }

        private static long Factoriel(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            long currentNum = n * Factoriel(n - 1);

            return currentNum;
        }

        private static void GeneratingVector(int index, int[] vector)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    GeneratingVector(index + 1, vector);
                }
            }
        }

        private static void GenComb(int[] set, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenComb(set, vector, index + 1, i + 1);
                }
            }
        }

        private static void ReadLab()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            lab = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string currentLine = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    lab[row, col] = currentLine[col];
                }
            }
        }

        public static void SolveLabyrint(int row, int col, char direction)
        {
            if (OutSideOfLabyrint(row, col))
            {
                return;
            }

            path.Add(direction);
            if (IsExit(row, col))
            {
                PrintLabyrint();
            }
            else if (IsPassable(row, col))
            {
                lab[row, col] = 'x';
                SolveLabyrint(row + 1, col, 'D'); //Down
                SolveLabyrint(row - 1, col, 'U'); //Up
                SolveLabyrint(row, col + 1, 'R'); //Right
                SolveLabyrint(row, col - 1, 'L'); //left
                lab[row, col] = '-';
            }

            path.RemoveAt(path.Count - 1);
        }

        private static bool IsPassable(int row, int col)
        {
            //alrady visited
            if (lab[row, col] == 'x') return false;

            //wall
            if (lab[row, col] == '*') return false;

            return true;
        }

        private static bool IsExit(int row, int col)
        {
            return lab[row, col] == 'e';
        }

        private static void PrintLabyrint()
        {
            Console.WriteLine(string.Join(string.Empty, path.Skip(1)));
        }

        private static bool OutSideOfLabyrint(int row, int col)
        {
            if (row < 0 || row >= lab.GetLength(0) || col < 0 || col >= lab.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
