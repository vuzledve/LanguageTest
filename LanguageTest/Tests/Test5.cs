using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Tests
{
    internal class Test5 : Base.BaseTest //https://metanit.com/sharp/tutorial/3.12.php
    {
        #region Logic

        //Угловые скобки в описании class Person<T> указывают, что класс является обобщенным,
        //а тип T, заключенный в угловые скобки, будет использоваться этим классом. 
        //T в угловых скобках еще называется универсальным параметром
        class Person<T, K>
        {
            public static T? code;
            public T Id { get; }
            public K Password { get; set; }
            public string Name { get; }
            public Person(T id, K password, string name)
            {
                Id = id;
                Name = name;
                Password = password;
            }
        }
        void Swap<T>(ref T x, ref T y) //можно также создавать обобщенные методы, которые точно также будут использовать универсальные параметры
        {
            T temp = x;
            x = y;
            y = temp;
        }

        #endregion
        public override void Start()
        {
            Person<int, string> tom = new Person<int, string>(123, "tomPass", "Tom");
            Person<string, string> bob = new Person<string, string>("abc", "bobPass", "Bob");
            Console.WriteLine(tom.Id);          // 123
            Console.WriteLine(tom.Password);    // tomPass
           
            Person<int, string>.code = 1234;
            Person<string, string>.code = "meta";
            Person<bool, bool>.code = true;

            Console.WriteLine(Person<int, string>.code);       // 1234 При типизации обобщенного класса определенным типом будет создаваться свой набор статических членов
            Console.WriteLine(Person<string, string>.code);   // meta
            Console.WriteLine(Person<bool, bool>.code);   // True


            int x = 7;
            int y = 25;
            Swap<int>(ref x, ref y); // или так Swap(ref x, ref y);
            Console.WriteLine($"x={x}    y={y}");   // x=25   y=7
            Swap(ref x, ref y);                
            Console.WriteLine($"x={x}    y={y}");   // x=7   y=25

            //Swap(x, y);  CTE: Аргумент должен передаваться с ключевым словом "ref"
            //Swap<int>(x, y); CTE: Аргумент должен передаваться с ключевым словом "ref"

        }
        public override void Info()
        {
            Console.WriteLine("class Person<T, K>          //определяем класс Person как обощенный.<T> - универсальный параметр");
            Console.WriteLine("{");
            Console.WriteLine("    public static T? code;                       // Переменная типа T?");
            Console.WriteLine("    public T Id { get; };                        // Переменная типа T");
            Console.WriteLine("    public K Password { get; set; };             // Переменная типа K");
            Console.WriteLine("    public string Name { get; };                 // Переменная типа string");
            Console.WriteLine("    public Person(T id, K password, string name) // Конструктор");
            Console.WriteLine("    {");
            Console.WriteLine("        Id = id;");
            Console.WriteLine("        Name = name;");
            Console.WriteLine("        Password = password;");
            Console.WriteLine("    }");
            Console.WriteLine("}");

            Console.WriteLine();

            Console.WriteLine("void Swap<T>(ref T x, ref T y)         //обобщенный метод, использующий универсальные параметры");
            Console.WriteLine("{");
            Console.WriteLine("    T temp = x;");
            Console.WriteLine("    x = y;");
            Console.WriteLine("    y = temp;");
            Console.WriteLine("}");

            Console.WriteLine();

            Console.WriteLine("Person<int, string> tom = new Person<int, string>(123, \"tomPass\", \"Tom\"); //");
            Console.WriteLine("//tom.Id = 123");
            Console.WriteLine("//tom.Password = tomPass");
            Console.WriteLine();
            Console.WriteLine("Person<string, string> bob = new Person<string, string>(\"abc\", \"bobPass\", \"Bob\");");
            Console.WriteLine("//bob.Id = abc");
            Console.WriteLine("//bob.Password = bobPass");
            Console.WriteLine();
            Console.WriteLine("Person<int, string>.code = 1234;             // При типизации обобщенного класса ");
            Console.WriteLine("Person<string, string>.code = \"meta\";        // определенным типом будет");   
            Console.WriteLine("Person<bool, bool>.code = true;              // создаваться свой набор статических членов");
            Console.WriteLine("//Person<int, string>.code = 1234");
            Console.WriteLine("//Person<string, string>.code = meta");
            Console.WriteLine("//Person<bool, bool>.code = True");
           
            
            Console.WriteLine();
            
            Console.WriteLine("int x = 7;");
            Console.WriteLine("int y = 25;");
            Console.WriteLine("Swap<int>(ref x, ref y);  // x=25   y=7. При вызове можно писать <...>");
            Console.WriteLine("Swap(ref x, ref y);       // x=7   y=25. А можно и не писать ЕСЛИ ПЕРЕДАЕМ ЧЕРЕЗ ref");
            Console.WriteLine("Swap(x, y);               //CTE: Аргумент должен передаваться с ключевым словом \"ref\" ");
            Console.WriteLine("Swap<int>(x, y);          //CTE: Аргумент должен передаваться с ключевым словом \"ref\" ");

        }
        public override string Conclusion()
        {
            return "Определить класс как обобщенный class Person<T, K> {...}. " +
                   "В конструкторе определяем типы T и K  public Person(T id, K password, ...). " +
                   "Создать объект: ... = new Person<тип1, тип2>(переменная типа1, переменная типа2, ...) " +
                   "Для каждого набора универсальных параметров будут создаваться свои статические переменные " +
                   "(Как будто создаются разные классы с одинаковым именем). " +
                   "В обобщенный метод параметры нужно передавать только по ссылке. " +
                   "Объявление метода: void Swap<T>(ref T x, ref T y). " +
                   "Вызов метода: Swap<int>(ref x, ref y) - в скобках указываем конкретный тип.";
        }

        public override string MoreInfo()
        {
            return "";
        }

        public Test5()
        {
            this.title = "Обобщенные типы  (generics)";
        }
    }
}
