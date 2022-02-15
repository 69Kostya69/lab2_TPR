using System;
using System.IO;
using System.Linq;

namespace lab2_TPR
{
    class Program
    {
        private static void Domination()
        {
            string[] mass = File.ReadAllLines("D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\MATRIX.txt");
            int[,] matrix = new int[mass.Length,mass.Length];
            ReadMatrix(ref matrix);

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

        private static void Locking()
        {
            string[] mass = File.ReadAllLines("D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\MATRIX.txt");
            int[,] matrix = new int[mass.Length, mass.Length];
            ReadMatrix(ref matrix);

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

        private static void Neumann()
        {
            string[] mass = File.ReadAllLines("D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\MATRIX.txt");
            int[,] matrix = new int[mass.Length, mass.Length];
            ReadMatrix(ref matrix);

            WriteMatrix(matrix);

            Graph graph= new Graph();
            graph.CteateFromMatrix(matrix);

            

        }

        private static void K()
        {
            string[] mass = File.ReadAllLines("D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\MATRIX.txt");
            int[,] matrix = new int[mass.Length, mass.Length];
            ReadMatrix(ref matrix);

            WriteMatrix(matrix);

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
            while (true)
            {
                Console.WriteLine("Identify plural of the best alternatives using the principle:\n" +
                                "1) Domination;\n" +
                                "2) Locking;\n" +
                                "3) Neumann-Morgenstern;\n" +
                                "4) K- optimization;\n" +
                                "5) Exit\n" +
                                "Your choose: ");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Domination();
                        break;
                    case 2:
                        Locking();
                        break;
                    case 3:
                        Neumann();
                        break;
                    case 4:
                        K();
                        break;
                    case 5:
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
