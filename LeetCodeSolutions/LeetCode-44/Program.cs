﻿namespace LeetCode_44
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(IsMatch("aa","*"));
        }
        public static bool IsMatch(string s, string p)
        {
            int m = s.Length, n = p.Length;
            bool[,] dp = new bool[m + 1, n + 1];
            dp[0, 0] = true;

            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == '*')
                {
                    dp[0, j] = dp[0, j - 1];
                }
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (p[j - 1] == '*')
                    {
                        dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
                    }
                    else if (p[j - 1] == '?' || s[i - 1] == p[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                }
            }

            return dp[m, n];

        }
    }
}
/*
 44. Wildcard Matching
    ==============================
Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*' where:

'?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).
The matching should cover the entire input string (not partial).

 

Example 1:

Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:

Input: s = "aa", p = "*"
Output: true
Explanation: '*' matches any sequence.
Example 3:

Input: s = "cb", p = "?a"
Output: false
Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.
 

Constraints:

0 <= s.length, p.length <= 2000
s contains only lowercase English letters.
p contains only lowercase English letters, '?' or '*'.
 */