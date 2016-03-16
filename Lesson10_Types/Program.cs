using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            //любой тип на стадии компиляции
            var number = 100;

            var text = "text";
            Console.WriteLine(text.Length);

            var x = GetNumber();

            //любой тип на стадии выполнения
            dynamic number2 = 10;
            Console.WriteLine(number2);
            number2 += 100;

            number2 = "строка";
            Console.WriteLine(number2.Length);

            number2 = number2 + 10;
            Console.WriteLine(number2);
        }

        private static double GetNumber()
        {
            return 100.0;
        }
    }
}
