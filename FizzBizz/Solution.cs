using FizzBizz.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBizz
{
    public class Solution
    {
        public string OutputNumbers(int[] numbers, int ruleNumber = 0, string ruleMessage = null)
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
    }
}
