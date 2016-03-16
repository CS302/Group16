//#define TRIAL
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
            int x = Sum(10, 20);
            double area = Mul(10.0, 1.5);
        }

        [Obsolete("новый метод double Sum(double, double)"/*, true*/)]
        private int Sum(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Считает площадь прямоугольника
        /// </summary>
        /// <param name="a">Длина первой стороны</param>
        /// <param name="b">Длина второй стороны</param>
        /// <returns>double площадь прямоугольника</returns>
        private double Mul(double a, double b)
        {
            return a * b;
        }

        [Conditional("DEBUG")]
        private void ShowInfo()
        {
            MessageBox.Show("Приложение калькулятор\nver 1.1");
        }

        //+
        private void btn_Calc_Click(object sender, EventArgs e)
        {
#if TRIAL
            Random rnd = new Random();
            textBox3.Text = rnd.Next(0, 98465).ToString();
            MessageBox.Show("Купите продукт))");
#else
//#error Не хватает проверок!!!
#warning Не хватает проверок!!!
            //todo доработать проверки
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);

            int sum = x + y;

            textBox3.Text = sum.ToString();
#endif
        }

    }
}
