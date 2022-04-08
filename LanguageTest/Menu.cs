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
            

            while (true)
            {
                PrintHeader("Главное меню");
                Console.WriteLine("1.Cписок тем");
                Console.WriteLine("2.Поиск темы");
                Console.WriteLine("3.Настройки");
                Console.WriteLine("4.TO DO");
                PrintFooter();
                //while (true)
                //{
                //    Console.WriteLine("YOUR INPUT: " + ReadIntFromConsole(1, 100).ToString());
                //}
                //while (true)
                //    SearchTopic();

                switch (ReadIntFromConsole(1, 4))
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
        }

        private static void TopicsList()
        {
            PrintHeader("Список всех тем");

            for (int i = 0; i < allTests.Count; i++)
                Console.WriteLine((i + 1).ToString() + ". " + allTests[i].title);

            PrintFooter();
            int topicNum = ReadIntFromConsole(1, allTests.Count);

            PrintTest(topicNum);
           
            return;
        }

        private static void SearchTopic()
        {
            PrintHeader("Поиск темы");
            bool correctInput = false;

            while (!correctInput)
            {
                Console.WriteLine($"\nВведите подстроку для поиска или оставьте строку пустой для перехода в главное меню: ");
                try
                {
                    string? input = Console.ReadLine();
                    if (input == null || input == "")
                        correctInput = true;
                    else
                    {
                        int correct = 0;
                        for (int i = 0; i < allTests.Count; i++)
                            if (allTests[i].title != null)
                                if (allTests[i].title.ToLower().Contains(input.ToLower()))
                                {
                                    Console.WriteLine((i + 1).ToString() + ". " + allTests[i].title);
                                    correct++;
                                }
                        Console.WriteLine("Найдено совпадений: " + correct);
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка ввода.");
                    correctInput = false;
                }
            }

            return;
        }

        public static void PrintTest(int topicNum)
        {                    
            PrintHeader((topicNum.ToString() + ". " + allTests[topicNum - 1].title).ToString());
            allTests[topicNum - 1].Start();
            PrintFooter();

            //  3/ 10' ' если не влезает то след строка
            //..<- -> следующая тема\предыдущая тема, и кнопку назад
            bool correctInput = false;

            while (!correctInput)
            {
                if (topicNum != 1)
                    Console.WriteLine("Предыдущая тема\t<-");
                else
                    Console.WriteLine("Последняя тема \t<-");
                if (topicNum != allTests.Count)
                    Console.WriteLine("Следующая тема \t->");
                else
                    Console.WriteLine("Первая тема    \t<-");
                Console.WriteLine("Главное меню   \tN");

                try
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    Console.WriteLine();

                    switch (input.Key)
                    {
                        //case ConsoleKey.Escape:
                        case ConsoleKey.N:
                            correctInput = true;                         
                            break;
                        case ConsoleKey.LeftArrow: //<-

                            correctInput = true;
                            if (topicNum != 1)
                                PrintTest(topicNum - 1);       //тут рекурсия (в теории бесконечная), TO DO убрать 
                            else //(topicNum == 1)
                                PrintTest(allTests.Count); //тут рекурсия (в теории бесконечная), TO DO убрать 
                            break;

                        case ConsoleKey.RightArrow: //->

                            correctInput = true;
                            if (topicNum != allTests.Count)
                                PrintTest(topicNum + 1);       //тут рекурсия (в теории бесконечная), TO DO убрать 
                            else //(topicNum == allTests.Count)
                                PrintTest(1);                  //тут рекурсия (в теории бесконечная), TO DO убрать 
                            break;

                        default: 
                            Console.WriteLine("Ошибка ввода. Введенный символ не совпал ни с одним из указанных.");
                            correctInput = false;
                            break;
                    }                  
                }
                catch
                {
                    Console.WriteLine("Ошибка ввода.");
                    correctInput = false;
                }
            }
        }

        private static void PrintHeader(string title)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("///                                                                                                              ///");
            string[] titleWords = title.Split(' ');
            for (int i = 0; i < titleWords.Length; i++)
            {
                string titleLine = titleWords[i];
                while (titleLine.Length < 90)
                    if (i + 1 < titleWords.Length)
                    {
                        if (titleLine.Length + titleWords[i + 1].Length > 89)
                        {
                            PrintTitleLine(titleLine);
                            break;
                        }
                        else
                        {
                            titleLine += " " + titleWords[i + 1];
                            i++;
                        }
                    }
                    else
                    {
                        PrintTitleLine(titleLine);
                        break;
                    }

                //while (true)
                //    if (i + 1 < titleWords.Length || titleLine.Length + titleWords[i + 1].Length > 90)
                //    {
                //        PrintTitleLine(titleLine);
                //        break;
                //    }
                //    else
                //    {
                //        titleLine += titleWords[i + 1];
                //        i++;
                //    }
            }

            Console.WriteLine("///                                                                                                              ///");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        private static void PrintFooter()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            //116 6 20 -->90
        }

        private static void PrintTitleLine(string line)
        {
            Console.Write("///" + "          ");
            for (int i = 0; i < 45-(line.Length/2); i++)
                Console.Write(' ');
            Console.Write(line);
            for (int i = 0; i < 90 - (45 - (line.Length / 2)) - line.Length; i++)
                Console.Write(' ');
            Console.WriteLine("          " + "///");
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
    }
}
