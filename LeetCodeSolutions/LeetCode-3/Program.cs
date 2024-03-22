namespace LeetCode_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));
        }
        public static int LengthOfLongestSubstring(string s)
        {
            int left = 0;
            int right = 0;
            Dictionary<char, int> seen = new Dictionary<char, int>();
            int maxLen = 0;

            while (right < s.Length)
            {
                char c = s[right];
                if (seen.ContainsKey(c) && seen[c] >= left)
                {
                    left = seen[c] + 1;
                    seen = seen.Where(kv => kv.Value >= left).ToDictionary(kv => kv.Key, kv => kv.Value);
                }
                seen[c] = right;
                maxLen = Math.Max(maxLen, right - left + 1);
                right++;
            }

            return maxLen;
        }
    }
}
/*
3. Longest Substring Without Repeating Characters
==================================================

Given a string s, find the length of the longest substring without repeating characters.

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
*/