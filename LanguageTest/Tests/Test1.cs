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
        public override string Conclusion()
        {
            return "CLR разрешает привести тип объекта к его собственному типу или любому из его базовых типов. " +
                    "Если явно привести базовый класс к наследнику B b = (B)(new A()), " +
                    "то такой код скомпилируется, однако в рантайме выдаст ошибку. " +
                    "Другими словами, если CLR не хватает инфы заполнить объект приводимым к нему объектом, то выпадает ошибка.";
        }

        public override string MoreInfo()
        {
            return "";
           /* return "Одна из важнейших особенностей CLR — безопасность типов (type safety). Во время " +
                   " выполнения программы среде CLR всегда известен тип объекта. Программист всегда" +
                   " может точно определить тип объекта при помощи метода GetType.Поскольку это" +
                   " невиртуальный метод, никакой тип не сможет сообщить о себе ложные сведения." +
                   " Например, тип Employee не может переопределить метод GetType, чтобы тот вернул" +
                   " тип SuperHero." +
                   " При разработке программ часто прибегают к приведению объекта к другим типам." +
                   " CLR разрешает привести тип объекта к его собственному типу или любому из его" +
                   " базовых типов.В каждом языке программирования приведение типов реализовано по-своему.Например, в C# нет специального синтаксиса для приведения типа" +
                   " объекта к его базовому типу, поскольку такое приведение считается безопасным" +
                   " Приведение типов 125" +
                   " неявным преобразованием. Однако для приведения типа к производному от него" +
                   " типу разработчик на C# должен ввести операцию явного приведения типов — неявное преобразование приведет к ошибке. Следующий пример демонстрирует" +
                   " приведение к базовому и производному типам";*/
        }

        public Test1()
        {
            this.title = "Приведение типов.";
        }
    }
}
