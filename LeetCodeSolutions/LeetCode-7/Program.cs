namespace LeetCode_7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Reverse(123));
        }
        public static int Reverse(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;
                if (result > Int32.MaxValue / 10 || (result == Int32.MaxValue / 10 && pop > 7))
                    return 0;
                if (result < Int32.MinValue / 10 || (result == Int32.MinValue / 10 && pop < -8))
                    return 0;
                result = result * 10 + pop;
            }
            return result;
        }
    }
}
/*
 7. Reverse Integer
    ==============================
Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.

Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

 

Example 1:

Input: x = 123
Output: 321
Example 2:

Input: x = -123
Output: -321
Example 3:

Input: x = 120
Output: 21
 

Constraints:

-231 <= x <= 231 - 1
 */