using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersLibrary
{
    public sealed class Driver : Worker
    {
        private string carType;

        public string CarType
        {
            get { return carType; }
            set { carType = value; }
        }
        private int hours;

        public int Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        public Driver(string name, int age, int snn, string carType, int hours)
            : base(name, age, snn)
        {
            this.carType = carType;
            this.hours = hours;
            salary = 50000;
        }

        public override double GetBonus()
        {
            return hours * 100;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Машина: " + carType);
            Console.WriteLine("Часы: " + hours);
            Console.WriteLine();
        }
    }
}
