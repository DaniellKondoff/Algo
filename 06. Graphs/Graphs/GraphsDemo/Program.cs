using System;
using System.Collections.Generic;

namespace GraphsDemo
{
    class Program
    {
        static bool[] visited;
        static List<int>[] graph;

        static void Main(string[] args)
        {
            graph = new List<int>[]
            {
                new List<int> {3, 6},           //0
                new List<int> {2, 3, 4, 5, 6},  //1
                new List<int> {1, 4, 5},        //2
                new List<int> {0, 1, 5 },       //3
                new List<int> {1, 2, 6},        //4
                new List<int> {1, 2, 3},        //5
                new List<int> {0, 1 ,4},        //6
                new List<int> { 8 },            //7
                new List<int> { 7 }             //8
            };

            visited = new bool[graph.Length];
            int countOfComponents = 0;

            for (int i = 0; i < graph.Length; i++)
            {
                if (!visited[i])
                {
                    countOfComponents++;
                    Console.Write($"Connected components {countOfComponents}: ");
                    DFS(i);
                    Console.WriteLine();
                }         
                //BFS(i);
            }
        }

        static void DFS(int n)
        {
            if (!visited[n])
            {
                visited[n] = true;

                foreach (var child in graph[n])
                {
                    DFS(child);
                }

                Console.Write($"{n} ");
            }
        }

        static void BFS(int n)
        {
            if (visited[n])
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(n);
            visited[n] = true;

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                Console.Write($"{currentNode} ");

                foreach (var child in graph[currentNode])
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
