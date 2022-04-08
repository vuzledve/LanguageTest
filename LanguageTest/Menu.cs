﻿using LanguageTest.Tests;
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
        }

        public static void TopicsList()
        {
            for (int i = 0; i < allTests.Count; i++)
                Console.WriteLine((i+1).ToString()+". "+allTests[i].title);

            ReadConsole();
        }

        public static int ReadConsole()
        {

            return 0;
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
