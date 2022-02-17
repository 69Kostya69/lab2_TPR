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
         
            List<int> R = new List<int>();
            List<int> help = new List<int>();
            List<int> help1 = new List<int>();
            List<int> R1 = new List<int>();
            List<int> R2 = new List<int>();
            List<int> End = new List<int>();
            for (int i=0; i<matrix.GetLength(0); i++)
            {
                R.AddRange(Lower_section_index(matrix, i));
                R1.AddRange(R);
                End.AddRange(R);

                while (R.Count != 0)
                {
                    foreach (int element in R)
                    {
                        R1.AddRange(Lower_section_index(matrix, element));
                    }
                    var temp = R1.Distinct();
                    help.Clear();
                    help.AddRange(temp);
                    R1.Clear();
                    R1.AddRange(help);
                    End = R1;

                    help1.AddRange(R);
                    R.Clear();
                    R2.AddRange(help1.Except(R2));
                    R.AddRange(R1.Except(R2));

                }

                if(help1.Contains(i))
                {
                    return true;
                }
                R.Clear();
                help.Clear();
                help1.Clear();
                R1.Clear();
                R2.Clear();
                End.Clear(); 

            }
            return false;
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
            Dictionary<int, List<int>> alternatives = new Dictionary<int, List<int>>();
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
            int p = 0, g=0;

            Console.Write("S0=");
            foreach (int s in S0)
            {
                int a = s;
                Console.Write(++a + " ");               
            }
            alternatives.Add(0, new List<int>(S0));
            Console.WriteLine();

            var temp = new List<int>();

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
                    temp.Add(s);
                }
                alternatives.Add(p, new List<int>(temp));
                temp.Clear();

                Console.WriteLine();
                S.Clear();
            }
            Console.WriteLine();

            int plus = 0;

            List<int> Q = new List<int>();
            List<int> temp1 = new List<int>();
            List<int> temp2 = new List<int>();
            alternatives.TryGetValue(0, out Q);
            plus += Q.Count();

            while(plus<matrix.GetLength(0))
            {
                for(int z=1; z<alternatives.Count(); z++)
                {
                    alternatives.TryGetValue(z, out temp1);
                    foreach(int s in temp1)
                    {
                        if((Upper_section_index(matrix,s).Intersect(Q)).Count()==0)
                        {
                            temp2.Add(s);                            
                        }
                        plus++;
                    }
                    Q.AddRange(temp2);
                    temp2.Clear();
                    temp1.Clear();
                }
            }

            Console.Write("Xhm=");
            foreach (int s in Q)
            {
                int a = s;
                Console.Write(++a + " ");
            }

            Console.WriteLine("\n================================================================\n");
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

        private static List<int> Lower_section_index(int[,] matrix, int row)
        {
            List<int> lowerSection = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[row, i] == 1)
                    lowerSection.Add(i);
            }
            return lowerSection;
        }

        private static void K_Optimize(int[,] matrix)
        {
            int[,] reverseMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int[,] symetricPart = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int[,] asymetricPart = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int[,] nonComparabilityRatio = new int[matrix.GetLength(0), matrix.GetLength(1)];

            string[,] symetricPartA = new string[matrix.GetLength(0), matrix.GetLength(1)];
            string[,] asymetricPartA = new string[matrix.GetLength(0), matrix.GetLength(1)];
            string[,] nonComparabilityRatioA = new string[matrix.GetLength(0), matrix.GetLength(1)];
            string[,] stringMatrix = new string[matrix.GetLength(0), matrix.GetLength(1)];

            Matrix matr = new Matrix(matrix);
            reverseMatrix = matr.Reverse();
            symetricPart = matr.GetSymetricPart(reverseMatrix);
            asymetricPart = matr.GetAsymetricPart();
            nonComparabilityRatio = matr.GetNonComparabilityRatio();

            symetricPartA = WriteAlphaMatrix(symetricPart, "I");
            asymetricPartA = WriteAlphaMatrix(asymetricPart, "P");
            nonComparabilityRatioA = WriteAlphaMatrix(nonComparabilityRatio, "N");

            stringMatrix = СombineMatrix(symetricPartA, asymetricPartA, nonComparabilityRatioA);

            WriteMatrix(stringMatrix);

            int[,] k1Matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int[,] k2Matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int[,] k3Matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int[,] k4Matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            k1Matrix = kOpt(symetricPart, asymetricPart, nonComparabilityRatio, matrix.GetLength(0));
            k2Matrix = kOpt(null, asymetricPart, nonComparabilityRatio, matrix.GetLength(0));
            k3Matrix = kOpt(symetricPart, asymetricPart, null, matrix.GetLength(0));
            k4Matrix = kOpt(null, asymetricPart, null, matrix.GetLength(0));

            
            Console.WriteLine();
        }

        public static int[,] kOpt(int[,] sym, int[,]asym, int[,]nonComp, int size)
        {
            int[,] down = new int[sym.GetLength(0), sym.GetLength(1)];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //if (symetricPart[i, j] == 1)
                    //{
                    //    k1Matrix[i, j] = 1;
                    //}
                    //if (asymetricPart[i, j] == 1)
                    //{
                    //    k1Matrix[i, j] = 1;
                    //}
                    //if (nonComparabilityRatio[i, j] == 1)
                    //{
                    //    k1Matrix[i, j] = 1;
                    //}
                }
            }
            return new int[1,1];
        }
        public static string[,] СombineMatrix(string[,] symetricPart, string[,] asymetricPart, string[,] nonComparabilityRatio)
        {
            string[,] fullMatrix = new string[symetricPart.GetLength(0), symetricPart.GetLength(1)];
            for (int i = 0; i < symetricPart.GetLength(0); i++)
            {
                for (int j = 0; j < symetricPart.GetLength(1); j++)
                {
                    if(symetricPart[i,j] !="-")
                    {
                        fullMatrix[i, j] = "I";
                    }
                    else if (asymetricPart[i, j] != "-")
                    {
                        fullMatrix[i, j] = "P";
                    }
                    else if (nonComparabilityRatio[i, j] != "-")
                    {
                        fullMatrix[i, j] = "N";
                    }
                    else
                    {
                        fullMatrix[i, j] = "-";
                    }
                }
            }
            return fullMatrix;
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
        public static void WriteMatrix(string[,] matrix)
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
        public static string[,] WriteAlphaMatrix(int[,] matrix, string part)
        {
            string[,] stringMatrix = new string[matrix.GetLength(0), matrix.GetLength(1)];

            Console.WriteLine("====================================================================");
            
            if(part=="I")
            {
                Console.WriteLine("Symmetrical part:");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 1)
                        {
                            stringMatrix[i, j] = "I";
                            Console.Write("I" + " ");
                        }
                        else
                        {
                            stringMatrix[i, j] = "-";
                            Console.Write("-" + " ");
                        }
                    }
                    Console.WriteLine("  ");
                }
                Console.WriteLine("\n");
                return stringMatrix;
            }
            else if(part == "P")
            {
                Console.WriteLine("Asymmetrical part:");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 1)
                        {
                            stringMatrix[i, j] = "P";
                            Console.Write("P" + " ");
                        }
                        else
                        {
                            stringMatrix[i, j] = "-";
                            Console.Write("-" + " ");
                        }
                    }
                    Console.WriteLine("  ");
                }
                Console.WriteLine("\n");
                return stringMatrix;
            }

            else if(part == "N")
            {
                Console.WriteLine("Non comparability part:");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 1)
                        {
                            stringMatrix[i, j] = "N";
                            Console.Write("N" + " ");
                        }
                        else
                        {
                            stringMatrix[i, j] = "-";
                            Console.Write("-" + " ");
                        }
                    }
                    Console.WriteLine("  ");
                }
                Console.WriteLine("\n");
                return stringMatrix;
            }
            return stringMatrix;
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
