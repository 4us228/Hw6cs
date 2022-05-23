using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw6cs
{
    delegate double Func(double x);
    internal class Program
    {
        public static double C(double x)
        {
            return x * x - 50 * x + 10;
        }
        public static double A(double x)
        {
            return x * 45 + 12 / x + 75;
        }
        public static double B(double x)
        {
            return x * x + 488 * x + 3;
        }
        public static void SaveFunc(Func func ,string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(func(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
        static void Main(string[] args)
        {
            Func func = A;
            Func funcA = B;
            Func funcB = C;

           Func[] funcs = { func, funcA, funcB, };

            
            int choiseFunc = 0;
            int choiseNumberOne = 0;
            int choiseNumberTwo = 0;
            //Задание 2
            do { Console.WriteLine("Выберите функцию результат которой хотите увидеть:");
                Console.WriteLine("1. Функция A");
                Console.WriteLine("2. Функция B");
                Console.WriteLine("3. Функция C");
                Console.WriteLine("Или введите 0 чтобы завершить работу ");
                
                choiseFunc = int.Parse(Console.ReadLine());
                Console.WriteLine("И введите два числа");
                Console.WriteLine("Число номер 1:");
                choiseNumberOne = int.Parse(Console.ReadLine());
                Console.WriteLine("Число номер 2:");
                choiseNumberTwo = int.Parse(Console.ReadLine());



                switch (choiseFunc)
                {
                    case 1: SaveFunc(funcs[0], "data.bin", choiseNumberOne, choiseNumberTwo, 0.5);
                        Console.WriteLine(Load("data.bin"));
                        break;
                    case 2: SaveFunc(funcs[1], "data.bin", choiseNumberOne, choiseNumberTwo, 0.5);
                        Console.WriteLine(Load("data.bin"));
                        break ;
                    case 3: SaveFunc(funcs[2], "data.bin", choiseNumberOne, choiseNumberTwo, 0.5);
                        Console.WriteLine(Load("data.bin"));
                        break;
                }
                    
                    
                    } while (choiseFunc!=0);
            
            
            Console.ReadKey();
        }
    }
}
