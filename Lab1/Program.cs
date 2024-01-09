﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lab1
{
    class Program
    {
            static void Main(string[] args)
            {
                //string filePath = @"D:\22DH110310__ThaiGiaBao\txt\matran.txt";
                //int n;
                //int[,] adjMatrix;
                //ReadAdjMatrix(filePath,out n,out adjMatrix);
                //OutPut(adjMatrix);
                //BacCuaDinh(adjMatrix);
                //TestVaoRa();
                //TestDanhSachKe();
                //TestVaoRa();
                //TestDanhSachKe();
                //TestDSCanh();
                //TestCanh2Ke();
                TestDanhSachKe2Canh();
                Console.ReadKey();
            }


        static void TestVaoRa()
        {
            string filePath = @"D:\22DH110310__ThaiGiaBao\txt\BacVaoRa.txt";
            int n;
            int[,] adjMatrix;
            ReadAdjMatrix(filePath, out n, out adjMatrix);
            TinhBacVaoRa(adjMatrix);

        }

        static void TestDanhSachKe()
        {
            string filePath = @"D:\22DH110310__ThaiGiaBao\txt\DSKe.txt";
            int n;
            List<int>[] adjList;
            ReadAdjMatrixMultiple(filePath, out n, out adjList);
            DanhSachKe(adjList);
        }

        static void TestDSCanh()
        {
            string filePath = @"D:\22DH110310__ThaiGiaBao\txt\DSCanh.txt";
            int n;
            List<Tuple<int, int>> adjMatrix;
            ReadAdjMatrixTuple(filePath, out n, out adjMatrix);
            DanhSachCanh(adjMatrix);
        }

        static void TestCanh2Ke()
        {
            string filePath = @"D:\22DH110310__ThaiGiaBao\txt\Canh2Ke.txt";
            int n;
            int m;
            List<Tuple<int, int>> edgeList;
            ReadEdgeList(filePath, out n, out m, out edgeList);
            List<int>[] adjList = new List<int>[m];
            adjList = ConvertEdgeList2AdjList(n,m,edgeList,adjList);
            for (int i = 0; i < adjList.Length; i++)
            {
                var result = string.Join(" ", adjList[i]);
                Console.WriteLine(result);
            }

        }

        static void TestDanhSachKe2Canh()
        {
            string filePath = @"D:\22DH110310__ThaiGiaBao\txt\DSKe2Canh.txt";
            int n;
            int m;
            List<int>[] adjList;
            ReadAdjMatrixMultiple(filePath, out n, out adjList);
            List<Tuple<int, int>> edgeList;
            ConvertAdjList2EdgeList(n, out m, out edgeList, adjList);
           


        }

        static void ReadAdjMatrix(string filePath, out int n, out int[,] adjMatrix)
        {
            StreamReader sr = new StreamReader(filePath);
            n = Convert.ToInt32(sr.ReadLine());
            adjMatrix = new int[n, n];
            for (int u = 0; u < n; u++)
            {
                string line = sr.ReadLine();
                string[] nums = line.Split();
                for (int v = 0; v < n; v++)
                {
                    adjMatrix[u, v] = int.Parse(nums[v]);
                }
            }
        }

        static void ReadAdjMatrixMultiple(string filePath, out int n, out List<int>[] adjList)
        {
            StreamReader sr = new StreamReader(filePath);
            n = Convert.ToInt32(sr.ReadLine());
            adjList = new List<int>[n+1];
            for (int u = 1; u <= n; u++)
            {
                string line = sr.ReadLine();
                string[] nums = line.Split();
                adjList[u] = Array.ConvertAll(nums, s => int.Parse(s)).ToList();
            }
        }

        static void ReadAdjMatrixTuple(string filePath, out int n, out List<Tuple<int, int>> adjTuple)
        {
            StreamReader sr = new StreamReader(filePath);
            n = Convert.ToInt32(sr.ReadLine());
            adjTuple = new List<Tuple<int, int>>();
            for (int u = 0; u < n + 1; u++)
            {
                string line = sr.ReadLine();
                string[] nums = line.Split();
                adjTuple.Add(new Tuple<int, int>(int.Parse(nums[0]), int.Parse(nums[1])));
            }
        }

        static void ReadEdgeList(string path, out int n, out int m, out List<Tuple<int, int>> edgeList)
        {
            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();
            string[] values = line.Split();
            n = Convert.ToInt32(values[0]);
            m = Convert.ToInt32(values[1]);
            edgeList = new List<Tuple<int, int>>();

            for (int i = 0; i < m; i++)
            {
                line = sr.ReadLine();
                values = line.Split();
                int u = Convert.ToInt32(values[0]);
                int v = Convert.ToInt32(values[1]);
                Tuple<int, int> e = new Tuple<int, int>(u, v);
                edgeList.Add(e);
            }
            sr.Close();
        }

        static void BacCuaDinh(int[,] adjMatrix)
        {
            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < adjMatrix.GetLength(0); j++)
                {
                    sum += adjMatrix[i, j];
                }
                Console.Write(sum + " ");
            }
        }

        static void TinhBacVaoRa(int[,] adjMatrix)
        {
            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                int vao = 0;
                int ra = 0;
                for (int j = 0; j < adjMatrix.GetLength(0); j++)
                {
                    vao += adjMatrix[j, i];
                    ra += adjMatrix[i, j];
                }
                Console.Write($"{vao} {ra}");
                Console.WriteLine();
            }
        }

        static void DanhSachKe(List<int>[] adjList)
        {

            for (int i = 0; i < adjList.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < adjList[i].Count; j++)
                {
                    count++;
                }
                Console.Write(count + " ");
            }
        }

        static void DanhSachCanh(List<Tuple<int, int>> adjMatrix)
        {
            int[] count1 = new int[adjMatrix.Count];
            int[] count2 = new int[adjMatrix.Count];
            int[] result = new int[adjMatrix.Count];
            for (int i = 0; i < adjMatrix.Count; i++)
            {
                count1[adjMatrix[i].Item1]++;
                count2[adjMatrix[i].Item2]++;
            }
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = count1[i] + count2[i];
            }
            foreach (int count in result)
            {
                Console.Write(count + " ");
            }
        }

        static List<int>[] ConvertEdgeList2AdjList(int n, int m, List<Tuple<int, int>> edgeList, List<int>[] adjList)
        {
            adjList = new List<int>[m];
            for (int i = 0; i < adjList.Length; i++)
            {
                adjList[i] = new List<int>();
            }
            foreach(var e in edgeList)
            {
                adjList[e.Item1].Add(e.Item2);
                adjList[e.Item2].Add(e.Item1);
            }
            return adjList;
        }

        static void ConvertAdjList2EdgeList(int n, out int m, out List<Tuple<int, int>> edgeList, List<int>[] adjList)
        {
            m = n;
            edgeList = new List<Tuple<int, int>>();
            for (int i = 1; i <= m; i++)
            {
                for (int j = 0; j < adjList[i].Count; j++)
                {
                    Tuple<int,int> e = new Tuple<int, int>(i, adjList[i][j]);
                    if(i < adjList[i][j])
                    {
                        edgeList.Add(e);
                        Console.WriteLine(e);
                    }
                }
            }
        }

        static void OutPut(int[,] adjMatrix)
        {
            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjMatrix.GetLength(0); j++)
                {
                    Console.Write(adjMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
