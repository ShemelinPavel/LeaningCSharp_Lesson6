/*

Shemelin Pavel 

1. Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double).
Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

 */

using System;
using LeaningCSharp_ClassLibrary;

namespace Lesson6
{
    partial class Tasks
    {
        public delegate double Fun(double a, double x);

        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("------ A ------- X ------ Y ---------");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, x, F(a, x));
                x += 1;
            }
            Console.WriteLine("-------------------------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double a, double x)
        {
            return a * x * x;
        }

        // Создаем метод для передачи его в качестве параметра в Table
        public static double MySin(double a, double x)
        {
            //(Math.PI / 180) - преобразование радиан в градусы
            return a * Math.Sin(x * Math.PI / 180);
        }

        public static void Task1()
        {
            ServingStaticClass.PrintTaskWelcomeScreen("Вы выбрали вывод таблицы функций\n");

            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc(A*X*X = Y):");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table(new Fun(MyFunc), 3, -2, 2);

            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            // Упрощение(c C# 2.0).Делегат создается автоматически.            
            Table(MyFunc, 3, -2, 2);
            Console.WriteLine("Таблица функции A*(X^2) = Y:");
            // Упрощение(с C# 2.0). Использование анонимного метода
            Table(delegate (double a, double x) { return a * x * x; }, 3, 0, 3);

            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Console.WriteLine("Таблица функции A*Sin(X) = Y:");
            Table(MySin, 3, -2, 2);

            // Упрощение(с C# 2.0). Использование анонимного метода
            Console.WriteLine("Еще раз та же таблица, но вызов анонимным методом");
            Table(delegate (double a, double x) { return a * Math.Sin(x * Math.PI / 180); }, 3, -2, 2);

            ServingStaticClass.Print("\n");
            ServingStaticClass.Pause("");
        }
    }
}
