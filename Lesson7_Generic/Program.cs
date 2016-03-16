using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersLibrary;

namespace Lesson7_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Point<int, int> p1 = new Point<int, int>(3, 80000);
            p1.Print();

            Point<double, double> p2 = new Point<double, double>(2.125, 80000);
            p2.Print();

            Point<string, double> p3 = new Point<string, double>("паспмо", 1000000);
            p3.Print();*/

            int x = 10;
            double y = 1000.456;
            string name = "qwerty";
            Console.WriteLine(x+ " " + y+ " " + name);
            Console.WriteLine("X = {0}   Y = {1}   name = {0}", x, y);
        }
    }

    class Point<T, M> //where T: string where M: struct
    {
        public T x;
        public M y;

        public Point(T x, M y)
        {
            this.x = x;
            this.y = y;
        }

        public void Print()
        {
            Console.WriteLine("X = {0}\nY = {1}", x, y);
        }
    }

    
}
