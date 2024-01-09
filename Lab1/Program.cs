using System;
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
            TestDSCanh();
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
            string filePath = @"D:\22DH110310__ThaiGiaBao\txt\DSke.txt";
            int n;
            List<Tuple<int, int>> adjMatrix;
            ReadAdjMatrixTuple(filePath, out n, out adjMatrix);
            DanhSachCanh(adjMatrix);
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
            adjList = new List<int>[n];
            for (int u = 0; u < n; u++)
            {
                string line = sr.ReadLine();
                string[] nums = line.Split();
                adjList[u] = new List<int>();
                for (int v = 0; v < nums.Length; v++)
                {
                    adjList[u].Add(int.Parse(nums[v]));
                }
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
                Console.WriteLine($"{count}");
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
