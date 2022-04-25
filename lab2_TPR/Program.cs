﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab2_TPR
{
    class Program
    {
        private static int[,] Pareto(int[,] criteria)
        {
            List<int> mas = new List<int>();
            int[,] matrix = new int[criteria.GetLength(0), criteria.GetLength(0)];
            WriteMatrix(criteria);           

            for (int m = 0; m < matrix.GetLength(0); m++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (m == j)
                        matrix[m, j] = 1;
                }
            }

            int p = 1;

            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = i+1; j < matrix.GetLength(1); j++)
                {
                    
                    for (int k = 0; k < criteria.GetLength(1); k++)
                    {
                        int number = criteria[i,k] - criteria[i+p,k];
                        if (number < 0)
                        {
                            number = -1;
                        }

                        else if (number == 0)
                        {
                            number = 0;
                        }

                        else
                            number = 1;

                        mas.Add(number);
                    }

                    p++;

                    if (mas.Any(x => x == -1))
                    {
                        matrix[i,j] = 0;
                    }

                    else
                    {
                        matrix[i,j] = 1;
                    }

                    List<int> tempMas = new List<int>();
                    foreach (var item in mas)
                    {
                        int temp = item * -1;
                        tempMas.Add(temp);
                    }

                    if (tempMas.Any(x => x == -1))
                    {
                        matrix[j, i] = 0;
                    }

                    else
                    {
                        matrix[j, i] = 1;
                    }

                    tempMas.Clear();
                    mas.Clear();

                }
                p = 1;
            }

            WriteMatrix(matrix);
            return matrix;
        }
        private static int[,] Padenovski(int[,] criteria)

        {
            WriteMatrix(criteria);

            List<int> mas = new List<int>();
            int[,] matrix = new int[criteria.GetLength(0), criteria.GetLength(0)];
            List<int> row = new List<int>();

            for (int i = 0; i < criteria.GetLength(0); i++)
            {
                for (int j = 0; j < criteria.GetLength(1); j++)
                {
                    row.Add(criteria[i, j]);
                }
                row.Sort();
                row.Reverse();

                int m = 0;
                foreach (var item in row)
                {
                    criteria[i, m] = item;
                    m++;
                }

                row.Clear();
            }

            for (int m = 0; m < matrix.GetLength(0); m++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (m == j)
                        matrix[m, j] = 1;
                }
            }

            int p = 1;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {

                    for (int k = 0; k < criteria.GetLength(1); k++)
                    {
                        int number = criteria[i, k] - criteria[i + p, k];
                        if (number < 0)
                        {
                            number = -1;
                        }

                        else if (number == 0)
                        {
                            number = 0;
                        }

                        else
                            number = 1;

                        mas.Add(number);
                    }

                    p++;

                    if (mas.Any(x => x == -1))
                    {
                        matrix[i, j] = 0;
                    }

                    else
                    {
                        matrix[i, j] = 1;
                    }

                    List<int> tempMas = new List<int>();
                    foreach (var item in mas)
                    {
                        int temp = item * -1;
                        tempMas.Add(temp);
                    }

                    if (tempMas.Any(x => x == -1))
                    {
                        matrix[j, i] = 0;
                    }

                    else
                    {
                        matrix[j, i] = 1;
                    }

                    tempMas.Clear();
                    mas.Clear();

                }
                p = 1;
            }

            WriteMatrix(matrix);
            return matrix;
        }
        private static int[,] Majority(int[,] criteria)
        {
            List<int> mas = new List<int>();
            int[,] matrix = new int[criteria.GetLength(0), criteria.GetLength(0)];
            WriteMatrix(criteria);

            for (int m = 0; m < matrix.GetLength(0); m++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (m == j)
                        matrix[m, j] = 0;
                }
            }

            int p = 1;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {

                    for (int k = 0; k < criteria.GetLength(1); k++)
                    {
                        int number = criteria[i, k] - criteria[i + p, k];
                        if (number < 0)
                        {
                            number = -1;
                        }

                        else if (number == 0)
                        {
                            number = 0;
                        }

                        else
                            number = 1;

                        mas.Add(number);
                    }

                    p++;

                    if (mas.Sum()<=0)
                    {
                        matrix[i, j] = 0;
                    }

                    else
                    {
                        matrix[i, j] = 1;
                    }

                    List<int> tempMas = new List<int>();
                    foreach (var item in mas)
                    {
                        int temp = item * -1;
                        tempMas.Add(temp);
                    }

                    if (tempMas.Sum()<=0)
                    {
                        matrix[j, i] = 0;
                    }

                    else
                    {
                        matrix[j, i] = 1;
                    }

                    tempMas.Clear();
                    mas.Clear();

                }
                p = 1;
            }

            WriteMatrix(matrix);
            return matrix;
        }
        private static int[,] Lexicographical(int[,] criteria, int[] importance)
        {
            List<int> mas = new List<int>();
            int[,] matrix = new int[criteria.GetLength(0), criteria.GetLength(0)];
            WriteMatrix(criteria);

            for (int m = 0; m < matrix.GetLength(0); m++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (m == j)
                        matrix[m, j] = 0;
                }
            }

            int p = 1;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {

                    for (int k = 0; k < criteria.GetLength(1); k++)
                    {
                        int number = criteria[i, k] - criteria[i + p, k];
                        if (number < 0)
                        {
                            number = -1;
                        }

                        else if (number == 0)
                        {
                            number = 0;
                        }

                        else
                            number = 1;

                        mas.Add(number);
                    }

                    p++;
                    int index = 0;

                    int[] massiv = new int[mas.Count];
                    int[] result = new int[mas.Count];
                    foreach (var item in mas)
                    {
                        massiv[index] = item;
                        index++;
                    }

                    for (int c = 0; c < massiv.Length; c++)
                    {                       
                        result[c] = massiv[importance[c]-1];
                    }

                    for (int q = 0; q < mas.Count; q++)
                    {
                        if (result[q]==0)
                        {
                            continue;
                        }

                        else if (result[q] == 0 && q==mas.Count-1)
                        {
                            matrix[i, j] = 0;
                            matrix[j, i] = 0;
                        }

                        else if(result[q]==1)
                        {
                            matrix[i, j] = 1;
                            matrix[j, i] = 0;
                            break;
                        }
                        else
                        {
                            matrix[i, j] = 0;
                            matrix[j, i] = 1;
                            break;
                        }
                    }
                    mas.Clear();
                }
                p = 1;
            }

            WriteMatrix(matrix);
            return matrix;
        }
        private static int[,] Berezovsky(int[,] criteria, int[] class1, int[] class2, int[] class3)
        {
            int[,] criteria1 = new int[criteria.GetLength(0), class1.Length];
            int[,] criteria2 = new int[criteria.GetLength(0), class2.Length];
            int[,] criteria3 = new int[criteria.GetLength(0), class3.Length];

            for (int i = 0; i < criteria.GetLength(0); i++)
            {
                for (int j = 0; j < class1.Length; j++)
                {
                    criteria1[i, j] = criteria[i, class1[j]-1];
                }
            }

            for (int i = 0; i < criteria.GetLength(0); i++)
            {
                for (int j = 0; j < class2.Length; j++)
                {
                    criteria2[i, j] = criteria[i, class2[j]-1];
                }
            }

            for (int i = 0; i < criteria.GetLength(0); i++)
            {
                for (int j = 0; j < class3.Length; j++)
                {
                    criteria3[i, j] = criteria[i, class3[j]-1];
                }
            }

            Console.WriteLine("First class:");
            int[,] res1 = Pareto(criteria1);
            Console.WriteLine("Second class:");
            int[,] res2 = Pareto(criteria2);
            Console.WriteLine("Third class:");
            int[,] res3 = Pareto(criteria3);

            int[,] reverseMatrix1 = new int[res1.GetLength(0),res1.GetLength(1)];
            int[,] symetricPart1 = new int[res1.GetLength(0), res1.GetLength(1)];
            int[,] asymetricPart1 = new int[res1.GetLength(0), res1.GetLength(1)];
            int[,] nonComparabilityRatio1 = new int[res1.GetLength(0), res1.GetLength(1)];
            int[,] reverseMatrix2 = new int[res2.GetLength(0), res2.GetLength(1)];
            int[,] symetricPart2 = new int[res2.GetLength(0), res2.GetLength(1)];
            int[,] asymetricPart2 = new int[res2.GetLength(0), res2.GetLength(1)];
            int[,] nonComparabilityRatio2 = new int[res2.GetLength(0), res2.GetLength(1)];
            int[,] reverseMatrix3 = new int[res3.GetLength(0), res3.GetLength(1)];
            int[,] symetricPart3 = new int[res3.GetLength(0), res3.GetLength(1)];
            int[,] asymetricPart3 = new int[res3.GetLength(0), res3.GetLength(1)];
            int[,] nonComparabilityRatio3 = new int[res3.GetLength(0), res3.GetLength(1)];

            Matrix matr1 = new Matrix(res1);
            reverseMatrix1 = matr1.Reverse();
            symetricPart1 = matr1.GetSymetricPart(reverseMatrix1);
            asymetricPart1 = matr1.GetAsymetricPart();
            nonComparabilityRatio1 = matr1.GetNonComparabilityRatio();
            Matrix matr2 = new Matrix(res2);
            reverseMatrix2 = matr2.Reverse();
            symetricPart2 = matr2.GetSymetricPart(reverseMatrix2);
            asymetricPart2 = matr2.GetAsymetricPart();
            nonComparabilityRatio2 = matr2.GetNonComparabilityRatio();
            Matrix matr3 = new Matrix(res3);
            reverseMatrix3 = matr3.Reverse();
            symetricPart3 = matr3.GetSymetricPart(reverseMatrix3);
            asymetricPart3 = matr3.GetAsymetricPart();
            nonComparabilityRatio3 = matr3.GetNonComparabilityRatio();



            Console.WriteLine("I01");
            WriteMatrix(symetricPart1);
            Console.WriteLine("P01");
            WriteMatrix(asymetricPart1);
            Console.WriteLine("N01");
            WriteMatrix(nonComparabilityRatio1);

            Console.WriteLine("I02");
            WriteMatrix(symetricPart2);
            Console.WriteLine("P02");
            WriteMatrix(asymetricPart2);
            Console.WriteLine("N02");
            WriteMatrix(nonComparabilityRatio2);

            Console.WriteLine("I03");
            WriteMatrix(symetricPart3);
            Console.WriteLine("P03");
            WriteMatrix(asymetricPart3);
            Console.WriteLine("N03");
            WriteMatrix(nonComparabilityRatio3);

            int[,] result = new int[criteria.GetLength(0), criteria.GetLength(0)];

            int[,] P2symetricPart = new int[res1.GetLength(0), res1.GetLength(1)];
            int[,] P2asymetricPart = new int[res1.GetLength(0), res1.GetLength(1)];
            int[,] P2nonComparabilityRatio = new int[res1.GetLength(0), res1.GetLength(1)];

            for (int i = 0; i < criteria.GetLength(0); i++)
            {
                for (int j  = 0; j < criteria.GetLength(0); j++)
                {
                    if ((asymetricPart2[i, j] == 1 && (asymetricPart1[i, j] == 1 || nonComparabilityRatio1[i, j] == 1 || symetricPart1[i, j] == 1))
                        || (symetricPart2[i, j] == 1 && asymetricPart1[i, j] == 1))
                    {
                        P2asymetricPart[i, j] = 1;
                    }
                    else
                    {
                        P2asymetricPart[i, j] = 0;
                    }

                    if(symetricPart2[i,j]==1 && symetricPart1[i,j]==1)
                    {
                        P2symetricPart[i, j] = 1;
                    }
                    else
                    {
                        P2symetricPart[i, j] = 0;
                    }                  
                }
            }

            for (int i = 0; i < criteria.GetLength(0); i++)
            {
                for (int j = 0; j < criteria.GetLength(0); j++)
                {
                    if (!(P2asymetricPart[i, j] == 1 || P2asymetricPart[j,i]==1 || P2symetricPart[i,j]==1))
                    {
                        P2nonComparabilityRatio[i, j] = 1;
                    }
                    else
                    {
                        P2nonComparabilityRatio[i, j] = 0;
                    }
                }
            }

            int[,] P3symetricPart = new int[res1.GetLength(0), res1.GetLength(1)];
            int[,] P3asymetricPart = new int[res1.GetLength(0), res1.GetLength(1)];
            int[,] P3nonComparabilityRatio = new int[res1.GetLength(0), res1.GetLength(1)];

            for (int i = 0; i < criteria.GetLength(0); i++)
            {
                for (int j = 0; j < criteria.GetLength(0); j++)
                {
                    if ((asymetricPart3[i, j] == 1 && (P2asymetricPart[i, j] == 1 || P2nonComparabilityRatio[i, j] == 1 || P2symetricPart[i, j] == 1))
                        || (symetricPart3[i, j] == 1 && P2asymetricPart[i, j] == 1))
                    {
                        P3asymetricPart[i, j] = 1;
                    }
                    else
                    {
                        P3asymetricPart[i, j] = 0;
                    }

                    if (symetricPart3[i, j] == 1 && P2symetricPart[i, j] == 1)
                    {
                        P3symetricPart[i, j] = 1;
                    }
                    else
                    {
                        P3symetricPart[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < criteria.GetLength(0); i++)
            {
                for (int j = 0; j < criteria.GetLength(0); j++)
                {
                    if (!(P3asymetricPart[i, j] == 1 || P3asymetricPart[j, i] == 1 || P3symetricPart[i, j] == 1))
                    {
                        P3nonComparabilityRatio[i, j] = 1;
                    }
                    else
                    {
                        P3nonComparabilityRatio[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < P3symetricPart.GetLength(0); i++)
            {
                for (int j = 0; j < P3symetricPart.GetLength(0); j++)
                {
                    if (P3symetricPart[i,j]==1 || P3asymetricPart[i,j]==1)
                    {
                        result[i, j] = 1;
                    }
                    else
                    {
                        result[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = i; j < 20; j++)
                {
                    if(result[i, j]==1 && result[j,i]==1)
                    {
                        result[i,j] = 0;
                        result[j,i] = 0;
                    }
                }
            }
            WriteMatrix(result);
            return result;
        }
        private static int[,] Electre(int[,] criteria, int[] balance, double c, double d)
        {
            int BalanceSum = balance.Sum();
            int[,] matrix = new int[criteria.GetLength(0), criteria.GetLength(0)];
            double[,] consistency = new double[criteria.GetLength(0), criteria.GetLength(0)];
            double[,] non_consistency = new double[criteria.GetLength(0), criteria.GetLength(0)];
            double[] non_consistency_znamenic = new double[balance.GetLength(0)];
            WriteMatrix(criteria);
            List<int> maxmin = new List<int>();

            for (int i = 0; i < balance.GetLength(0); i++)
            {
                
                for (int j = 0; j < 15; j++)
                {
                    maxmin.Add(criteria[j, i]);
                }
                int max = maxmin.Max();
                int min = maxmin.Min();
                non_consistency_znamenic[i] = (balance[i] * Math.Abs(max - min));
                maxmin.Clear();
            }

            List<int> kPlus = new List<int>();
            List<int> kEqual = new List<int>();
            List<int> kMinus = new List<int>();
            List<int> kPlusM = new List<int>();
            List<int> kEqualM = new List<int>();
            List<int> kMinusM = new List<int>();
            Dictionary<int, int> kMinusDict = new Dictionary<int, int>();
            Dictionary<int, int> kPlusDict = new Dictionary<int, int>();


            double Pplus = 0;
            double Pequal = 0;
            double Pminus = 0;

            double PplusM = 0;
            double PequalM = 0;
            double PminusM = 0;

            int p = 1;
            int p2 = 1;
            int p3 = 1;
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {

                    for (int k = 0; k < criteria.GetLength(1); k++)
                    {
                        if(criteria[i,k]>criteria[i+p,k])
                        {
                            kPlus.Add(balance[k]);
                            kPlusDict.Add(k, balance[k]);
                        }

                        else if(criteria[i, k] < criteria[i + p, k])
                        {
                            kMinus.Add(balance[k]);
                            kMinusDict.Add(k, balance[k]);
                        }

                        else
                        {
                            kEqual.Add(balance[k]);
                        }
                    }
                    p++;

                    Pplus = kPlus.Sum();
                    Pminus = kMinus.Sum();
                    Pequal = kEqual.Sum();

                    double match = ((Pplus + Pequal) / BalanceSum);
                    consistency[i, j] = Math.Round(match, 3);
                    double mismatch = 0;

                    if (kMinus.Count()==0)
                    {
                        mismatch = 0;
                    }
                    else
                    {
                        List<double> X = new List<double>();
                        List<double> Y = new List<double>();
                        double max_X = 0.0;
                        double max_Y = 0.0;

                        foreach (var item in kMinusDict)
                        {
                            X.Add(item.Value* Math.Abs(criteria[i,item.Key]-criteria[i+p2,item.Key]));
                            Y.Add(non_consistency_znamenic[item.Key]);
                        }

                        p2++;
                        max_X = X.Max();
                        max_Y = Y.Max();
                        mismatch = max_X / max_Y;

                        X.Clear();
                        Y.Clear();
                    }

                    non_consistency[i, j] = Math.Round(mismatch, 3);

                    if(match >= c && mismatch <= d)
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }

                    kPlusM.AddRange(kMinus);
                    kMinusM.AddRange(kPlus);
                    kEqualM.AddRange(kEqual);
                    
                    match = 0;
                    mismatch = 0;
                    kEqual.Clear();
                    kMinusDict.Clear();
                    foreach (var item in kPlusDict)
                    {
                        kMinusDict.Add(item.Key, item.Value);
                    }
                    kMinus.Clear();
                    kPlus.Clear();
                    kPlusDict.Clear();
                    Pplus = 0;
                    Pminus = 0;
                    Pequal = 0;

                    ////////////////////////////////////////////////////    
                    
                    PplusM = kPlusM.Sum();
                    PminusM = kMinusM.Sum();
                    PequalM = kEqualM.Sum();

                    match = ((PplusM + PequalM) / BalanceSum);
                    consistency[j, i] = Math.Round(match, 3);

                    if (kMinusM.Count() == 0)
                    {
                        mismatch = 0;
                    }
                    else
                    {
                        List<double> X = new List<double>();
                        List<double> Y = new List<double>();
                        double max_X = 0.0;
                        double max_Y = 0.0;

                        foreach (var item in kMinusDict)
                        {
                            X.Add(item.Value * Math.Abs(criteria[i, item.Key] - criteria[i + p3, item.Key]));
                            Y.Add(non_consistency_znamenic[item.Key]);
                        }

                        p3++;
                        max_X = X.Max();
                        max_Y = Y.Max();
                        mismatch = max_X / max_Y;

                        X.Clear();
                        Y.Clear();
                    }

                    non_consistency[j, i] = Math.Round(mismatch, 3);

                    if (match >= c && mismatch <= d)
                    {
                        matrix[j, i] = 1;
                    }
                    else
                    {
                        matrix[j, i] = 0;
                    }
                    ///////////////////////////////////////
                    kMinusDict.Clear();
                    kPlusDict.Clear();
                    kPlusM.Clear();
                    kMinusM.Clear();
                    kEqualM.Clear();
                    match = 0;
                    mismatch = 0;
                    PplusM = 0;
                    PminusM = 0;
                    PequalM = 0;
                }
                p = 1;
                p2 = 1;
                p3 = 1;
            }

            for (int i = 0; i < consistency.GetLength(0); i++)
            {
                for (int j = 0; j < consistency.GetLength(0); j++)
                {
                    if (i==j)
                    {
                        consistency[i, j] = 0;
                        non_consistency[i, j] = 1;
                    }
                }
            }


            Console.WriteLine("Consistency matrix:");
            WriteMatrix(consistency);
            WriteCONMatrixToFile(ref consistency);
            Console.WriteLine("Mismatch matrix:");
            WriteMatrix(non_consistency);
            WriteNONCONMatrixToFile(ref non_consistency);
            Console.WriteLine("Result:");
            WriteMatrix(matrix);
            return matrix;
        }
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

            List<int> res = new List<int>();
            Console.Write("Xhm=");
            foreach (int s in Q)
            {
                int a = s;
                res.Add(++a);
                Console.Write(++a + " ");
            }

            string filePath = "D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\Results.txt";
            string message = "";
            foreach (var item in res)
            {
                message += $"{item}" + " ";
            }
            File.AppendAllText(filePath, message + Environment.NewLine);
            message = "";
            
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

            k1Matrix = kOpt(symetricPart, asymetricPart, nonComparabilityRatio, matrix.GetLength(0), 1);
            k2Matrix = kOpt(null, asymetricPart, nonComparabilityRatio, matrix.GetLength(0), 2);
            k3Matrix = kOpt(symetricPart, asymetricPart, null, matrix.GetLength(0), 3);
            k4Matrix = kOpt(null, asymetricPart, null, matrix.GetLength(0), 4);

            
            List<int> kMax = new List<int>();
            List<int> kOptim = new List<int>();

            Console.WriteLine("========================================================");
            Console.WriteLine("Results");
            for (int i = 0; i < k1Matrix.GetLength(0); i++)
            {
                List<int> op = new List<int>();
                for (int j = 0; j < k1Matrix.GetLength(1); j++)
                {
                    op.Add(k1Matrix[i, j]);
                    
                    if (k1Matrix[i, j] == 0 && Explore_Column(k1Matrix.GetLength(1), j, k1Matrix))
                    {
                        
                    }
                    else if (k1Matrix[i, j] == 1)
                    {
                        
                    }
                    else
                    {
                        break;
                    }
                    
                    if(j==k1Matrix.GetLength(0)-1)
                    {
                        if (op.Where(x => x == 0).Count() == 0)
                        {
                            kOptim.Add(i);
                        }
                        else
                        {
                            kMax.Add(i);
                        }
                    }
                }
                op.Clear();
                
            }

            
            Console.Write("K1-Max: ");
            foreach (var item in kMax)
            {
                int k =item;
                Console.Write(++k + " ");
            }

            Console.WriteLine(" ");

            Console.Write("K1-Opt: ");
            foreach (var item in kOptim)
            {
                int k = item;
                Console.Write(++k + " ");
            }

            Console.WriteLine(" ");

            kOptim.Clear();
            kMax.Clear();

            for (int i = 0; i < k2Matrix.GetLength(0); i++)
            {
                List<int> op = new List<int>();
                for (int j = 0; j < k2Matrix.GetLength(1); j++)
                {
                    op.Add(k2Matrix[i, j]);

                    if (k2Matrix[i, j] == 0 && Explore_Column(k2Matrix.GetLength(1), j, k2Matrix))
                    {

                    }
                    else if (k2Matrix[i, j] == 1)
                    {

                    }
                    else
                    {
                        break;
                    }

                    if (j == k2Matrix.GetLength(0) - 1)
                    {
                        if (op.Where(x => x == 0).Count() == 0)
                        {
                            kOptim.Add(i);
                        }
                        else
                        {
                            kMax.Add(i);
                        }
                    }
                }
                op.Clear();

            }

            Console.Write("K2-Max: ");
            foreach (var item in kMax)
            {
                int k = item;
                Console.Write(++k + " ");
            }

            Console.WriteLine(" ");

            Console.Write("K2-Opt: ");
            foreach (var item in kOptim)
            {
                int k = item;
                Console.Write(++k + " ");
            }

            Console.WriteLine(" ");

            kOptim.Clear();
            kMax.Clear();

            for (int i = 0; i < k3Matrix.GetLength(0); i++)
            {
                List<int> op = new List<int>();
                for (int j = 0; j < k3Matrix.GetLength(1); j++)
                {
                    op.Add(k3Matrix[i, j]);

                    if (k3Matrix[i, j] == 0 && Explore_Column(k3Matrix.GetLength(1), j, k3Matrix))
                    {

                    }
                    else if (k3Matrix[i, j] == 1)
                    {

                    }
                    else
                    {
                        break;
                    }

                    if (j == k3Matrix.GetLength(0) - 1)
                    {
                        if (op.Where(x => x == 0).Count() == 0)
                        {
                            kOptim.Add(i);
                        }
                        else
                        {
                            kMax.Add(i);
                        }
                    }
                }
                op.Clear();

            }

            Console.Write("K3-Max: ");
            foreach (var item in kMax)
            {
                int k = item;
                Console.Write(++k + " ");
            }

            Console.WriteLine(" ");

            Console.Write("K3-Opt: ");
            foreach (var item in kOptim)
            {
                int k = item;
                Console.Write(++k + " ");
            }

            Console.WriteLine(" ");

            kOptim.Clear();
            kMax.Clear();

            for (int i = 0; i < k4Matrix.GetLength(0); i++)
            {
                List<int> op = new List<int>();
                for (int j = 0; j < k4Matrix.GetLength(1); j++)
                {
                    op.Add(k4Matrix[i, j]);

                    if (k4Matrix[i, j] == 0 && Explore_Column(k4Matrix.GetLength(1), j, k4Matrix))
                    {

                    }
                    else if (k4Matrix[i, j] == 1)
                    {

                    }
                    else
                    {
                        break;
                    }

                    if (j == k4Matrix.GetLength(0) - 1)
                    {
                        if (op.Where(x => x == 0).Count() == 0)
                        {
                            kOptim.Add(i);
                        }
                        else
                        {
                            kMax.Add(i);
                        }
                    }
                }
                op.Clear();

            }

            Console.Write("K4-Max: ");
            foreach (var item in kMax)
            {
                int k = item;
                Console.Write(++k + " ");
            }

            Console.WriteLine(" ");

            Console.Write("K4-Opt: ");
            foreach (var item in kOptim)
            {
                int k = item;
                Console.Write(++k + " ");
            }

            Console.Write("\n");
            Console.WriteLine("========================================================");
            Console.WriteLine("\n ");
        }
        public static bool Explore_Column(int lenght, int j, int[,] kmatrix)
        {
            for (int k = 0; k < lenght; k++)
            {
                if (kmatrix[k, j] == 1)
                {
                    return false;
                }
            }
            return true;
        }
        public static int[,] kOpt(int[,] sym, int[,]asym, int[,]nonComp, int size, int k)
        {
            int[,] down = new int[size, size];

            switch (k)
            {
                case 1:
                    {
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                if (sym[i, j] == 1)
                                {
                                    down[i, j] = 1;
                                }
                                else if (asym[i, j] == 1)
                                {
                                    down[i, j] = 1;
                                }
                                else if(nonComp[i, j] == 1)
                                {
                                    down[i, j] = 1;
                                }
                                else
                                {
                                    down[i, j] = 0;
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                if (asym[i, j] == 1)
                                {
                                    down[i, j] = 1;
                                }
                                else if(nonComp[i, j] == 1)
                                {
                                    down[i, j] = 1;
                                }
                                else
                                {
                                    down[i, j] = 0;
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    {
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                if (asym[i, j] == 1)
                                {
                                    down[i, j] = 1;
                                }
                                else if(sym[i, j] == 1)
                                {
                                    down[i, j] = 1;
                                }
                                else
                                {
                                    down[i, j] = 0;
                                }
                            }
                        }
                    }
                    break;
                case 4:
                    {
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                if (asym[i, j] == 1)
                                {
                                    down[i, j] = 1;
                                }                               
                                else
                                {
                                    down[i, j] = 0;
                                }
                            }
                        }
                    }
                    break;                
            }
            
            return down;
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
        public static void ReadCriteria(ref int[,] matrix)
        {
            string[] mass = File.ReadAllLines("D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\Criteria.txt");
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
        public static void WriteMatrixToFile(ref int[,] matrix)
        {
            string filePath = "D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\MATRIX.txt";

            File.WriteAllText(filePath, string.Empty);
            string message = "";
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    message += " " + matrix[j, i].ToString();
                }
                File.AppendAllText(filePath, message + Environment.NewLine);
                message = "";
            }           
        }
        public static void WriteCONMatrixToFile(ref double[,] matrix)
        {
            string filePath = "D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\Match.txt";

            File.WriteAllText(filePath, string.Empty);
            string message = "";
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    message += " " + matrix[j, i].ToString();
                }
                File.AppendAllText(filePath, message + Environment.NewLine);
                message = "";
            }
        }
        public static void WriteNONCONMatrixToFile(ref double[,] matrix)
        {
            string filePath = "D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\Mismatch.txt";

            File.WriteAllText(filePath, string.Empty);
            string message = "";
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    message += " " + matrix[j, i].ToString();
                }
                File.AppendAllText(filePath, message + Environment.NewLine);
                message = "";
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
        public static void WriteMatrix(double[,] matrix)
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
            

            while (true)
            {

                string[] mass = File.ReadAllLines("D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\MATRIX.txt");
                int[,] matrix = new int[mass.Length, mass.Length];
                ReadMatrix(ref matrix);

                string[] criteriaM = File.ReadAllLines("D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\Criteria.txt");
                int[,] criteria = new int[criteriaM.Length, 12];
                ReadCriteria(ref criteria);

                Console.WriteLine("Identify plural of the best alternatives using the principle:\n" +
                                "1) Domination;\n" +
                                "2) Locking;\n" +
                                "3) Сyclicity check;\n" +
                                "4) Build an advantage relationship on the principle of Pareto;\n" +
                                "5) Build an advantage relationship if the criteria are balanced (majority);\n" +
                                "6) Build an advantage relationship if the set of criteria specifies a strict order relation(lexicographical);\n" +
                                "7) Build an advantage relationship if the set of quasi-orders is given on the set of criteria (Berezovsky);\n" +
                                "8) Build an advantage relationship if the criteria are equilibrium (Podinovsky);\n" +
                                "9) Electre;\n" +
                                "10) Experiment with (d);\n" +
                                "11) Experiment with (c);\n" +
                                "12) Experiment with (c,d);\n" +
                                "13) Exit\n" +
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
                        int[,] mas1= Pareto(criteria);
                        WriteMatrixToFile(ref mas1);
                        break;
                    case 5:
                        int[,] mas3 = Majority(criteria);
                        WriteMatrixToFile(ref mas3);
                        break;
                    case 6:
                        int[] koef = new int[criteria.GetLength(1)];
                        Console.WriteLine("Sort the criteria in descending order of importance!");
                        for (int i = 0; i < criteria.GetLength(1); i++)
                        {
                            int k = int.Parse(Console.ReadLine());
                            koef[i] = k;
                        }
                        int[,] mas4 = Lexicographical(criteria, koef);
                        WriteMatrixToFile(ref mas4);                     
                        break;
                    case 7:
                        Console.WriteLine("Arrange the classes in ascending order of importance!");

                        Console.WriteLine("Specify the number of criteria in the first class:");
                        int k1 = int.Parse(Console.ReadLine());
                        int[] criteria1 = new int[k1];
                        for (int i = 0; i < k1; i++)
                        {
                            Console.WriteLine("Enter № criterion belonging to the 1 class");
                            int k = int.Parse(Console.ReadLine());
                            criteria1[i] = k;
                        }
                        Console.WriteLine("Specify the number of criteria in the second class:");
                        int k2 = int.Parse(Console.ReadLine());
                        int[] criteria2 = new int[k2];
                        for (int i = 0; i < k2; i++)
                        {
                            Console.WriteLine("Enter № criterion belonging to the 2 class");
                            int k = int.Parse(Console.ReadLine());
                            criteria2[i] = k;
                        }
                        Console.WriteLine("Specify the number of criteria in the third class:");
                        int k3 = int.Parse(Console.ReadLine());
                        int[] criteria3 = new int[k3];
                        for (int i = 0; i < k3; i++)
                        {
                            Console.WriteLine("Enter № criterion belonging to the 3 class");
                            int k = int.Parse(Console.ReadLine());
                            criteria3[i] = k;
                        }

                        Console.WriteLine();

                        int[,] mas5 = Berezovsky(criteria,criteria1,criteria2,criteria3);
                        WriteMatrixToFile(ref mas5);
                        break;
                    case 8:
                        int[,] mas2 = Padenovski(criteria);
                        double Match = 0.0;
                        double Mismatch = 0.0;
                        WriteMatrixToFile(ref mas2);
                        break;
                    case 9:
                        int[] balance = new int[criteria.GetLength(1)];
                        for (int i = 0; i < criteria.GetLength(1); i++)
                        {
                            Console.WriteLine($"Enter the weighting factor of criterion №{i+1}:");
                            balance[i] = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("==================================================");

                        Console.WriteLine("Enter a threshold value for the matching index (c):");
                        Match = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter a threshold value for the mismatch index (d):");
                        Mismatch = double.Parse(Console.ReadLine());

                        int[,] mas6 = Electre(criteria, balance, Match, Mismatch);
                        WriteMatrixToFile(ref mas6);
                        break;
                    case 10:
                        string filePath = "D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\Results.txt";

                        File.WriteAllText(filePath, string.Empty);

                        int[,] mat = new int[15,15];
                        int[] balance1 = new int[] { 9, 10, 3, 7, 6, 2, 5, 7, 7, 1, 10, 1 };
                        for (double i = 0.0; i <=0.5 ; i+=0.1)
                        {
                            int[,] mas7 = Electre(criteria, balance1, 0.5, i);
                            WriteMatrixToFile(ref mas7);
                            ReadMatrix(ref mat);
                            Сhoose_Alghoritm(mat);
                        }
                        Console.WriteLine("End");
                        break;
                    case 11:
                        string filePath1 = "D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\Results.txt";
                        File.WriteAllText(filePath1, string.Empty);

                        int[,] mat1 = new int[15, 15];
                        int[] balance2 = new int[] { 9, 10, 3, 7, 6, 2, 5, 7, 7, 1, 10, 1 };
                        for (double i = 0.5; i <= 1; i += 0.1)
                        {
                            int[,] mas7 = Electre(criteria, balance2, i, 0.49);
                            WriteMatrixToFile(ref mas7);
                            ReadMatrix(ref mat1);
                            Сhoose_Alghoritm(mat1);
                        }
                        Console.WriteLine("End");
                        break;
                    case 12:
                        string filePath2 = "D:\\Labs\\4Cours\\Teoria_Rozkladiv\\lab2_TPR\\Results.txt";
                        File.WriteAllText(filePath2, string.Empty);

                        int[,] mat2 = new int[15, 15];
                        int[] balance3 = new int[] { 9, 10, 3, 7, 6, 2, 5, 7, 7, 1, 10, 1 };
                        double k4 = 1.000;
                        double j4 = 0.000;
                        for (double i = 1; i <= 5; i++)
                        {
                            int[,] mas7 = Electre(criteria, balance3, k4, j4);
                            WriteMatrixToFile(ref mas7);
                            ReadMatrix(ref mat2);
                            Сhoose_Alghoritm(mat2);
                            k4 -= 0.100;
                            j4 += 0.100;
                        }
                        Console.WriteLine("End");
                        break;
                    case 13:
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
