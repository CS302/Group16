using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lesson10_Serialization
{
    [Serializable]
    [XmlRoot("rates")]
    public class MoneyRates
    {
        [XmlElement("EUR")]
        public Eur eur;
        [XmlElement("RUR")]
        public Rur rur;
        [XmlElement("UAH")]
        public Uah uah;
        [XmlElement("USD")]
        public Usd usd;
    }

    [Serializable]
    public class Eur
    {
        public double RUR;
        public double UAH;
        public double USD;
    }

    [Serializable]
    public class Rur
    {
        public double EUR;
        public double UAH;
        public double USD;
    }

    [Serializable]
    public class Uah
    {
        public double EUR;
        public double RUR;
        public double USD;
    }

    [Serializable]
    public class Usd
    {
        public double EUR;
        public double RUR;
        public double UAH;
    }


    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://www.liqpay.com/exchanges/exchanges.cgi");
            Stream streamLP = request.GetResponse().GetResponseStream();

            MoneyRates data = new MoneyRates();
            data.eur = new Eur();
            data.rur = new Rur();
            data.uah = new Uah();
            data.usd = new Usd();

            XmlSerializer serializer = new XmlSerializer(data.GetType());
            data = (MoneyRates)serializer.Deserialize(streamLP);
            streamLP.Close();
            Console.ReadLine();

            //Point p = new Point(10, 15, "Точка1");
            //XMLSerialization(p);

            //Point p = XMLDeserializer();
            //p.Print();

            /*Random rnd = new Random();
            List<Point> points = new List<Point>();
            for (int i = 0; i < rnd.Next(5, 101); i++)
            {
                Point p = new Point(rnd.Next(-100, 101), rnd.Next(-100, 101), "Точка" + i);
                points.Add(p);
            }

            XMLSerialization(points);*/
        }

        private static void XMLSerialization(List<Point> p)
        {
            FileStream stream = new FileStream("data1.xml", FileMode.Create, FileAccess.Write);

            XmlSerializer serializer = new XmlSerializer(p.GetType());
            serializer.Serialize(stream, p);

            stream.Close();
        }

        private static Point XMLDeserializer()
        {
            FileStream stream = new FileStream("data.xml", FileMode.Open, FileAccess.Read);

            Point p = new Point();

            XmlSerializer serializer = new XmlSerializer(p.GetType());
            p = (Point)serializer.Deserialize(stream);

            stream.Close();

            return p;
        }


        private static void BinarySerialization(Point p)
        {
            FileStream stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write);

            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(stream, p);

            stream.Close();
        }

        private static Point BinaryDeserialization()
        {
            FileStream stream = new FileStream("data.bin", FileMode.Open, FileAccess.Read);

            BinaryFormatter format = new BinaryFormatter();
            Point p = (Point)(format.Deserialize(stream));

            stream.Close();

            return p;
        }
    }

    [Serializable]
    public class Point
    {
        public int x;
        public int y;
        public string label;

        public Point()
        {   }

        public Point(int x, int y, string label)
        {
            this.x = x;
            this.y = y;
            this.label = label;
        }

        public void Print()
        {
            Console.WriteLine("label - {0}\nX = {1}\nY = {2}", label, x, y);
        }
    }
}
