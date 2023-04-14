using FizzBizz.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FizzBizz
{
    public class Solution
    {
        public static string OutputNumbers(int[] numbers, int ruleNumber = 0, string ruleMessage = null)
        {
            var strBuilder = new StringBuilder();

            for (int i = 0; i < numbers.Length; i++)
            {
                string strNumber = numbers[i] switch
                {
                    int _ when (numbers[i] % 3 == 0) => nameof(OutputEnum.Fizz),
                    int _ when (numbers[i] % 5 == 0) => nameof(OutputEnum.Buzz),
                    int _ when (numbers[i] % 7 == 0) => nameof(OutputEnum.Woof),
                    _ => numbers[i].ToString(),
                };

                if (ruleNumber > 0 && !string.IsNullOrEmpty(ruleMessage))
                {
                    if (numbers[i] % ruleNumber == 0)
                    {
                        strNumber = ruleMessage;
                    }
                }

                strBuilder.Append(strNumber);               
                strBuilder.Append(' ');               
            }

            return strBuilder.ToString();
        }

        public static string OutputNumbers2(int[] numbers, int ruleNumber = 0, string ruleMessage = null)
        {
            var numberStringValues = MapNumbersToStringValues(numbers.ToList(), ruleNumber, ruleMessage);
            return string.Join(" ", numberStringValues);
        }

        public static string OutputWord(int number)
        {
            return _outputSelector.First(x => x.Predicate(number)).Output(number);
        }

        private static readonly List<(Func<int, bool> Predicate, Func<int, string> Output)> _outputSelector = new()
        {
           new (x => x.IsMultipleOf(3) && x.IsMultipleOf(5), x => nameof(OutputEnum.FizzBuzz)),
           new (x => x.IsMultipleOf(7), x => nameof(OutputEnum.Woof)),
           new (x => x.IsMultipleOf(5), x => nameof(OutputEnum.Buzz)),
           new (x => x.IsMultipleOf(3), x => nameof(OutputEnum.Fizz)),
           new (x => true, x => x.ToString())
        };

        private static List<string> MapNumbersToStringValues(List<int> numbers, int ruleNumber = 0, string ruleMessage = null)
        {
            var numberValues = new List<string>();
            numbers.ForEach(number => numberValues.Add(GetStringValue(number, ruleNumber, ruleMessage)));
            return numberValues;
        }

        private static string GetStringValue(int number, int ruleNumber = 0, string ruleMessage = null)
            => new List<(Func<int, bool> Predicate, Func<int, int, string, string> Output)>
            {
               new (x => x.IsMultipleOf(3) && x.IsMultipleOf(5), (x, y, z) => nameof(OutputEnum.FizzBuzz)),
               new (x => x.IsMultipleOf(7), (x, y, z) => nameof(OutputEnum.Woof)),
               new (x => x.IsMultipleOf(5), (x, y, z) => nameof(OutputEnum.Buzz)),
               new (x => x.IsMultipleOf(3), (x, y, z) => nameof(OutputEnum.Fizz)),
               new (x => true, (x, y, z) => x.RuleChecker(y, z))
            }.First(x => x.Predicate(number)).Output(number, ruleNumber, ruleMessage);
    }
}
