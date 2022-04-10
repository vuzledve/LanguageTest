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
            int y = 3;
            int z = x / y; //результат равен 2

            double k = 10 / 4; //результат равен 2

            double a = 10;
            double b = 3;
            double c = a / b; // 3.33333333

            double o = 10.0;
            double p = o % 4; //результат равен 2

            int aw = 3;
            int bw = 5;
            int cw = 40;
            int dw = --cw - bw * aw;    // aw=3  bw=5  cw=39  d=24

            int n = 10 / 5 * 2; //4
            int y1 = 1, y2 = 2;
            int at = 3;
            int bt = 5;
            int v = --at + bt;

            double doub = 0;
            for (int i = 0; i < 10; i++)
                doub += 0.1;
            decimal dec = 0m;
            for (int i = 0; i < 10; i++)
                dec += 0.1m;

            Console.WriteLine($"z = {z}");
            Console.WriteLine($"k = {k}");
            Console.WriteLine($"c = {c}");
            Console.WriteLine($"n = {n}");
            Console.WriteLine($"p = {p}");
            Console.WriteLine($"dw = {dw}");
            Console.WriteLine($"at = {at}");
            Console.WriteLine($"v = {v}");
            Console.WriteLine($"doub = {doub}");
            Console.WriteLine($"dec = {dec}");
        }
        public override void Info()
        {
            Console.WriteLine("int x = 5 / 3;               //x = 1 (остаток удаляется)");
            Console.WriteLine("double y = 10 / 4;           //y = 2 (остаток удаляется т.к. 10 и 4 приводятся к int)");
            Console.WriteLine("double z = (double)10 / 4;   //z = 2,5");
            Console.WriteLine("double p = 10 % 4.0;         //p = 2 (остаток от деления)");
            Console.WriteLine("");
            Console.WriteLine("int a1 = 3, a2 = 3;");
            Console.WriteLine("int b1 = 5, b2 = 5;");
            Console.WriteLine("int v = --a + b;             //a1 = 2; v = 7; при префиксе сначала вып. преф., после - остальное");
            Console.WriteLine("int f = a-- + b;             //a2 = 2; f = 8; при постфиксе сначала вып. основн., после - постф.");
            Console.WriteLine("");
            Console.WriteLine("double doub = 0;");
            Console.WriteLine("for (int i = 0; i < 10; i++)");
            Console.WriteLine("    doub += 0.1;             //doub = 0.9(9)");
            Console.WriteLine("");
            Console.WriteLine("decimal dec = 0m;");
            Console.WriteLine("for (int i = 0; i < 10; i++)");
            Console.WriteLine("    dec += 0.1m;             //dec = 1.0");
        }
        public override string Conclusion()
        {
            return "При делении int округление идет всегда в меньшую сторону (дробная часть удаляется). " +
                "Double работает быстрее decimal, но в нем могут возникать ошибки округления. " +
               @"Для объявления переменной decimal обязательно нужно прописывать m\M в конце значения (1.1m). " +
               "При префиксе (--i) сначала выполняется i = i - 1, а после выражение, в котором находится --i. " +
               "При постфиксе (i--) сначала выполняется выражение, в котором находится i, а после i = i - 1. ";
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
