using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    public class LCS
    {
        int[,] matrix;
        private void createMatrix(int x, int y)
        {
            matrix = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        private void fillMatrix(string a, string b)
        {
            int lenx = a.Length;
            int leny = b.Length;
            createMatrix(lenx, leny);
            for (int i = 1; i < lenx; i++)
            {
                for (int j = 1; j < leny; j++)
                {
                    if (a[i] == b[j])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }
                }
            }
        }

        private string reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string LongestCommonSubsequence(string a, string b)
        {
            string res = "";
            fillMatrix(a, b);

            int lenx = a.Length - 1;
            int leny = b.Length - 1;
            while( lenx >= 0 && leny >= 0)
            {
                if (a[lenx] == b[leny])
                {
                    res += a[lenx];
                    lenx--;
                    leny--;
                }
                else if (matrix[lenx, leny] != 0 && matrix[lenx - 1, leny] > matrix[lenx, leny - 1])
                {
                    lenx--;
                }
                else
                {
                    leny--;
                }
            }

            return reverse(res);
        }
    }
}
