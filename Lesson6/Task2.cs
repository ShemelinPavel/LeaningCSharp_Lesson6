/*

Shemelin Pavel

Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум. Использовать массив (или список) делегатов, в котором хранятся различные функции.
б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр (с использованием модификатора out). 

*/

using System;
using System.IO;
using System.Collections.Generic;
using LeaningCSharp_ClassLibrary;

namespace Lesson6
{
    partial class Tasks
    {

        static List<Delegate> delegatesList = new List<Delegate>();

        static void delegatesListInit()
        {
            delegatesList.Add(new Delegate (double x) { return (x * x) - (50 * x) + 10; } );
        }

        public static double SinDouble(double x)
        {
            return Math.Pow(Math.Sin(x* Math.PI / 180), 2);
        }

        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }
        public static void SaveFunc(string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                //bw.Write(SinDouble(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        public static double[] Load(string fileName, out double minValue)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            minValue = double.MaxValue;
            double currentValue;
            double[] functionValues = new double[(fs.Length / sizeof(double))];
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                currentValue = bw.ReadDouble();

                functionValues[i] = currentValue;
                if (currentValue < minValue) minValue = currentValue;
            }
            bw.Close();
            fs.Close();

            return functionValues;
        }

        public static void Task2()
        {
            ServingStaticClass.PrintTaskWelcomeScreen("Вы выбрали задачу поиска минимума функции\n");

            SaveFunc("data.bin", -100, 100, 0.5);
            double[] Values = Load("data.bin", out double minValue);

            ServingStaticClass.Print($"{minValue.ToString()}\n");
            ServingStaticClass.Print("");


            ServingStaticClass.Pause("");
        }
    }
}
