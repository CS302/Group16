using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersLibrary;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            // {()} --> правильный
            // {(})[<]> --> неправильный


            /*
             * Пользовательское меню.
             * Выберите файл: ..., ....
             * 1-2
             * 
             * 1 файл: Ввод данных: ФИО, №рейса, №билета, А/П вылета, А/П прилета
             * 
             * 2 файл: №билета, идентификатор чемодана
             * 
             * команда - "закончить"
             * 
             * Вы вводите программе: номер билета
             * Программа выдает всю инф-ию о пасажире: 
             * ФИО, №рейса, А/П вылета, 
             * А/П прилета, 
             * идентификатор чемодана
             */















            string path = Path.Combine("", "", "");


            //ShowList();
            //ShowListGeneric();

            //ShowStack();


            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            foreach (int item in queue)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("***************");

            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Peek());

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            //int number = stack.Peek();
            //Console.WriteLine(number);
            //
            //number = stack.Pop();
            //Console.WriteLine(number);
            //
            //number = stack.Peek();
            //Console.WriteLine(number);

            /*ArrayList list = new ArrayList();
            list.Add(new Driver("John", 27, 6435, "BMW", 256));
            list.Add(new Manager("Hulk", 25, 465138, 25));
            list.Add(new Manager("Helena", 25, 478656, 12));
            list.Add(new Driver("Jason", 45, 46513, "BMW", 256));
            list.Add(new Manager("Mary", 27, 461577, 15));

            foreach (object item in list)
            {
                (item as Worker).Print();
            }

            Console.WriteLine(list.Count);
            list.RemoveAt(3);
            Console.WriteLine(list.Count);

            (list[3] as Worker).Print();

            list.Add("Rabotnik");
            foreach (object item in list)
            {
                (item as Worker).Print();
            }*/
        }

        private static void ShowStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("*********");
            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        private static void ShowListGeneric()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string[] exs = ".exe.pdf.txt.js.txt.txt".Split('.');
            for (int i = 0; i < exs.Length; i++)
            {
                if (!dict.ContainsKey(exs[i]))
                {
                    dict.Add(exs[i], 0);
                }
            }
            string extension = "js";
            dict[extension] += 1;
            Console.WriteLine();
        }

        private static void ShowList()
        {
            Worker[] workers = new Worker[5];
            workers[0] = new Driver("John", 27, 6435, "BMW", 256);
            workers[1] = new Manager("Hulk", 25, 465138, 25);
            workers[2] = new Manager("Helena", 25, 478656, 12);
            workers[3] = new Driver("Jason", 45, 46513, "BMW", 256);
            workers[4] = new Manager("Mary", 27, 461577, 15);

            List<Worker> list = new List<Worker>();
            list.AddRange(workers);

            list.Insert(0, new Manager("Jenny", 25, 55431, 45));

            list.Reverse();
            foreach (Worker item in list)
            {
                item.Print();
            }

            List<int> list2 = new List<int>();
        }
    }
}
