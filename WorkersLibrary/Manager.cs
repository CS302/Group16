using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersLibrary
{
    public class Manager : Worker, IPayTax
    {
        public int projCount;

        public Manager(string name, int age, int snn, int projCount)
            : base(name, age, snn)
        {
            this.projCount = projCount;
            salary = 70000;
        }

        public override double GetBonus()
        {
            return projCount * 1500;
        }

        public double PayTax()
        {
            return salary * 0.13;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Проектов: " + projCount);
            Console.WriteLine();
        }
    }
}
