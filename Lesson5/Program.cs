using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShowString();

            //ShowMethods();

            //ShowSB();
            int a = 32;
            Int32 b = 32;
            double x = 6851.645;
            double y = 15.14988;

            Console.WriteLine("X = {0}\nY = {1}", x, y);

            string message = String.Format("X = {0}\nY = {1}", x, y);
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            double price = 99.9999;
            Console.WriteLine("Цена = {0}", price);
            Console.WriteLine();

            Console.WriteLine("Цена = {0:e}", price); //scientific

            Console.WriteLine();
            Console.WriteLine("Цена = {0:c}", price); //commercial

            Console.WriteLine();
            Console.WriteLine("Цена = {0:.#####}", price);


            Point p = new Point(213.454544, 15.1816);
            //Console.WriteLine(p);
            Console.WriteLine("{0:myFormat}", p);
            Console.WriteLine("{0:science}", p);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            DateTime date = DateTime.Now;
            Console.WriteLine("{0:HH:mm}", date);
            Console.WriteLine("{0:yy.MM.dd HH:mm}", date);
            Console.WriteLine("{0:yyyy.MMMM.dd HH:mm:ss}", date);
        }

        private static void ShowSB()
        {
            int n = 1000000;
            StringBuilder data = new StringBuilder();
            Console.WriteLine(data.Capacity); //увеличивается вдвое
            for (int i = 0; i < n; i++)
            {
                if (i == 16)
                {
                    Console.WriteLine(data.Capacity);
                }

                data.Append(i);
            }
            Console.WriteLine();
            Console.WriteLine(data.Capacity);
            Console.WriteLine(data.MaxCapacity);
            Console.WriteLine(data.Length);
        }

        private static void ShowMethods()
        {
            string text = "простая строка";

            Console.WriteLine(text.Replace("простая", "сложная"));

            Console.WriteLine(text.Length);
            Console.WriteLine(text[0]);

            Console.WriteLine(text.CompareTo("простая строка"));

            Console.WriteLine(text.Contains("стр"));

            text = text.Insert(0, "Это ");
            Console.WriteLine(text);
            Console.WriteLine(text.Remove(7, 4));


            Console.WriteLine();

            string data = "655 511 984 64 687 35 64 6";
            string[] items = data.Split(' ');

            int sum = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sum += int.Parse(items[i]);
            }
            Console.WriteLine(sum);

            string login = "username ";
            login = login.Trim(' ');
            Console.WriteLine("|" + login + "|");
        }

        private static void ShowString()
        {
            string text = String.Empty; // аналогично ""
            string text1 = "простой текст";

            string text2 = "\a";
            Console.WriteLine(text2);

            text1 = "первая\nвторая";
            Console.WriteLine(text1);

            text1 = "первая\t123";
            Console.WriteLine(text1);

            /*string[] symbols = new string[]{"\\", "|", "/", "-"};
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(symbols[i%4] + "\r");
                Thread.Sleep(200);
            }*/

            string path = @"C:\Lesson6\Point.txt";
            //string path2 = Console.ReadLine();
            Console.WriteLine();

            text1 = "наши занятия \"легкие\"";

            char symbol = '\'';
            Console.WriteLine(symbol);

            text1 = @"первая {0}строку{1}
вторая строка
            примечание";
        }
    }

    class Point : IFormattable
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "myFormat":
                    return String.Format("X = {0}; Y = {1}", x, y);
                case "science":
                    return String.Format("[{0:e}  {1:e}]", x, y);
                default:
                    return ToString();
            }
        }
    }
}
