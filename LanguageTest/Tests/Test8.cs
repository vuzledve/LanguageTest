using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Tests
{

    internal class Test8 : Base.BaseTest
    {
        #region Logic

        #endregion
        public override void Start()
        {

        }
        public override void Info()
        {

        }
        public override string Conclusion()
        {
            return "Интерфейс IDisposable объявляет один единственный метод Dispose, " +
                "в котором при реализации интерфейса в классе должно происходить освобождение неуправляемых ресурсов" +
                   "" +
                   "" +
                   "";
        }

        public override string MoreInfo()
        {
            return "";
        }

        public Test8()
        {
            //this.title = "foreach";
            this.title = "Dispose";
        }
    }
}
