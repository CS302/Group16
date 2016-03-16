using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8_Lorry
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionLorry lorry1 = new CollectionLorry(300);
            try
            {
                lorry1.Add(new Book("Троелсен", 150));
                lorry1.Add(new Book("Шилдт", 100));
                lorry1.Add(new Disc("Windows 8.1", 20));
                lorry1.Add(new Disc("Photoshop", 50));
            }
            catch (OverflowGoodsException ex)
            {
                Console.WriteLine(ex.Message);
                ex.good.Print();
            }
            finally
            {
                Console.WriteLine("Что-то произошло");
            }

            lorry1.RemoveAt(2);

            for (int i = 0; i < lorry1.Count; i++)
            {
                lorry1[i].Print();
            }
        }
    }

    [Serializable]
    public class OverflowGoodsException : Exception
    {
        public Good good;
        public OverflowGoodsException() { }
        public OverflowGoodsException(string message) : base(message) { }
        public OverflowGoodsException(string message, Exception inner) : base(message, inner) { }
        protected OverflowGoodsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    class CollectionLorry : List<Good>
    {
        private int maxWeight;
        private int weight;
        
        public int MaxWeight
        {
            get { return maxWeight; }
        }

        public int Weight
        {
            get { return weight; }
        }

        public CollectionLorry(int maxWeight)
        {
            this.maxWeight = maxWeight;
        }

        public void Add(Good good)
        {
            if (good.Weight + Weight > MaxWeight)
            {
                OverflowGoodsException ex = new OverflowGoodsException("Невозможно добавить товар");
                ex.good = good;
                throw ex;
            }
            else
            {
                base.Add(good);
                weight += good.Weight;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                weight -= base[index].Weight;
                base.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Товара с таким индексом нет");
            }
        }
    }

    class Lorry
    {
        private int maxWeight;
        private int weight;
        private int count;

        //индексатор
        public Good this[int i]
        {
            get { return items[i]; }
        }

        public int MaxWeight
        {
            get { return maxWeight; }
        }

        public int Weight
        {
            get { return weight; }
        }

        public int Count
        {
            get { return items.Count; }
        }

        private List<Good> items;

        public Lorry(int maxWeight)
        {
            this.maxWeight = maxWeight;
            items = new List<Good>();
        }

        public void Add(Good good)
        {
            if (good.Weight + Weight > MaxWeight)
            {
                Console.WriteLine("Невозможно положить товар в грузовик:");
                good.Print();
                Console.WriteLine();
                return;
            }
            else
            {
                items.Add(good);
                weight += good.Weight;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                weight -= items[index].Weight;
                items.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Товара с таким индексом нет");
            }
        }
    }

    abstract class Good
    {
        protected string name;
        protected int weight;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public abstract void Print();

        public Good(string name, int weight)
        {
            this.name = name;
            this.weight = weight;
        }
    }

    class Book : Good
    {
        public Book(string name, int weight)
            : base(name, weight)
        {   }

        public override void Print()
        {
            Console.WriteLine("Книга - '{0}'    ({1})", name, weight);
        }
    }

    class Disc : Good
    {
        public Disc(string name, int weight)
            : base(name, weight)
        {   }

        public override void Print()
        {
            Console.WriteLine("Диск - '{0}'    ({1})", name, weight);
        }
    }
}
