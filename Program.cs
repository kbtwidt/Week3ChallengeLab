using System.Timers;

namespace Week3ChallengeLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part1
            Console.WriteLine("Part 1");
            string inputWord;
            char choice = 'y';
            while (choice == 'y' || choice == 'Y')
            {
                Console.Write("\nProvide a word to check for palindrome: ");
                inputWord = Console.ReadLine().ToLower();
                Console.WriteLine(IsPalindrome(inputWord));
                Console.Write("Would you like to try another word?(y/Y): ");
                choice = char.Parse(Console.ReadLine());
            }

            #endregion

            #region Part2
            Console.WriteLine("Part 2");
            int sum;
            Console.Write("Input a string containing letters and numbers: ");
            inputWord = Console.ReadLine();
            sum = SumDigits(inputWord);
            Console.WriteLine($"Sum of numbers in {inputWord} is: {sum}");
            #endregion

            #region Part3
            Console.WriteLine("Part 3");
            int n;
            int target;
            int[] resultArray = new int[2];
            Console.Write("How big of an array will you input?: ");
            n = int.Parse(Console.ReadLine());
            int[] inputArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Input a number for array entry[{i + 1}]: ");
                inputArray[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Input a target number for addition: ");
            target = int.Parse(Console.ReadLine());
            resultArray = ArraySum(inputArray, target);
            Console.WriteLine($"Target({target}) is found as sum of indexes: [{resultArray[0]},{resultArray[1]}]");
            #endregion

            #region Part4
            Console.WriteLine("Part 4");
            string s = "ABFCACDB";
            int result;
            result = MinStringLength(s);
            Console.WriteLine($"Resulting length of {s} after removal of all 'AB' and 'CD' combos: {result}");
            s = "ACBBD";
            result = MinStringLength(s);
            Console.WriteLine($"Resulting length of {s} after removal of all 'AB' and 'CD' combos: {result}"); 
            #endregion

        }

        public static bool IsPalindrome(string text)
        {
            int left = 0;
            int right = text.Length - 1;

            while (left < right)
            {
                if (text[left] != text[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }

        public static int SumDigits(string text)
        {
            int sum = 0;

            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    sum += int.Parse(c.ToString()); 
                }
            }

            return sum;
        }

        public static int[] ArraySum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { };
        }

        public static int MinStringLength(string s)
        {
            while (s.Contains("AB") || s.Contains("CD"))
            {
                s = s.Replace("AB", "");
                s = s.Replace("CD", "");
            }

            return s.Length;
        }
    }
}
