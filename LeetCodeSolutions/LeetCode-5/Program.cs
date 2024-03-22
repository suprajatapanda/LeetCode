namespace LeetCode_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindrome("babad"));
        }
        public static string LongestPalindrome(string s)
        {
            int n = s.Length;
            bool[,] dp = new bool[n, n];

            // initialize dp array
            for (int i = 0; i < n; i++)
            {
                dp[i, i] = true;
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (s[i] == s[j] && (j - i <= 2 || dp[i + 1, j - 1]))
                    {
                        dp[i, j] = true;
                    }
                }
            }

            int start = 0, maxLen = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (dp[i, j] && j - i + 1 > maxLen)
                    {
                        start = i;
                        maxLen = j - i + 1;
                    }
                }
            }

            return s.Substring(start, maxLen);
        }
    }

}
/*
 5. Longest Palindromic Substring
    =================================
    Given a string s, return the longest palindromic substring in s.

Example 1:

Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.
Example 2:

Input: s = "cbbd"
Output: "bb"
 

Constraints:

1 <= s.length <= 1000
s consist of only digits and English letters.
 */