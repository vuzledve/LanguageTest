using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Tests
{
    internal class Test1 : Base.BaseTest
    {
        
        public class A
        {
           
        }

        public class B : A 
        {
           
        }

        public override void Start()
        {
            // B b1 = new A(); CTE: Не удается неявно преобразовать тип "A" в "B"
            B b2 = new B();
            A a1 = new A();
            A a2 = new B();
            // B b3 = (B)a1; RTE: Unable to cast object of type 'A' to type 'B
            // A a3 = new Object(); CTE: Не удается неявно преобразовать тип "object" в "A"
        }

        public override void Info()
        {
            Console.WriteLine("public class A { }");
            Console.WriteLine("public class B : A  { }");
            Console.WriteLine();

            Console.Write("B b1 = new A();\t\t");
            Console.WriteLine("Ошибка компиляции. B - наследник А, а значит в теории не хватает инфы заполнить B.");

            Console.Write("B b2 = new B();\t\t");
            Console.WriteLine("ОК.");

            Console.Write("A a1 = new A();\t\t");
            Console.WriteLine("ОК.");

            Console.Write("A a2 = new B();\t\t");
            Console.WriteLine("ОК.");

            Console.Write("B b3 = (B)a1;\t\t");
            Console.WriteLine("Ошибка рантайма. Unable to cast object of type 'A' to type 'B");

            Console.Write("A a3 = new Object();\t");
            Console.WriteLine("Ошибка компиляции. Не удается неявно преобразовать тип \"object\" в \"A\"");

        }
        public override void Conclusion()
        {

        }
        public Test1()
        {
            this.title = "Приведение типов.";
        }
    }
}
