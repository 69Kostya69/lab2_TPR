using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2_TPR
{
    public class Matrix
    {
        private int[,] data;

        private int m;
        public int M { get => this.m; }

        private int n;
        public int N { get => this.n; }

        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.data = new int[m, n];
        }

        public Matrix(int[,] matrix)
        {
            this.data = matrix;
        }

        public bool IsASymetric()
        {
            bool asymm = true;
            for (int i = 0; i < data.GetLength(0); ++i)
            {
                for (int j = 0; j < data.GetLength(1); ++j)
                    if (data[i, j]==1 && data[i, j] == data[j, i])
                    {
                        asymm = false;
                        return asymm;
                    }
            }

            return true;
        }

        public string FindXp()
        {
            List<int> r = new List<int>();
            for (int i = 0; i < data.GetLength(0); ++i)
            {
                for (int j = 0; j < data.GetLength(1); ++j)
                {
                    if(i!=j)
                    r.Add(data[i,j]);
                }

                if (r.Where(x => x == 0).Count() == 0)
                {
                    return $"The largest on P is: {i+1}\n Because in line {i+1} all 1 except x=y\n";
                };
                r.Clear();
            }

            return "Dominance did not work\n";
        }

        public string FindXr()
        {
            List<int> r = new List<int>();
            List<int> r1 = new List<int>();
            List<int> alternative = new List<int>();
            List<int> alternative1 = new List<int>();
            for (int i = 0; i < data.GetLength(0); ++i)
            {
                for (int j = 0; j < data.GetLength(1); ++j)
                {                  
                  r.Add(data[i, j]);
                    int k = j;
                    int m = i;
                    if (k != m)
                    {
                        r1.Add(data[k, m]);
                    }
                    k++;
                }

                if (r.Where(x => x == 0).Count() == 0)
                {
                    alternative.Add(i+1);
                    if(r1.Where(x => x==1).Count()==0)
                    {
                        alternative1.Add(i + 1);
                    }
                };

                r.Clear();
                r1.Clear();
            }

            StringBuilder sb = new StringBuilder();
            if(alternative.Count!=0)
            {
                if (alternative1.Count != 0)
                {
                    sb.Append("The strictly largest on R are: ");
                    foreach (int alt1 in alternative1)
                    {
                        sb.Append(alt1);
                        sb.Append(" ");
                    }
                    sb.Append(" Because in lines all 1 and in columns all 0 except x=y.\n");

                    return sb.ToString();
                }

                sb.Append("The largest on R are: ");
                foreach (int alt in alternative)
                {
                    sb.Append(alt);
                    sb.Append(" ");
                }
                sb.Append(" Because in lines  all 1 elements.\n");


                return sb.ToString();
            }
            return "Dominance did not work\n";
        }

        public string FindXpMax()
        {
            List<int> r = new List<int>();
            List<int> alternative = new List<int>();
            for (int i = 0; i < data.GetLength(0); ++i)
            {
                for (int j = 0; j < data.GetLength(1); ++j)
                {
                  r.Add(data[j, i]);
                }

                if (r.Where(x => x == 1).Count() == 0)
                {
                    alternative.Add(i+1);
                };

                r.Clear();
            }

            if (alternative.Count()!=0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("The maximum on P are: ");
                foreach (int alt1 in alternative)
                {
                    sb.Append(alt1);
                    sb.Append(" ");
                }
                sb.Append(" Because in columns all 0\n");
                return sb.ToString();
            }
            
            return "Locking did not work\n";
        }

        public string FindXrMax()
        {
            List<int> r = new List<int>();
            List<int> alternative = new List<int>();
            for (int i = 0; i < data.GetLength(0); ++i)
            {
                for (int j = 0; j < data.GetLength(1); ++j)
                {
                    if (data[j, i] == 1 && data[i, j] == 1)
                    {
                        r.Add(0);
                    }
                    else
                    {
                        r.Add(data[j, i]);
                    }
                }

                if (r.Where(x => x == 1).Count() == 0)
                {
                    alternative.Add(i + 1);
                };

                r.Clear();
            }
            var alternative1 = alternative.Except(FindStrictlyXrMaxInt());
            if (alternative1.Count() != 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("The maximum on R are: ");
                foreach (int alt1 in alternative1)
                {
                    sb.Append(alt1);
                    sb.Append(" ");
                }
                sb.Append(" Because in columns all 0 or symmetrical part\n");
                return sb.ToString();
            }

            return "\n";
        }

        public string FindStrictlyXrMax()
        {
            List<int> r = new List<int>();
            List<int> alternative = new List<int>();
            for (int i = 0; i < data.GetLength(0); ++i)
            {
                for (int j = 0; j < data.GetLength(1); ++j)
                {
                   

                    if (data[j, i] == 1 && data[i, j] == 1 && i==j)
                    {
                        r.Add(0);
                    }
                    else
                    {
                        r.Add(data[j, i]);
                    }
                }

              
                if (r.Where(x => x == 1).Count() == 0)
                {
                    alternative.Add(i + 1);
                };

                r.Clear();
            }

            if (alternative.Count() != 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("The strictly maximum on R are: ");
                foreach (int alt1 in alternative)
                {
                    sb.Append(alt1);
                    sb.Append(" ");
                }
                sb.Append(" Because in columns all 0 or symmetrical part in x=y\n");
                return sb.ToString();
            }

            return "\n";
        }

        public List<int> FindStrictlyXrMaxInt()
        {
            List<int> r = new List<int>();
            List<int> alternative = new List<int>();
            for (int i = 0; i < data.GetLength(0); ++i)
            {
                for (int j = 0; j < data.GetLength(1); ++j)
                {


                    if (data[j, i] == 1 && data[i, j] == 1 && i == j)
                    {
                        r.Add(0);
                    }
                    else
                    {
                        r.Add(data[j, i]);
                    }
                }


                if (r.Where(x => x == 1).Count() == 0)
                {
                    alternative.Add(i + 1);
                };

                r.Clear();
            }

            return alternative;
        }
    }
}
