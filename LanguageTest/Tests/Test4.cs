using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Tests
{
    
    internal class Test4 : Base.BaseTest
    {

        public class A
        {
            public virtual void Foo()
            {
                Console.WriteLine("Class A");
                Console.WriteLine();
            }
            public void Goo()
            {
                Console.WriteLine("goo\n");
            }
        }

        public class B : A
        {
            public override void Foo()
            {
                Console.WriteLine("Class B");
                Console.WriteLine();
            }
        }

        public class C : B
        {
            public override void Foo()
            {
                Console.WriteLine("Class C");
                Console.WriteLine();
            }

            public void Boo()
            {
                Console.WriteLine("Class C. Boo\n");
            }
        }


        public override void Start()
        {
            /* B - наследник А, а значит в теории не хватает инфы заполнить B */
            //B b1 = new A(); 
            //b.Foo();
            Console.WriteLine("B b1 = new A();");
            Console.WriteLine("Error. B - наследник А, а значит в теории не хватает инфы заполнить B \n");

            B b2 = new B();
            Console.WriteLine("B b2 = new B();");
            b2.Foo();

            A a1 = new B();
            Console.WriteLine("A a1 = new B();");
            a1.Foo();

            A a2 = new C();
            Console.WriteLine("A a2 = new C();");
            a2.Foo();

            A a3 = new A();
            Console.WriteLine("A a3 = new A();");
            a3.Foo();

            //a2.Boo();
            b2.Goo();
        }
        public override void Info()
        {


        }
        public override void Conclusion()
        {

        }
        public Test4()
        {
            this.title = @"Vurtual \ override";
        }
    }
}
