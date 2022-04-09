using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Tests
{
    internal class Test2 : Base.BaseTest
    {
        public class A
        {
            public readonly static int minAge = 1;      //статическая переменная
            public const string typeName = "A_name";    //константа
            public string Name { get; set; }            //свойство
            public  void Foo()                          //метод
            {
                Console.WriteLine("Class A");
            }
           
        }

        public class B : A //all new
        {
            public new readonly static int minAge = 18;
            public new const string typeName = "B_name";

            public new string Name
            {
                get => $"Mr./Ms. {base.Name}"; 
                set => base.Name = value;

            }

            public new void Foo()
            {
                Console.WriteLine("Class B");
            }
        }

        public class C : A
        {
            public void Foo()
            {
                Console.WriteLine("Class C");
            }
        }


        public override void Start()
        {
            new A().Foo();
            new B().Foo();
            new C().Foo();

            //C c2 = new C();
            //Console.WriteLine("C c2 = new C();");
            //c2.Foo();

            //A a3 = new A();
            //Console.WriteLine("A a3 = new A();");
            //a3.Foo();
            Console.WriteLine("Class A");
            Console.WriteLine(A.minAge);     // 1
            Console.WriteLine(A.typeName);   // A_name
            Console.WriteLine("Class B");
            Console.WriteLine(B.minAge);     // 18
            Console.WriteLine(B.typeName);   // B_name
        }
        public override void Info()
        {
            Console.WriteLine("public class A                                  //базовый класс");
            Console.WriteLine("{");
            Console.WriteLine("    public readonly static int minAge = 1;      //статическая переменная");
            Console.WriteLine("    public const string typeName = \"A_name\";    //константа");
            Console.WriteLine("    public string Name { get; set; }            //свойство");
            Console.WriteLine("    public void Foo()                           //метод");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine(\"Class A\");");
            Console.WriteLine("    }");
            Console.WriteLine("}");

            Console.WriteLine();

            Console.WriteLine("public class B : A                                      //класс - наследник");
            Console.WriteLine("{");
            Console.WriteLine("    public new readonly static int minAge = 18;         //new реализация статической переменной");
            Console.WriteLine("    public new const string typeName = \"B_name\";        //new реализация константы");
            Console.WriteLine("    public new string Name                              //new реализация свойства");
            Console.WriteLine("    {");
            Console.WriteLine("        get => $\"Mr./ Ms. {base.Name}\";");
            Console.WriteLine("        set => base.Name = value;");
            Console.WriteLine("    }");
            Console.WriteLine("    public new void Foo()                               //new реализация метода");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine(\"Class B\");");
            Console.WriteLine("    }");
            Console.WriteLine("}");

            Console.WriteLine();

            Console.Write("new A().Foo();\t\t\t\t");
            new A().Foo();
            Console.Write("Console.WriteLine(A.minAge);\t\t");
            Console.WriteLine(A.minAge);
            Console.Write("Console.WriteLine(A.typeName);\t\t");
            Console.WriteLine(A.typeName);

            Console.WriteLine();

            Console.Write("new B().Foo();\t\t\t\t");
            new B().Foo();
            Console.Write("Console.WriteLine(B.minAge);\t\t");
            Console.WriteLine(B.minAge);
            Console.Write("Console.WriteLine(B.typeName);\t\t");
            Console.WriteLine(B.typeName);
        }
        public override string Conclusion()
        {
            return null;
        }
        public Test2()
        {
            this.title = "Скрытие методов и свойств с помощью ключевого слова new.";
        }
    }
}
