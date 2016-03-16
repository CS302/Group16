using System.Diagnostics;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Lesson9_11._03._16
{
    class Program
    {
        delegate void BinaryOp(int a, int b);
        static Queue<int> que;
        static object lockObject = new object();
        static void Main(string[] args)
        {
            #region Process

            //Process[] processes = Process.GetProcesses();
            //foreach (Process p in processes)
            //{
            //    if (p.ProcessName == "notepad++")
            //    {
            //        Console.WriteLine("Kill notepad++ process.");
            //        p.Kill();
            //    }
            //}
            //Process.Start("notepad++", @"D:\Programs\Lesson6_29.02.16//\Lesson6_29.02.16\bin\Debug\testfile.txt");
            //Process.Start("notepad++");
            //ProcessStartInfo info = new ProcessStartInfo();
            //info.FileName = "notepad++";
            //info.Arguments = @"D:\Programs\Lesson6_29.02.16/\Lesson6_29.02.16/\bin\Debug\testfile.txt";
            //info.WindowStyle = ProcessWindowStyle.Minimized;
            //Process.Start(info);

            #endregion 

            #region Delegate
            //BinaryOp op = new BinaryOp(Sum);
            //op += delegate(int x, int y)
            //{
            //    
            //};

            //op = ((x, y) =>  Console.WriteLine(x + y) );
            //op(10, 20);
            
            //op = Mult;
            
            //Console.WriteLine();
            //op.Invoke(10, 20);
            //
            //Sum(10, 20);
            //Mult(1, 10);

            //Action<int, int> action = Sum;
            //action(10, 20);

            //Func<DateTime, string> func = DateToString;
            //Console.WriteLine(func(DateTime.Now));
            #endregion

            #region Async
            //Func<int, int, int> action = GetNumbers;
            ////action(10, 20);
            //IAsyncResult result = action.BeginInvoke(10, 20, ShowGetNumberResult, //null);
            //
            //while (Console.ReadLine() != "exit")
            //{ 
            //}
            //
            //int sum = action.EndInvoke(result);
            //Console.WriteLine(sum);
            #endregion

            #region Thread
            //ThreadStart y = DoSmth;
            //Thread t = new Thread(y);
            //
            //t.Start();
            //DoSmth();
            

            //que = new Queue<int>();
            //for (int i = 0; i < 100; i++)
            //{
            //    que.Enqueue(i);
            //}
            //Action<int> workItem = DeQueueItem;
            //workItem.BeginInvoke(1, null, null);
            //workItem.BeginInvoke(2, null, null);
            #endregion
            Console.ReadLine();
        }

        static void DoSmth()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void DeQueueItem(int id)
        {
            while (que.Count != 0)
            {
                int number = -1;
                Thread.Sleep(10);
                lock (lockObject)
                {
                    number = que.Dequeue();
 
                }
                number *= number;
                Console.WriteLine("{0}-{1}", number, id);
            }
        }

        static void Sum(int a, int b)
        {
            double sum = 0;
            for (int i = a; i < b; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);
        }

        static void Mult(int a, int b)
        {
            double mult = 1;
            for (int i = a; i < b; i++)
            {
                mult *= i;
            }
            Console.WriteLine(mult);
        }

        static string DateToString(DateTime time)
        {
            return time.ToLongDateString();
        }

        static int GetNumbers(int a, int b)
        {
            int sum = 0;
            for (int i = a; i < b; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
                sum += i;
            }
            return sum;
        }

        static void ShowGetNumberResult(IAsyncResult res)
        {
            AsyncResult r = (AsyncResult)res;
            Func<int, int, int> workitem = (Func<int, int, int>)r.AsyncDelegate;
            int sum = workitem.EndInvoke(res);
            Console.WriteLine(sum);
        }

    }
}