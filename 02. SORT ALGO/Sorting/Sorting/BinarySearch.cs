using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public class BinarySearch
    {
        public static int IndexOf(int[] arr, int key)
        {
            int min = 0;
            int max = arr.Length - 1;

            while (min <= max)
            {
                int mid = (max + min) / 2;

                if (key == arr[mid])
                {
                    return mid;
                }
                else if (key < arr[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return -1;
        }

        public static int IndexOf(int[] arr, int key, int min, int max)
        {
            if (min > max)
            {
                return -1;
            }
            else
            {
                int mid = (min + max) / 2;

                if (key == arr[mid])
                {
                    return mid;
                }
                else if(key < arr[mid])
                {
                    return IndexOf(arr, key, min, mid - 1);
                }
                else
                {
                    return IndexOf(arr, key, mid + 1, max);
                }
            }
        }
    }
}
