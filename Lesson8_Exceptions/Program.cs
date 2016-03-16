using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start();
            Console.WriteLine("MaxInt = {0}", int.MaxValue);
            Console.WriteLine("MinInt = {0}\n\n\n", int.MinValue);

            int a = 2000000000;
            int b = 2000000000;
            try
            {
                int c = a + b;
                Console.WriteLine(c);
                
            }
            catch(OverflowException)
            {
                Console.WriteLine("Переполнение разрядной сетки");
            }
            
            

        }

        static void Start()
        {
            //throw new Exception("А мне захотелось");
                    
            while (true)
            {
                try
                {
                    int number;
                    number = int.Parse(Console.ReadLine());
                    Console.WriteLine(150 / number);
                    return;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    //Console.WriteLine(ex.StackTrace);
                    Console.WriteLine("Вводить надо число!");
                    Console.WriteLine("Попробуйте еще раз:");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                    //Console.WriteLine(ex.StackTrace);
                    Console.WriteLine("Нельзя делить на ноль");
                    Console.WriteLine("Попробуйте еще раз:");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    //Console.WriteLine(ex.StackTrace);
                    Console.WriteLine("Нужно число из диапазона [{0} до {1}]", int.MinValue, int.MaxValue);
                    Console.WriteLine("Попробуйте еще раз:");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //Console.WriteLine(ex.StackTrace);
                    Console.WriteLine("Что-то пошло не так. Обратитесь к системному администратору.");
                    Console.WriteLine("Попробуйте еще раз:");
                }
            }
            
        }
    }
}
