﻿namespace LeetCode_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Array.ForEach(TwoSum([2, 7, 11, 15], 9),Console.WriteLine);
        }
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> arr = new Dictionary<int, int>();
            int[] result = new int[2];
            int complement = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                complement = target - nums[i];
                if (arr.ContainsKey(complement))
                {
                    result[0] = arr[complement];
                    result[1] = i;
                    return result;
                }
                arr[nums[i]] = i;
            }
            return result;
        }
    }
}

/*
1. Two Sum
==============================
Given an array of integers nums and an integer target, return indices of the two 
numbers such that they add up to target.

You may assume that each input would have exactly one solution, 
and you may not use the same element twice.

You can return the answer in any order.

 

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]
Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]
 

Constraints:

2 <= nums.length <= 104
-109 <= nums[i] <= 109
-109 <= target <= 109
Only one valid answer exists.
 

Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
    */

