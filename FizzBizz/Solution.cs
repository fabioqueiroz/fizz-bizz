using FizzBizz.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static string OutputWord(int number)
        {
            //if (number.IsMultipleOf(3) && number.IsMultipleOf(5)) return nameof(OutputEnum.FizzBuzz);
            //if (number.IsMultipleOf(7)) return nameof(OutputEnum.Woof);
            //if (number.IsMultipleOf(5)) return nameof(OutputEnum.Buzz);
            //if (number.IsMultipleOf(3)) return nameof(OutputEnum.Fizz);

            //return number.ToString();
            return _functionalSelector.First(x => x.Predicate(number)).Output(number);
        }

        private static readonly List<(Func<int, bool> Predicate, Func<int, string> Output)> _functionalSelector = new()
        {
           new (x => x.IsMultipleOf(3) && x.IsMultipleOf(5), x => nameof(OutputEnum.FizzBuzz)),
           new (x => x.IsMultipleOf(7), x => nameof(OutputEnum.Woof)),
           new (x => x.IsMultipleOf(5), x => nameof(OutputEnum.Buzz)),
           new (x => x.IsMultipleOf(3), x => nameof(OutputEnum.Fizz)),
           new (x => true, x => x.ToString())
        };
    }
}
