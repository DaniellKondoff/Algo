using System;
using System.Collections.Generic;

namespace CombinatorialAlgo
{
    class Program
    {
        static string[] elements;
        static bool[] used;
        static string[] permutations;
        static string[] variats;
        static HashSet<string> set;
        static int k;
        static int n;

        static void Main(string[] args)
        {
            //elements = Console.ReadLine().Split();
            //used = new bool[elements.Length];

            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            //variats = new string[k];

            Console.WriteLine(Binom(n, k));
        }

        public static void PermutationWithoutRepetitions(int index)
        {
            if (index == permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        var currentElement = elements[i];
                        used[i] = true;
                        permutations[index] = currentElement;
                        PermutationWithoutRepetitions(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        public static void PermutationWithoutRepetitionsSwap(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                PermutationWithoutRepetitionsSwap(index + 1);

                for (int i = index + 1; i < elements.Length; i++)
                {
                    Swap(index, i);
                    PermutationWithoutRepetitionsSwap(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int firstIndex, int secondIndex)
        {
            var temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }

        public static void PermutationWittRepetitions(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                HashSet<string> swapped = new HashSet<string>();

                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        PermutationWittRepetitions(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }
        }

        public static void Variations(int index)
        {
            if (index >= variats.Length)
            {
                Console.WriteLine(string.Join(" ", variats));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        variats[index] = elements[i];
                        Variations(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        public static void VariationsWithRepetitions(int index)
        {
            if (index >= variats.Length)
            {
                Console.WriteLine(string.Join(" ", variats));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    variats[index] = elements[i];
                    VariationsWithRepetitions(index + 1);
                }
            }
        }

        public static void Combinate(int index, int start)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", variats));
            }
            else
            {
                for (int i = start; i < elements.Length; i++)
                {
                    variats[index] = elements[i];
                    Combinate(index + 1, i + 1);
                }
            }
        }

        public static decimal Binom(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            return Binom(n - 1, k - 1) + Binom(n - 1, k);
        }
    }
}
