using System;

namespace FizzBizz
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var numbers = new int[] { 2, 3, 4, 5, 7, 13 };
            Console.WriteLine(solution.OutputNumbers(numbers, 13, "Thirteen"));
        }
    }
}
