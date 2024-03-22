namespace LeetCode_2306
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(DistinctNames(["coffee", "donuts", "time", "toffee"]));
        }
        public static long DistinctNames(string[] ideas)
        {
            long distinctCompany = 0;
            Dictionary<char, HashSet<string>> dict = new Dictionary<char, HashSet<string>>();
            //Initially map the key as first letter from the hint of question and value is string
            foreach (var idea in ideas)
            {
                if (!dict.ContainsKey(idea[0]))
                {
                    dict.Add(idea[0], new HashSet<string>());
                }
                dict[idea[0]].Add(idea);
            }
            Dictionary<char, Dictionary<char, long>> set = new Dictionary<char, Dictionary<char, long>>();
            //Generate All possible combinations of the company name
            foreach (var idea1 in dict.Keys)
            {
                set.Add(idea1, new Dictionary<char, long>());
                foreach (var idea2 in dict.Keys)
                {
                    if (idea1 == idea2)
                    {
                        continue;
                    }
                    set[idea1].Add(idea2, 0);
                    foreach (var str in dict[idea2])
                    {
                        var posCompany = $"{idea1}" + str.Substring(1);
                        if (!dict[idea1].Contains(posCompany))
                        {
                            set[idea1][idea2]++;
                        }
                    }
                }
            }
            // Compute the which all are distinct.
            foreach (var idea1 in dict.Keys)
            {
                foreach (var idea2 in dict.Keys)
                {
                    if (idea1 == idea2) continue;
                    distinctCompany += set[idea1][idea2] * set[idea2][idea1];
                }
            }
            return distinctCompany;
        }
    }
}
/*
2306. Naming a Company
    ==============================
You are given an array of strings ideas that represents a list of names to be used in the process of naming a company. The process of naming a company is as follows:

Choose 2 distinct names from ideas, call them ideaA and ideaB.
Swap the first letters of ideaA and ideaB with each other.
If both of the new names are not found in the original ideas, then the name ideaA ideaB (the concatenation of ideaA and ideaB, separated by a space) is a valid company name.
Otherwise, it is not a valid name.
Return the number of distinct valid names for the company.

 

Example 1:

Input: ideas = ["coffee","donuts","time","toffee"]
Output: 6
Explanation: The following selections are valid:
- ("coffee", "donuts"): The company name created is "doffee conuts".
- ("donuts", "coffee"): The company name created is "conuts doffee".
- ("donuts", "time"): The company name created is "tonuts dime".
- ("donuts", "toffee"): The company name created is "tonuts doffee".
- ("time", "donuts"): The company name created is "dime tonuts".
- ("toffee", "donuts"): The company name created is "doffee tonuts".
Therefore, there are a total of 6 distinct company names.

The following are some examples of invalid selections:
- ("coffee", "time"): The name "toffee" formed after swapping already exists in the original array.
- ("time", "toffee"): Both names are still the same after swapping and exist in the original array.
- ("coffee", "toffee"): Both names formed after swapping already exist in the original array.
Example 2:

Input: ideas = ["lack","back"]
Output: 0
Explanation: There are no valid selections. Therefore, 0 is returned.
 

Constraints:

2 <= ideas.length <= 5 * 104
1 <= ideas[i].length <= 10
ideas[i] consists of lowercase English letters.
All the strings in ideas are unique.
 */