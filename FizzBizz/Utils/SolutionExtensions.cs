using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBizz.Utils
{
    public static class SolutionExtensions
    {
        public static bool IsMultipleOf(this int number, int input)
            => number % input == 0;

        public static string RuleChecker(this int number, int ruleNumber = 0, string ruleMessage = null)
            => (ruleNumber > 0 && !string.IsNullOrEmpty(ruleMessage) && number % ruleNumber == 0) ? ruleMessage : number.ToString();
    }
}