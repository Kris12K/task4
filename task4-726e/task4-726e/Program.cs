using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4_726e
{
    class Program
    {
        //функция проверки ввода вещественного числа
        public static double CheckInputDouble(string message, double minValue, double maxValue)
        //(сообщение, мин вводимое значение, макс вводимое значение)
        {
            double input; //переменная, которой будет присвоено значение, введенное с клавиатуры
            do
            {
                input = maxValue + 1;  //переменной присваивается значение, выходящее за макс значение
                Console.WriteLine(message); //печать сообщения
                try
                {
                    string buf = Console.ReadLine();
                    input = Convert.ToDouble(buf);
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
                {
                }
            } while ((input <= minValue) || (input >= maxValue)); //пока значение больше или равно макс/меньше мин
            return input;
        }

        //функция, возвращающая значение f(x)
        static double f(double x)
        {
            return (Math.Pow(x, 4) + 0.5 * Math.Pow(x, 3) - 4 * x * x - 3 * x - 0.5);
        }

        //функция нахождения корня уравнения с помощью метода хорд
        static double FindRoot(double x0, double x1, double e)
        //левая граница отрезка, правая граница отрезка, точность 
        {
            double x2=0;

            while (Math.Abs(x1 - x0) > e)
            {
                x2 = x1 - f(x1) * (x1 - x0) / (f(x1) - f(x0));
                x0 = x1;
                x1 = x2;
            }
            return x2;
        }

        static void Main(string[] args)
        {
            //программа находит корень уравнения с помощью метода хорд на заданном отрезке

            double x;//искомый корень уравнения
            double x0, x1;//левая и правая границы отрезка, который содержит x
            double e;//заданная точность
            x0 = -1;
            x1 = 0;
            e = CheckInputDouble("Введите e от 0 до 1", 0, 1);//ввод е с клавиатуры и проверка ввода
            x = FindRoot(x0, x1, e);//поиск корня
            Console.WriteLine("x=" + x);//вывод корня
        }
    }
}
