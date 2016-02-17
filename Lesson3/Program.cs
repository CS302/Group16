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
            Worker worker1 = new Worker("John", 27, 461352);
            worker1.Print();

            Worker worker2 = new Worker("Hulk", 25);
            worker2.Print();

            Worker worker3 = new Worker("Helena", 25, 478656);

            Console.WriteLine(Worker.count);
        }
    }

    class Worker
    {
        private string name; //поле класса
        private int age;
        public int snn;
        public static int count; //поле count относится не к объекту-работнику, а к классу

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
        
        static Worker()
        {
            count = 0;
        }

        public Worker(string name, int age, int snn)
        {//главный конструктор
            this.name = name;
            Age = age;
            this.snn = snn;
            count++;
        }

        public Worker(string name, int age)
            : this(name, age, 0) //второстепенный конструктор
        {   }

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

        public void Print() //метод
        {
            Console.WriteLine("Имя: " + name);
            Console.WriteLine("Возраст: " + age);
            Console.WriteLine("ИНН: " + snn);
            Console.WriteLine();
        }
    }
}
