using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace linyarSearch
{
    internal class Program
    {

        //start =0               4   5      8    end =9
        //**1        2   3   4   5   6   7  8  9  10
                                                  
        //                                  9
        public static bool binarySearch(int[] arr, int target)
        {
            int start = 0;
            int end=arr.Length - 1;
            bool targetFound = false;
            while (start != end ) {
                int item = start + (end - start) / 2;

                if (arr[item] == target)
                {
                    targetFound = true;
                    break;
                }

                if (arr[item] < target)//9
                {
                    start = item + 1;//5
                }

                if (arr[item]>target) 
                {
                    end = item - 1;
                }
            }

            return targetFound; 

        }

        public static void bubbleSort (int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void selectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }

        static void InsertionSort(int[] arr)
        {    //       i
            //{1, 2, 12, 4, 14, 7, 8, 9 ,13, 10 
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];//12  1 
                int j = i - 1;  

                // Move elements of arr[0..i-1], that are greater than key,
                // to one position ahead of their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
        static void Main(string[] args)
        {

            int  [] arr = {2, 12, 1, 4, 14, 7, 8, 9 ,13, 10 };
            bubbleSort(arr); 
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

        }
    }
}