namespace LeetCode_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(FindMedianSortedArrays([1, 3], [2]));
        }
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var mergedArray = Merge(nums1, nums2);
            if (mergedArray.Length % 2 == 1)
                return mergedArray[mergedArray.Length / 2];
            else
                return (mergedArray[mergedArray.Length / 2] + mergedArray[mergedArray.Length / 2 - 1]) / 2.0;
        }

        public static int[] Merge(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length + nums2.Length];
            int i = 0, j = 0;
            while (i < nums1.Length || j < nums2.Length)
            {
                if (i < nums1.Length && j < nums2.Length)
                {
                    if (nums1[i] <= nums2[j])
                    {
                        result[i + j] = nums1[i];
                        i++;
                    }
                    else
                    {
                        result[i + j] = nums2[j];
                        j++;
                    }
                    continue;
                }

                if (i < nums1.Length)
                {
                    result[i + j] = nums1[i];
                    i++;
                    continue;
                }

                if (j < nums2.Length)
                {
                    result[i + j] = nums2[j];
                    j++;
                    continue;
                }
            }
            return result;
        }
    }
}
/* 
 4. Median of Two Sorted Arrays

Given two sorted arrays nums1 and nums2 of size m and n respectively, 
return the median of the two sorted arrays.

The overall run time complexity should be O(log (m+n)).

 

Example 1:

Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.
Example 2:

Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
 

Constraints:

nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-106 <= nums1[i], nums2[i] <= 106
 */