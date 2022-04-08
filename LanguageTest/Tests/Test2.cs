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
            public  void Foo()
            {
                Console.WriteLine("Class A");
                Console.WriteLine();
            }
           
        }

        public class B : A
        {
            public void Foo()
            {
                Console.WriteLine("Class B");
                Console.WriteLine();
            }
        }
        public class C : A
        {
            public new void Foo()
            {
                Console.WriteLine("Class C");
                Console.WriteLine();
            }
        }


        public override void Start()
        {
            
            B b1 = new B();
            Console.WriteLine("B b1 = new B();");
            b1.Foo();

            C c2 = new C();
            Console.WriteLine("C c2 = new C();");
            c2.Foo();

            A a3 = new A();
            Console.WriteLine("A a3 = new A();");
            a3.Foo();



        }
        public override void Info()
        {
            

        }

        public Test2()
        {
            this.title = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa bbbb ccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc dddddddddddddddddddddddddddddddddddddddddddddddddddddddddd rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww";
        }
    }
}
