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
    }
}