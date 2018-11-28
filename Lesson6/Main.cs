using System;
using LeaningCSharp_ClassLibrary;

namespace Lesson6
{
    class Lesson6
    {
        static void Main(string[] args)
        {

            //задачи собраны в отдельный класс
            Tasks tasks = new Tasks();

            MainMenu menu = new MainMenu(new string[] { "Вывод таблицы функций", "Поиск минимума функции", "*", "*", "*" });

            menu.Show();

            while (true)
            {
                ConsoleKeyInfo userChooseKey = Console.ReadKey(true);
                bool resulTaskCall = menu.GotoTask(tasks, userChooseKey.Key);

                menu.Show();

            }


        }
    }
}
