using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Tests
{
    internal class Test3 : Base.BaseTest //https://metanit.com/sharp/tutorial/2.3.php
    {
        public override void Start()
        {
            int x = 5;
            int y = 2;
            int z = x / y; //результат равен 2

            double k = 10 / 4; //результат равен 2

            double a = 10;
            double b = 3;
            double c = a / b; // 3.33333333


            int n = 10 / 5 * 2; //4
            Console.WriteLine($"z = {z}");
            Console.WriteLine($"k = {k}");
            Console.WriteLine($"c = {c}");
            Console.WriteLine($"n = {n}");

        }
        public override void Info()
        {


        }
        public override string Conclusion()
        {
            return "";
        }
        public override string MoreInfo()
        {
            return "";
        }
        public Test3()
        {
            this.title = "Арифметические операции";
        }
    }
}
