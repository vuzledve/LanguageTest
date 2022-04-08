using LanguageTest.Tests;
using LanguageTest.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest
{
    static class Menu
    {
        static List <BaseTest> allTests = new List <BaseTest> ();

        public static void Start()
        {
            allTests.Add(new Test1());
            allTests.Add(new Test2());
            allTests.Add(new Test3());

            MainWindow();
        }

        public static void MainWindow()
        {
            Console.WriteLine("1.Cписок тем");
            Console.WriteLine("2.Поиск темы");
            Console.WriteLine("3.Настройки");
            Console.WriteLine("4.TO DO");

            while (true)
            {
                Console.WriteLine("YOUR INPUT: " + ReadIntFromConsole(1, 100).ToString());
            }

            switch (ReadIntFromConsole(1,4))
            {
                case 1:
                    TopicsList();
                    break;
                case 2:
                    SearchTopic();
                    break;
                case 3:
                    //TO DO
                    break;
                case 4:
                    //TO DO
                    break;
            }
        }

       

        private static void TopicsList()
        {
            for (int i = 0; i < allTests.Count; i++)
                Console.WriteLine((i + 1).ToString() + ". " + allTests[i].title);

            ReadIntFromConsole(1, allTests.Count);//TO DO
        }
        private static void SearchTopic()
        {
            //TO DO
        }


        private static int ReadIntFromConsole(int min, int max)
        {
            int answer = 0;
            bool correctInput = false;

            while (!correctInput)
            {
                Console.Write($"\nВведите число [{min} - {max}]: ");
                try
                {
                    answer = Convert.ToInt32(Console.ReadLine());
                    if (answer >= min && answer <= max)
                        correctInput = true;
                    else
                        Console.WriteLine("Ошибка ввода. Число выходит за рамки заданного диапазона.");
                }
                catch 
                {
                    Console.WriteLine("Ошибка ввода. Невозможно преобразовать в Int.");
                    correctInput = false; 
                }
            }
            
            return answer;
        }


        //private int WindowSize = 100;
        //public string Title(string text)
        //{
        //    string answer = "";
        //    for (int i = 0; i < (WindowSize - text.Length) / 2; i++)
        //        answer += @"\";

        //    return answer;
        //}
    }
}
