using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab2_TPR
{
    class Program
    {
        private static void Domination(int[,] matrix)
        {
            
            WriteMatrix(matrix);

            Matrix matr = new Matrix(matrix);
            if(matr.IsASymetric())
            {
                Console.WriteLine("Asymmetric");
                Console.WriteLine(matr.FindXp());
            }

            else
            {
                Console.WriteLine("No asymmetric");
                Console.WriteLine(matr.FindXr());
            }
            Console.WriteLine("====================================================================");

        }

        private static void Locking(int[,] matrix)
        {         
            WriteMatrix(matrix);

            Matrix matr = new Matrix(matrix);
            if (matr.IsASymetric())
            {
                Console.WriteLine("Asymmetric");
                Console.WriteLine(matr.FindXpMax());
            }

            else
            {
                Console.WriteLine("No asymmetric");
                Console.WriteLine(matr.FindXrMax());
                Console.WriteLine(matr.FindStrictlyXrMax());
            }
            Console.WriteLine("====================================================================");

        }

        private static bool IsCyclic(int[,] matrix)
        {            
            Matrix matr = new Matrix(matrix);
            if (matr.IsASymetric())
            {
                return false;
            }
            else return true;                     
        }

        private static void Сhoose_Alghoritm(int[,] matrix)
        {
            WriteMatrix(matrix);

            if (IsCyclic(matrix))
            {
                Console.WriteLine("The matrix is cyclic, therefore we will find set of optimum alternatives by the principle of K-optimization\n");
                K_Optimize(matrix);
            }
            else
            {
                Console.WriteLine("The matrix is acyclic, therefore we will find the Neumann-Morgenstern set\n");
                Neumann(matrix);
            }
        }
        private static void Neumann(int[,] matrix)
        {
            List<int> S0 = new List<int>();
            List<int> S = new List<int>();
            List<int> Q0 = new List<int>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var section = Upper_section(matrix, i);

                if(section.Where(x=>x==1).Count()==0)
                {
                    S0.Add(i);
                }

                section.Clear();
            }

            Q0 = S0;
            
            int[,] res = new int[15,15];
            int p = 0, l = 0, g=0;

            Console.Write("S0=");
            foreach (int s in S0)
            {
                int a = s;
                Console.Write(++a + " ");
                res[p, l] = s;
                res[p, l] = res[p, l] + 1;
                l++;
            }
            Console.WriteLine();
            l = 0;

            while (S0.Count != matrix.GetLength(0))
            {
                p++;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    var section = Upper_section_index(matrix, i);
                    if(S0.Intersect(section).Count()==section.Count() && !S0.Contains(i))
                    {
                        S.Add(i);
                    }
                }

                S0.AddRange(S);
               
                Console.Write($"S{p}\\S{p-1}=");

                foreach (int s in S)
                {
                    int a = s;
                    Console.Write(++a + " ");
                    res[p, l] = s;
                    res[p, l] = res[p, l] + 1;
                    l++;
                }

                Console.WriteLine();
                l = 0;
                S.Clear();
            }
            Console.WriteLine();

            List<int> Q = new List<int>();

            
        }

        private static List<int> Upper_section(int[,] matrix, int column)
        {
            List<int> upperSection = new List<int>();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                upperSection.Add(matrix[i, column]);
            }
            return upperSection;
        }

        private static List<int> Upper_section_index(int[,] matrix, int column)
        {
            List<int> upperSection = new List<int>();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if(matrix[i, column]==1)
                upperSection.Add(i);
            }
            return upperSection;
        }

        private static void K_Optimize(int[,] matrix)
        {
            


        }

        public static void ReadMatrix(ref int[,] matrix)
        {

            string[] mass = File.ReadAllLines("D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\MATRIX.txt");
            for (int p = 0; p < mass.Length; p++)
            {
                int[] m = mass[p].Split(new char[] { ' ' },
              StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
                for (int i = 0; i < m.Length; i++)
                {
                    matrix[p, i] = m[i];
                }
            }
        }
        public static void WriteMatrix(int[,] matrix)
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine("Matrix:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine("  ");
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            string[] mass = File.ReadAllLines("D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\MATRIX.txt");
            int[,] matrix = new int[mass.Length, mass.Length];
            ReadMatrix(ref matrix);

            while (true)
            {
                Console.WriteLine("Identify plural of the best alternatives using the principle:\n" +
                                "1) Domination;\n" +
                                "2) Locking;\n" +
                                "3) Сyclicity check;\n" +
                                "4) Exit\n" +
                                "Your choose: ");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Domination(matrix);
                        break;
                    case 2:
                        Locking(matrix);
                        break;
                    case 3:
                        Сhoose_Alghoritm(matrix);
                        break;
                    case 4:
                        Console.WriteLine("Bye");
                        return;
                    default:
                        Console.WriteLine("Error input! Try again");
                        break;
                }
            }
        }
    }
}
