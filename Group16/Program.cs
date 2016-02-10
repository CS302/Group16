using System;

namespace Group16
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!"); //qwerty
            Console.ReadLine();*/

            /*int number = 10;
            Console.WriteLine(number);
            number = 100;
            Console.WriteLine(number);

            number = 10 * 50 - 75;

            number = 10 - number;

            Console.WriteLine(number);
            Console.WriteLine();

            number = 56 / 10; //div целочисленное деление
            Console.WriteLine(number);
            number = 56 % 10; //mod остаток от деления
            Console.WriteLine(number);
            Console.WriteLine();

            number = 56;
            double number2 = (double)number / 10;
            Console.WriteLine(number2);

            Console.WriteLine("*************");

            string text = "123456789";
            int number3 = int.Parse(text);
            number3 = number3 + 1;
            Console.WriteLine(number3);

            char symbol = 'A';
            Console.WriteLine(symbol);

            Console.WriteLine("a" + "b" + "c");
            Console.WriteLine('a' + 'b' + 'c');
            Console.WriteLine((int)'a');
            Console.WriteLine((int)'6');

            bool flag = true;
            flag = true && false;
            Console.WriteLine(flag);
            flag = !true;
            Console.WriteLine(flag);

            Console.WriteLine("***********");

            int number4 = -10;
            number4 = -number4;
            Console.WriteLine(number4);

            int number5 = 5;
            number5++;
            Console.WriteLine(number5);
            number5 = number5 + 2;
            number5 += 10;
            Console.WriteLine(number5);*/

            DateTime date = new DateTime(2016, 2, 10);
            Console.WriteLine(date.DayOfWeek);

            DayOfWeek day = DayOfWeek.Friday;
            Console.WriteLine((int)day);

            DayOfWeek day2 = (DayOfWeek)4;
            Console.WriteLine(day2);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Желтенький");
        }
    }

    enum Users
    {
        Admin,
        AuthUser,
        Guest,
        Banned
    }
}
