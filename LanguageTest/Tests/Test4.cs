using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Tests
{
    
    internal class Test4 : Base.BaseTest
    {

        public  class A
        {
            public virtual void Foo()
            {
                Console.WriteLine("A.Foo");
            }
            public void Voo()
            {
                Console.WriteLine("A.Voo");
            }
        }

        public class B : A
        {
            //public virtual void Foo() //new
            public override void Foo()
            {
                Console.WriteLine("B.Foo");
            }
            new public void Voo() //override - невозможно переопределить наследуемый член "Test4.A.Voo()", так как он не помечен как virtual, abstract или override.
            {
                Console.WriteLine("B.Voo");
            }
            public void Zoo()
            {
                Console.WriteLine("B.Zoo");
            }
        }

        public override void Start()
        {
            A a1 = new A(); 
            a1.Foo(); //a
            a1.Voo(); //a

            B b1 = new B();
            b1.Foo(); //b
            b1.Voo(); //b
            b1.Zoo(); //b

            A a2 = new B(); 
            a2.Foo(); //b
            a2.Voo(); //a
            //a2.Zoo();//- A не содержит определения "Zoo"

        }
        public override void Info()
        {
            Console.WriteLine("public class A                           //базовый класс");
            Console.WriteLine("{");
            Console.WriteLine("    public virtual void Foo()            //virtual метод");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine(\"A.Foo\");");
            Console.WriteLine("    }");
            Console.WriteLine();  
            Console.WriteLine("    public void Voo()                    //обычный метод");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine(\"A.Voo\");");
            Console.WriteLine("    }");
            Console.WriteLine("}");

            Console.WriteLine();

            Console.WriteLine("public class B : A                       //класс - наследник");
            Console.WriteLine("{");
            Console.WriteLine("    public override void Foo()           //override метод");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine(\"B.Foo\");");
            Console.WriteLine("    }");
            Console.WriteLine();
            Console.WriteLine("    new public void Voo()                //new метод (скрытие реализации базового)");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine(\"B.Voo\");");
            Console.WriteLine("    }");
            Console.WriteLine();
            Console.WriteLine("    public void Zoo()                    //обычный метод, не прописанный в базовом классе");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine(\"B.Zoo\");");
            Console.WriteLine("    }");
            Console.WriteLine("}");

            Console.WriteLine();

            Console.WriteLine("A a1 = new A();  //обычный объект класса А");
            Console.WriteLine("a1.Foo();        //А");
            Console.WriteLine("a1.Voo();        //А");
            Console.WriteLine();
            Console.WriteLine("B b1 = new B();  //обычный объект класса B");
            Console.WriteLine("b1.Foo();        //B");
            Console.WriteLine("b1.Voo();        //B");
            Console.WriteLine("b1.Zoo();        //B");
            Console.WriteLine();
            Console.WriteLine("A a2 = new B();  //объект класса B приводим к типу А");
            Console.WriteLine("a2.Foo();        //B. Foo переопределен в B, поэтому при приведении В к А у нас функционал B");
            Console.WriteLine("a2.Voo();        //A. Voo указан в В как new, значит реализация может сильно отличаться, значит используем фукционал А");
            Console.WriteLine("a2.Zoo();        //CTE: \"A\" не содержит определения \"Zoo\". Нельзя вызвать обычный метод B."); 
        }
        public override string Conclusion()
        {
            return "Если метод virtual, то его можно переопределить override. При этом если объект класса - наследника " +
                "привести к базовому -> функционал у virtual методов будет из класса - наследника. " +
                "Методы класса-наследника у приведенного объекта вызвать нельзя(CTE). Методы new не считаются override " +
                "и вызывается базовый virtual метод. Если в наследнике написать новый virtual вместо override," +
                "то будет считаться что он new. Методы vurtual можно вызывать у объекта базового класса если он не был " +
                "приведенным из наследника.";

        }
        public override string MoreInfo()
        {
            return "";
        }

        public Test4()
        {
            this.title = @"Vurtual \ override";
        }
    }
}
