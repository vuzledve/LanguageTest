using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Tests
{
    internal class Test3 : Base.BaseTest
    {
        public override void Start()
        {

            int x = 1;
            int y = 2;
            int z = x / y;
            Console.WriteLine($"z = {z}");
           



        }
        public override void Info()
        {


        }
    }
}
