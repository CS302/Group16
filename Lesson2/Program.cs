using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintSmth();
            //int x = 10;
            //int y = 6;
            //DoSmth(x, y);
            //int z = Sum(x, y);
            //Console.WriteLine(z);


            //ShowArrays();

            //ShowRefTypes();

            //ShowIfSitch();
            for (int i = 0; i < 11; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                } 
            }


            int[,] table2 = new int[10, 10];
            for (int i = 0; i < table2.GetLength(0); i++)
            {
                for (int j = 0; j < table2.GetLength(1); j++)
                {
                    //if
                    table2[i, j] = 1;
                }
            }
            for (int i = 0; i < table2.GetLength(0); i++)
            {
                for (int j = 0; j < table2.GetLength(1); j++)
                {
                    Console.Write(table2[i, j] + " ");
                }
                Console.WriteLine();
            }

            /*string comand = Console.ReadLine();
            while (comand != "exit")
            {
                Console.WriteLine("Выполняется какая-то работа");
                comand = Console.ReadLine();
            }*/

            /*string comand;
            do
            {
                Console.WriteLine("Выполняется какая-то работа");
                comand = Console.ReadLine();
            } while (comand != "exit");*/

        }

        private static void ShowIfSitch()
        {
            string text = Console.ReadLine();
            /*if (text == "exit")
            {
                Console.WriteLine("Работа завершена");
            }
            else 
            {
                Console.WriteLine("Выполняется какая-то работа");
            }*/

            switch (text)
            {
                case "exit":
                    Console.WriteLine("Работа завершена");
                    break;
                case "Option 1":
                case "Option 10":
                    Console.WriteLine("Включена 1 опция");
                    break;
                case "Option 2":
                    Console.WriteLine("Включена опция 2");
                    break;
                default:
                    Console.WriteLine("Попробуйте еще раз");
                    break;
            }
        }

        static void ShowRefTypes()
        {
            int[] array1 = new int[2] { 5, 9 };
            int[] array2 = new int[2] { 9, 9 };
            Console.WriteLine(array1[0] + " " + array1[1]);
            Console.WriteLine(array2[0] + " " + array2[1]);
            Console.WriteLine();

            array1 = array2;
            Console.WriteLine(array1[0] + " " + array1[1]);
            Console.WriteLine(array2[0] + " " + array2[1]);
            Console.WriteLine();

            array2[0] = 100;
            array2[1] = 100;
            Console.WriteLine(array1[0] + " " + array1[1]);
            Console.WriteLine(array2[0] + " " + array2[1]);
            Console.WriteLine();
        }

        static void ShowArrays()
        {
            int number = 10;
            int[] numbers = new int[5];
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = 3;
            numbers[3] = 4;
            numbers[4] = 5;

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.GetLength(0));

            Console.WriteLine("**************");

            int[,] table = new int[2, 3];
            table[0, 0] = 1;
            table[0, 1] = 2;
            table[0, 2] = 3;
            table[1, 0] = 4;
            table[1, 1] = 5;
            table[1, 2] = 6;
            Console.WriteLine(table.Length);
            Console.WriteLine(table.GetLength(0));
            Console.WriteLine(table.GetLength(1));
            Console.WriteLine();
            Console.Write(table[0, 0] + " ");
            Console.Write(table[0, 1] + " ");
            Console.WriteLine(table[0, 2] + " ");
            Console.Write(table[1, 0] + " ");
            Console.Write(table[1, 1] + " ");
            Console.WriteLine(table[1, 2] + " ");

            int[] numbers1 = new int[5] { 1, 2, 3, 4, 5 };
            int[] numbers2 = new int[] { 1, 2, 3, 4, 5 };
            int[] numbers3 = { 1, 2, 3, 4, 5 };

            int[,] table2 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
        }

        static void PrintSmth()
        {
            Console.WriteLine("Результат работы метода");
        }

        static void DoSmth(int a, int b)
        {
            int sum = a + b;
            Console.WriteLine("Сумма чисел = " + sum);
        }

        static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
