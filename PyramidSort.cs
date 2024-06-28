using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    public class PyramidSort
    {
        public List<int[]> states = new List<int[]>();
        public void sort(int[] arr)
        {
            int len = arr.Length;
            for (int i = len / 2 - 1; i >= 0; i--)
            {
                saveState(arr);
                heapify(arr, len, i);
            }

            for (int i = len - 1; i >= 0; i--)
            {
                saveState(arr);
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                heapify(arr, i, 0);
            }
        }

        private void heapify(int[] arr, int size, int i)
        {
            int max = i;
            int left = i * 2 + 1;
            int right = i * 2 + 2;

            if (left < size && arr[left] > arr[max])
            {
                max = left;
            }

            if (right < size && arr[right] > arr[max])
            {
                max = right;
            }

            if (max != i)
            {
                int temp = arr[i];
                arr[i] = arr[max];
                arr[max] = temp;

                heapify(arr, size, max);
            }
        }

        private void saveState(int[] arr)
        {
            int[] slot = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                slot[i] = arr[i];
            }
            states.Add(slot);
        }

        public string printArray(int[] arr)
        {
            string res = "";
            for (int i = 0; i < arr.Length; i++)
            {
                res += arr[i] + " ";
            }
            return res;
        }
    }
}
