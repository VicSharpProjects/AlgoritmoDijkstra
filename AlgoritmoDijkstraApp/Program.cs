using System;

namespace AlgoritmoDijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,]{{0, 4, 0, 0, 0, 0, 0, 8, 0},
                                {4, 0, 8, 0, 0, 0, 0, 11, 0},
                                {0, 8, 0, 7, 0, 4, 0, 0, 2},
                                {0, 0, 7, 0, 9, 14, 0, 0, 0},
                                {0, 0, 0, 9, 0, 10, 0, 0, 0},
                                {0, 0, 4, 14, 10, 0, 2, 0, 0},
                                {0, 0, 0, 0, 0, 2, 0, 1, 6},
                                {8, 11, 0, 0, 0, 0, 1, 0, 7},
                                {0, 0, 2, 0, 0, 0, 6, 7, 0}
                                };
            int rows = graph.GetLength(0);
            Dijkstra(graph, 0, rows);
        }

        public static void Dijkstra(int[,] graph, int src, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[src] = 0;

            for (int count = 0; count < verticesCount - 1; count++)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);

                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; v++)
                {
                    if (!shortestPathTreeSet[v] && graph[u, v] != 0 &&
                            distance[u] != int.MaxValue &&
                            distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
                }
            }

            PrintSolution(distance, verticesCount);
        }
        public static void PrintSolution(int[] distance, int verticesCount)
        {
            Console.WriteLine("Vertex\t\tDistance from source");
            for (int i = 0; i < verticesCount; i++)
                Console.WriteLine("{0}\t\t  {1}", i, distance[i]);
            Console.ReadKey();
        }

        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
    }
}
