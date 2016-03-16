using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static Dictionary<string, Func<double, double, double>> _operations;
        static void Main(string[] args)
        {
            _operations = new Dictionary<string, Func<double, double, double>>
            {
                { "+", (x, y) => x + y},
                { "-", DoSubstraction},
                { "*", DoMultiplication},
                { "/", DoDivision}
            };

            DefineOperation("mod", (x, y) => x % y);

            Console.WriteLine( PerformOperation("mod", 101, 4));

            Console.ReadLine();
        }

        static double PerformOperation(string op, double x, double y)
        {
            #region First Step
            //switch (op)
            //{
            //    case "+": return DoAddition(x, y);
            //    case "-": return DoSubstraction(x, y);
            //    case "*": return DoMultiplication(x, y);
            //    case "/": return DoDivision(x, y);
            //    default:
            //        throw new ArgumentException("Операция " + op + " не имеет /обработки /в коде.");
            //}
            #endregion 

            if(!_operations.ContainsKey(op))
                throw new ArgumentException("Операция " + op + " не имеет /обработки /в коде.");
            return _operations[op](x, y);
        }

        static void DefineOperation(string op, Func<double, double, double> body)
        {
            if (_operations.ContainsKey(op))
                throw new ArgumentException("Операция " + op + " уже добавлена.");
            _operations.Add(op, body);
        }


        static double DoAddition(double x, double y)
        {
            return x + y;
        }

        static double DoSubstraction(double x, double y)
        {
            return x - y;
        }

        static double DoMultiplication(double x, double y)
        {
            return x - y;
        }

        static double DoDivision(double x, double y)
        {
            if (y == 0)
                return 0;
            else
                return x / y;
        }
    }
}
