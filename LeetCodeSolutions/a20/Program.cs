namespace a20
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("([])"));
            Console.WriteLine(IsValid("()[]{}"));
        }
        private static bool IsValid(string s)
        {
            Dictionary<char, char> map = new Dictionary<char, char>();
            map.Add(')', '(');
            map.Add('}', '{');
            map.Add(']', '[');

            if (s.Length == 1)
            {
                return false;
            }
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {

                if (map.ContainsKey(s[i]))
                {
                    if (stack.Count > 0 && stack.Peek() == map[s[i]])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(s[i]);
                }
            }

            if (stack.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
/*
 * 20. Valid Parentheses
 Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
 

Example 1:

Input: s = "()"

Output: true

Example 2:

Input: s = "()[]{}"

Output: true

Example 3:

Input: s = "(]"

Output: false

Example 4:

Input: s = "([])"

Output: true

 

Constraints:

1 <= s.length <= 104
s consists of parentheses only '()[]{}'.
 */