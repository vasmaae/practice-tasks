using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//var 10

namespace Practice_1
{
    public static class TaskManager
    {
        public static int CurrentTask = -1;
        private static string[] tasks = { 
            "Найти серии с максимальной длиной для положительных чисел и отрицательных чисел. Вывести с какой позиции начинается каждая серия и длины серий",
            "Знаки значений всех элементов серии положительные. Перенести после первого отрицательного элемента массива серию с наименьшей длиной.",
            "nothing",
            "Удалить первую серию в массиве"
        };

        public static string GetCurrentTask()
        {
            return tasks[CurrentTask];
        }

        public static string Task1(int[] arr)
        {
            CurrentTask = 0;
            int size = arr.Length / 2;
            string res = "";

            int posLength = 1;
            int negLength = 1;
            int startPos = 0;
            int startNeg = 0;
            int maxLengthPos = 0;
            int maxLengthNeg = 0;
            
            for (int i = 0; i < size - 1; i++)
            {
                if (arr[i] >= 0 && arr[i + 1] >= 0)
                {
                    posLength++;
                    if (posLength >= maxLengthPos)
                    {
                        maxLengthPos = posLength;
                        startPos = i - posLength + 2;
                    }
                }
                else
                {
                    posLength = 1;
                }

                if (arr[i] < 0 && arr[i + 1] < 0)
                {
                    negLength++;
                    if (negLength >= maxLengthNeg)
                    {
                        maxLengthNeg = negLength;
                        startNeg = i - negLength + 2;
                    }
                }
                else
                {
                    negLength = 1;
                }
            }

            res += "iPos: " + startPos + " LPos: " + maxLengthPos + " iNeg: " + startNeg + " LNeg: " + maxLengthNeg;

            return res;
        }

        public static string Task2(int[] arr)
        {
            CurrentTask = 1;
            string res = "";
            int size = arr.Length / 2;

            int firstNegIndex = -1;

            int currLength = 1;
            int startIndex = 0;
            int minLength = size + 1;

            for (int i = 0; i < size - 1; i++)
            {
                if (arr[i] < 0 && firstNegIndex == -1)
                {
                    firstNegIndex = i;
                }

                if (arr[i] > 0 && arr[i + 1] > 0 && i + 1 < size - 1)
                {
                    currLength++;

                }
                else
                {
                    if (currLength < minLength && currLength > 1)
                    {
                        minLength = currLength;
                        startIndex = i - currLength + 1;
                    }
                    currLength = 1;
                }
            }
            if (arr[size] < 0 && firstNegIndex == -1) firstNegIndex = size;

            if (minLength == size + 1 || firstNegIndex == -1)
            {
                for (int i = 0; i < size; i++)
                {
                    res += arr[i] + " ";
                    return res;
                }
            }
            //передвижение в массиве
            if (firstNegIndex > startIndex)
            {
                for (int i = startIndex; i < firstNegIndex; i++)
                {
                    int temp = arr[firstNegIndex];
                    arr[firstNegIndex] = arr[i];
                    arr[i] = temp;
                }
            }
            else
            {
                for (int i = firstNegIndex + 1; i < startIndex; i++)
                {
                    int temp = arr[firstNegIndex + 1];
                    for (int j = firstNegIndex + 1; j < startIndex + minLength - 1; j++)
                    {
                        arr[j] = arr[j + 1];
                    }
                    arr[startIndex + minLength - 1] = temp;
                }
            }
            

            for (int i = 0; i < size; i++)
            {
                res += arr[i] + " ";
            }
            return res;
        }

        public static string Task3(int[] arr)
        {
            int size = arr.Length / 2;
            string res = "";

            bool posSeria = false;
            bool negSeria = false;

            for (int i = 0; i < size - 1; i++)
            {
                if (arr[i] > 0 && arr[i + 1] > 0 && i + 1 < size)
                {
                    posSeria = true;
                    
                }
                else
                {
                    if (posSeria)
                    {
                        posSeria = false;
                        size++;
                        for (int j = size; j >= i + 1; j--)
                        {
                            arr[j] = arr[j - 1]; 
                        }
                        arr[i + 1] = 1;
                        i++;
                    }
                    
                }

                if (arr[i] < 0 && arr[i + 1] < 0 && i + 1 < size)
                {
                    negSeria = true;
                }
                else
                {
                    if (negSeria)
                    {
                        negSeria = false;
                        size++;
                        for (int j = size; j >= i + 1; j--)
                        {
                            arr[j] = arr[j - 1];
                        }

                        arr[i + 1] = -1;
                        i++;
                    }

                }
            }

            for (int i = 0; i < size; i++)
            {
                res += arr[i] + " ";
            }

            return res;
        }

        public static string Task4(int[] arr)
        {
            int size = arr.Length / 2;
            string res = "";

            int seriaLength = 1;
            int startIndex = -1;
            bool seria = false;

            for (int i = 1; i < size; i++)
            {
                if (arr[i] % arr[i - 1] == 0)
                {
                    seria = true;
                    seriaLength++;

                }
                else
                {
                    if (seria)
                    {
                        startIndex = i - seriaLength;
                        break;
                    }
                    seria = false;
                }


            }
            if (startIndex == -1)
            {
                for (int i = 0; i < size; i++)
                {
                    res += arr[i] + " ";
                }

                return res;
            }

            for (int i = startIndex; i < startIndex + seriaLength; i++)
            {
                for (int j = startIndex; j < size; j++)
                {
                    arr[j] = arr[j + 1];
                }
                size--;
            }

            for (int i = 0; i < size; i++)
            {
                res += arr[i] + " ";
            }

            return res;
        }
    }
}
