using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void Calculate()
        {
            try
            {
                string rr1 = textBox1.Text;
                string ii1 = textBox2.Text;
                string rr2 = textBox3.Text;
                string ii2 = textBox4.Text;
                switch (comboBox1.Text)
                {

                    case "+":
                        textBox5.Text = Complex.Print(Complex.Sum(rr1, ii1, rr2, ii2));
                        break;
                    case "-":
                        textBox5.Text = Complex.Print(Complex.Subtract(rr1, ii1, rr2, ii2));
                        break;
                    case "*":
                        textBox5.Text = Complex.Print(Complex.Multiplication(rr1, ii1, rr2, ii2));
                        break;
                    case "/":
                        textBox5.Text = Complex.Print(Complex.Divide(rr1, ii1, rr2, ii2));
                        break;
                    case "Cравнение":
                        textBox5.Text = (Complex.Equal(rr1, ii1, rr2, ii2));
                        break;

                    default:
                        break;
                }
            }
            catch(FormatException)
            {
                textBox5.Text = "Ошибка преобразования числа";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

    }
    public class Complex

    {
        public double r, i;
        static public Complex Sum(string rr1, string ii1, string rr2, string ii2) // сумма
        {
            double r1;
            r1 = double.Parse(rr1);
            double r2;
            r2 = double.Parse(rr2);
            double i1;
            i1 = double.Parse(ii1);
            double i2;
            i2 = double.Parse(ii2);

            Complex res = new Complex();
            res.r = r1 + r2;
            res.i = i1 + i2;
            return res;
        }

        public static Complex Multiplication(string rr1, string ii1, string rr2, string ii2) // умножение
        {
            double r1;
            r1 = double.Parse(rr1);
            double r2;
            r2 = double.Parse(rr2);
            double i1;
            i1 = double.Parse(ii1);
            double i2;
            i2 = double.Parse(ii2);

            Complex res = new Complex();
            res.r = r1 * r2 - i1 * i2;
            res.i = r1 * i2 + i1 * r2;
            return res;
        }

        public static Complex Subtract(string rr1, string ii1, string rr2, string ii2)  //минус
        {
            double r1;
            r1 = double.Parse(rr1);
            double r2;
            r2 = double.Parse(rr2);
            double i1;
            i1 = double.Parse(ii1);
            double i2;
            i2 = double.Parse(ii2);
            Complex res = new Complex();
            res.r = r1 - r2;
            res.i = i1 - i2;
            return res;
        }
        public static Complex Divide(string rr1, string ii1, string rr2, string ii2)  // деление
        {
            double r1;
            r1 = double.Parse(rr1);
            double r2;
            r2 = double.Parse(rr2);
            double i1;
            i1 = double.Parse(ii1);
            double i2;
            i2 = double.Parse(ii2);

            Complex res = new Complex();
            res.r = (r1 * r2 + i1 * i2) / (r2 * r2 + i2 * i2);
            res.i = (r2 * i1 - r1 * i2) / (r2 * r2 + i2 * i2);
            return res;
        }
        public static string Equal(string rr1, string ii1, string rr2, string ii2)  // сравнение
        {
            double r1;
            r1 = double.Parse(rr1);
            double r2;
            r2 = double.Parse(rr2);
            double i1;
            i1 = double.Parse(ii1);
            double i2;
            i2 = double.Parse(ii2);
            string res;
            double vector1 = Math.Sqrt(r1 * r1 + i1 * i1);
            double vector2 = Math.Sqrt(r2 * r2 + i2 * i2);
            if (vector1 != vector2)
                if (vector1 > vector2)
                {
                    res = "Первое комплексное число > Второе комплексное число";
                }
                else
                    res = "Первое комплексное число < Второе комплексное число";
            else
                res = "Первое комплексное число = Второе комплексное число";
            return res;
        }
        public static string Print(Complex a)
        {
            string sign = "+";
            if (a.i < 0)
                sign = "";
            return String.Format("{0}{1}{2}i", Math.Round(a.r, 1), sign, Math.Round(a.i, 1));
        }
    }
}
