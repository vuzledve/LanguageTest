using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Tests.Base
{
    internal class BaseTest
    {
        private int WindowSize = 100;
        public string Title(string text)
        {
            string answer = "";
            for (int i = 0; i<(WindowSize - text.Length)/2; i++)
                answer += @"\";

            return answer;
        }

        public virtual void Start()
        {

        }
    }
}
