using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = new Worker[5];
            //workers[0] = new Worker("John", 27, 461352);
            //workers[1] = new Worker("Hulk", 25, 465138);
            //workers[2] = new Worker("Helena", 25, 478656);
            Driver dr1 = new Driver("Jason", 45, 46513, "BMW", 256);
            Manager mn1 = new Manager("Mary", 27, 461577, 15);

            /*Worker worker = dr1;
            Driver dr2 = (Driver)worker;
            Console.WriteLine(dr2.hours);*/

            Worker worker = mn1;
            Driver dr = worker as Driver;
            if (dr != null)
            {
                Console.WriteLine(dr.hours);
            }
            else
            {
                Console.WriteLine("Что-то пошло не так");
            }
            /*if (worker is Driver)
            {
                Driver dr2 = (Driver)worker;
                Console.WriteLine(dr2.hours);
            }
            else
            {
                Console.WriteLine("Что-то пошло не так");
            }*/


            
        }
    }

    /// <summary>
    /// 
    /// </summary>
    abstract class Worker
    {
        #region Поля
        /// <summary>
        /// 
        /// </summary>
        private string name; //поле класса
        private int age;
        public int snn;
        public static int count; //поле count относится не к объекту-работнику, а к классу
        protected double salary;

        #endregion

        #region Свойства
        /// <summary>
        /// 
        /// </summary>
        public int Age
        {
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Неверно задан возраст!!!");
                }
                else
                {
                    age = value;
                }
            }
            get
            {
                return age;
            }
        }
        public string Name
        {
            get { return name; }
        } 
        #endregion

        #region Конструкторы
        static Worker()
        {
            count = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="snn"></param>
        public Worker(string name, int age, int snn)
        {//главный конструктор
            this.name = name;
            Age = age;
            this.snn = snn;
            count++;
            salary = 30000;
        }

        public Worker(string name, int age)
            : this(name, age, 0) //второстепенный конструктор
        { } 
        #endregion

        #region Методы
        public void SetAge(int a)
        {
            if (a <= 0)
            {
                Console.WriteLine("Возраст задан неверно!!!");
            }
            else
            {
                age = a;
            }
        }

        public int GetAge()
        {
            return age;
        }

        abstract public double GetBonus();
        public virtual void Print() //метод
        {
            Console.WriteLine("Имя: " + name);
            Console.WriteLine("Возраст: " + age);
            Console.WriteLine("ИНН: " + snn);
            Console.WriteLine();
        } 
        #endregion
    }
}
