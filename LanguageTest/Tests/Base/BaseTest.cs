using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Tests.Base
{
    internal abstract class BaseTest
    {
        public string title;

        public abstract void Start();

        public abstract void Info();
        public abstract string Conclusion(); //краткий вывод

        public abstract string MoreInfo(); //информация, взятая из открытых источников
    }
}
