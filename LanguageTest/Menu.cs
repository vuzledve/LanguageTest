using LanguageTest.Tests;
using LanguageTest.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest
{
    static class Menu //https://www.videosharp.info/article/sharp/id=513
    {
        const int windowSize = 116;
        const char windowFrameSymbol = '-';
        const int marginSize = 10;
        const char marginSymbol = ' ';
        const int frameSize = 3;
        const char frameSymbol = '/';

        static List <BaseTest> allTests = new List <BaseTest> ();

        public static void Start()
        {
            allTests.Add(new Test1());
            allTests.Add(new Test2());
            allTests.Add(new Test3());
            allTests.Add(new Test4());
            //allTests.Add(new Test5());
            //allTests.Add(new Test6());
            //allTests.Add(new Test7());
            //allTests.Add(new Test8());
            //allTests.Add(new Test9());
            //allTests.Add(new Test10());
            //allTests.Add(new Test11());
            //allTests.Add(new Test12());
            //allTests.Add(new Test13());
            //allTests.Add(new Test14());
            //allTests.Add(new Test15());
            //allTests.Add(new Test16());
            //allTests.Add(new Test17());
            //allTests.Add(new Test18());
            //allTests.Add(new Test19());
            //allTests.Add(new Test20());
          
            MainWindow();
        }

        public static void MainWindow()
        {
            

            while (true)
            {
                PrintHeader("Главное меню");
                Console.WriteLine("1.Cписок тем");
                Console.WriteLine("2.Поиск темы");
                Console.WriteLine("3.Запуск теста");
                Console.WriteLine("4.TO DO");
                Console.WriteLine("5.Настройки");
                PrintFooter();
                //while (true)
                //{
                //    Console.WriteLine("YOUR INPUT: " + ReadIntFromConsole(1, 100).ToString());
                //}
                //while (true)
                //    SearchTopic();
              
                switch (ReadIntFromConsole(1, 5))
                {
                    case 1:
                        TopicsList();
                        break;
                    case 2:
                        SearchTopic();
                        break;
                    case 3:
                        TestsList();
                        break;
                    case 4:
                        //TO DO
                        break;
                    case 5:
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

            PrintTest(topicNum, false);
           
            return;
        }

        private static void TestsList()
        {
            PrintHeader("Запуск теста (метод Start())");

            for (int i = 0; i < allTests.Count; i++)
                Console.WriteLine((i + 1).ToString() + ". " + allTests[i].title);

            PrintFooter();
            Console.WriteLine("Введите 0 для возврата в главное меню.");
            int topicNum = ReadIntFromConsole(0, allTests.Count);

            StartTest(topicNum);

            return;
        }
        public static void StartTest(int topicNum)//запуск теста
        {
            PrintHeader((topicNum.ToString() + ". " + allTests[topicNum - 1].title).ToString() +". ТЕСТИРОВАНИЕ.");
            allTests[topicNum - 1].Start();
            PrintFooter();

            //  3/ 10' ' если не влезает то след строка
            //..<- -> следующая тема\предыдущая тема, и кнопку назад
            bool correctInput = false;

            while (!correctInput)
            {
                if (topicNum != 1)
                    Console.WriteLine("Предыдущая тема\t\t\t<-");
                else
                    Console.WriteLine("Последняя тема \t\t\t<-");
                if (topicNum != allTests.Count)
                    Console.WriteLine("Следующая тема \t\t\t->");
                else
                    Console.WriteLine("Первая тема    \t\t\t->");
                
                Console.WriteLine("Главное меню   \t\t\tN");

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
                                StartTest(topicNum - 1);        //тут рекурсия (в теории бесконечная), TO DO убрать 
                            else //(topicNum == 1)
                                StartTest(allTests.Count);      //тут рекурсия (в теории бесконечная), TO DO убрать 
                            break;

                        case ConsoleKey.RightArrow: //->

                            correctInput = true;
                            if (topicNum != allTests.Count)
                                StartTest(topicNum + 1);        //тут рекурсия (в теории бесконечная), TO DO убрать 
                            else //(topicNum == allTests.Count)
                                StartTest(1);                   //тут рекурсия (в теории бесконечная), TO DO убрать 
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
                    if (input == null || input == "") //isNullOrEmpty
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

        public static void PrintTest(int topicNum, bool printDetails)//принт ВСЕЙ страницы теста
        {                    
            PrintHeader((topicNum.ToString() + ". " + allTests[topicNum - 1].title).ToString());
            allTests[topicNum - 1].Info();
            PrintConclusion(allTests[topicNum - 1].Conclusion());
            if (printDetails)
                PrintDetails();
            PrintFooter();

            //  3/ 10' ' если не влезает то след строка
            //..<- -> следующая тема\предыдущая тема, и кнопку назад
            bool correctInput = false;

            while (!correctInput)
            {
                if (topicNum != 1)
                    Console.WriteLine("Предыдущая тема\t\t\t<-");
                else
                    Console.WriteLine("Последняя тема \t\t\t<-");
                if (topicNum != allTests.Count)
                    Console.WriteLine("Следующая тема \t\t\t->");
                else
                    Console.WriteLine("Первая тема    \t\t\t->");
                if (!printDetails)
                    Console.WriteLine("Дополнительная информация\tI");
                Console.WriteLine("Главное меню   \t\t\tN");

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
                        case ConsoleKey.I:
                            correctInput = true;
                            PrintTest(topicNum, true);        //тут рекурсия (в теории бесконечная), TO DO убрать 
                            break;
                        case ConsoleKey.LeftArrow: //<-

                            correctInput = true;
                            if (topicNum != 1)
                                PrintTest(topicNum - 1, false);        //тут рекурсия (в теории бесконечная), TO DO убрать 
                            else //(topicNum == 1)
                                PrintTest(allTests.Count, false);      //тут рекурсия (в теории бесконечная), TO DO убрать 
                            break;

                        case ConsoleKey.RightArrow: //->

                            correctInput = true;
                            if (topicNum != allTests.Count)
                                PrintTest(topicNum + 1, false);        //тут рекурсия (в теории бесконечная), TO DO убрать 
                            else //(topicNum == allTests.Count)
                                PrintTest(1, false);                   //тут рекурсия (в теории бесконечная), TO DO убрать 
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
        private static void PrintDetails() //принт большого конспекта к тесту
        {
            
        }
        private static void PrintConclusion(string conclusion) //принт вывода\заметок к тесту
        {
            if (!string.IsNullOrEmpty(conclusion))
            {
                Console.WriteLine();
                Console.WriteLine();
                PrintWindowFrame();
                PrintLineInFrame("Conclusion:");
                PrintWindowFrame();
                Console.WriteLine();

                string[] conclusionWords = conclusion.Split(' ');
                for (int i = 0; i < conclusionWords.Length; i++)
                {
                    string titleLine = conclusionWords[i];
                    while (titleLine.Length <= windowSize)
                        if (i + 1 < conclusionWords.Length) //если текущее слово не последнее
                        {
                            if (titleLine.Length + conclusionWords[i + 1].Length > windowSize - 1) //если длина уже сущ строки + добавляемой больше окна
                            {
                                Console.WriteLine(titleLine); //прнт строки + выход из while
                                break;
                            }
                            else //если длины меньше
                            {
                                titleLine += " " + conclusionWords[i + 1]; //складываем строки
                                i++;
                            }
                        }
                        else //если тек слово последнее
                        {
                            Console.WriteLine(titleLine);
                            break;
                        }

                }

                Console.WriteLine();
            }
        }
        private static void PrintHeader(string title)//принт заголовка окна
        {
            Console.Clear();
            PrintWindowFrame();
            PrintTopFrame();

            string[] titleWords = title.Split(' ');
            for (int i = 0; i < titleWords.Length; i++)
            {
                string titleLine = titleWords[i];
                while (titleLine.Length <= windowSize - 2 * (marginSize + marginSize))
                    if (i + 1 < titleWords.Length)
                    {
                        if (titleLine.Length + titleWords[i + 1].Length > windowSize - 2 * (marginSize + marginSize) - 1)
                        {
                            PrintLineInFrame(titleLine);
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
                        PrintLineInFrame(titleLine);
                        break;
                    }
            }

            PrintTopFrame();
            PrintWindowFrame();
            Console.WriteLine();
            Console.WriteLine();
        }
     
        private static void PrintFooter() //разделение между контентом и инструкциям к дальнейшим действ. пользователя
        {
            Console.WriteLine();
            Console.WriteLine();
            PrintWindowFrame();  
        }

        private static void PrintLineInFrame(string line) //Console.WriteLine("///  line  ///") 
        {
            PrintLeftMargin();
           
            for (int i = 0; i < (windowSize - 2 * (marginSize + frameSize) - line.Length) / 2; i++) 
                Console.Write(marginSymbol);

            Console.Write(line);
            
            for (int i = 0; i < (windowSize / 2) -  (marginSize + frameSize) - (line.Length/2); i++)
                Console.Write(marginSymbol);
  
            PrintRightMargin();
        }

        private static void PrintTopFrame() //Console.WriteLine("///    ///")
        {
            for (int i = 0; i < frameSize; i++)
                Console.Write(frameSymbol);
            for (int i = 0; i < windowSize - frameSize*2; i++)
                Console.Write(marginSymbol);
            for (int i = 0; i < frameSize; i++)
                Console.Write(frameSymbol);
            Console.WriteLine();
        }
        private static void PrintLeftMargin() //Console.Write("///" + "          ");
        {
            for (int i = 0; i < frameSize; i++)
                Console.Write(frameSymbol);

            for (int i = 0; i < marginSize; i++)
                Console.Write(marginSymbol);
        }

        private static void PrintRightMargin() //Console.Write("          " + "///");
        {
            for (int i = 0; i < marginSize; i++)
                Console.Write(marginSymbol);

            for (int i = 0; i < frameSize; i++)
                Console.Write(frameSymbol);
            Console.WriteLine();
        }

        private static void PrintWindowFrame() //Console.WriteLine("-----------")//строка символов "-" размером windowSize;
        {
            for (int i = 0; i < windowSize; i++)
                Console.Write(windowFrameSymbol);
            Console.WriteLine();
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
