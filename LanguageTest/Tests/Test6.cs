using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Tests
{
   // delegate void Message();// 1. Объявляем делегат 
    internal class Test6 : Base.BaseTest //https://metanit.com/sharp/tutorial/3.13.php
    {
        #region Logic
        delegate void Message(); // 1. Объявляем делегат 
                                 //делегаты необязательно могут указывать только на методы, которые определены в том же классе, 
                                 //где определена переменная делегата.Это могут быть также методы из других классов и структур.
                                 //делегат можно определять внутри класса Либо вне класса

        void Hello() => Console.WriteLine("Hello");
        void HowAreYou() => Console.WriteLine("How Are You");

        delegate int Operation(int x, int y);
        int Add(int x, int y) => x + y;
        int Multiply(int x, int y) => x * y;
        int Divide(int x, int y) => x / y;
        int Modulo(int x, int y) => x % y;


        //Как было написано выше, методы соответствуют делегату, если они имеют один и тот же возвращаемый тип
        //и один и тот же набор параметров.Но надо учитывать, что во внимание также принимаются модификаторы
        //ref, in и out. Например, пусть у нас есть делегат:

        delegate void SomeDel(int a, double b);
        //Этому делегату соответствует, например, следующий метод:
        void SomeMethod1(int g, double n) { } //сигнатура совпадает
        //А следующие методы НЕ соответствуют:
        double SomeMethod2(int g, double n) { return g + n; } //другой возвращаемый тип
        void SomeMethod3(double n, int g) { } //другой набор параметров
        void SomeMethod4(ref int g, double n) { } //отличаются от параметров делегата, поскольку имеют модификаторы ref и out.
        void SomeMethod5(out int g, double n) { g = 6; }



        delegate T Operation<T, K>(K val); //Обобщенные делегаты

        decimal Square(int n) => n * n;
        int Double(int n) => n + n;


        enum OperationType
        {
            Add, Subtract, Multiply
        }
        #endregion
        public override void Start()
        {
            //delegate void Message(); /внутри функции объявлять нельзя
            Message mes;            // 2. Создаем переменную делегата
            mes = Hello;            // 3. Присваиваем этой переменной адрес метода
            mes();                  // 4. Вызываем метод

            
            
            Operation operation = Add;      // делегат указывает на метод Add
            int result = operation(4, 5);   // фактически Add(4, 5)
            Console.WriteLine(result);      // 9

            operation = Multiply;           // теперь делегат указывает на метод Multiply
            result = operation(4, 5);       // фактически Multiply(4, 5)
            Console.WriteLine(result);      // 20
    
            Operation operation1 = Add;//переменной делегата напрямую присваивался метод.
            Operation operation2 = new Operation(Add);// создание объекта делегата с помощью конструктора, в который передается нужный метод
            //Оба способа равноценны.

            //делегат может указывать на множество методов, которые имеют ту же сигнатуру и возвращаемые тип.
            //Все методы в делегате попадают в специальный список - список вызова или invocation list.
            //И при вызове делегата все методы из этого списка последовательно вызываются.
            //И мы можем добавлять в этот список не один, а несколько методов.
            //Для добавления методов в делегат применяется операция +=:
            Operation manyOperations = Add;
            manyOperations += Multiply;
            //При добавлении делегатов следует учитывать, что мы можем добавить ссылку на один и тот же метод несколько раз,
            //и в списке вызова делегата тогда будет несколько ссылок на один и то же метод.
            //Соответственно при вызове делегата добавленный метод будет вызываться столько раз, сколько он был добавлен:
            manyOperations += Divide;
            manyOperations += Divide;
            manyOperations += Divide;


            manyOperations -= Add;   // удаляем метод Add
            if (manyOperations != null) manyOperations(5,2); // вызывается метод Hello
            //При удалении методов из делегата фактически будет создаватья новый делегат,
            //который в списке вызова методов будет содержать на один метод меньше.

            //При удалении следует учитывать, что если делегат содержит несколько ссылок на один и тот же метод,
            //то операция -= начинает поиск с конца списка вызова делегата и удаляет только первое найденное вхождение.
            //Если подобного метода в списке вызова делегата нет, то операция -= не имеет никакого эффекта.

            //Объединение делегатов
            Message mes1 = Hello;
            Message mes2 = HowAreYou;
            Message mes3 = mes1 + mes2; // объединяем делегаты
            mes3(); // вызываются все методы из mes1 и mes2

            //Вызов делегата
            operation1(5,2); //при вызове для параметров передавались необходимые значения:
            operation1.Invoke(5, 2);//Другой способ вызова делегата представляет метод Invoke():
                                    //Если делегат возвращает некоторое значение, то возвращается значение последнего метода из списка вызова (если в списке вызова несколько методов).

            //Обобщенные делегаты //delegate T Operation<T, K>(K val);
            Operation<decimal, int> squareOperation = Square;
            decimal result1 = squareOperation(5);
            Console.WriteLine(result1);  // 25

            Operation<int, int> doubleOperation = Double;
            int result2 = doubleOperation(5);
            Console.WriteLine(result2);  // 10


            //Делегаты как параметры методов
            // делегаты могут быть параметрами методов.
            // Благодаря этому один метод в качестве параметров может получать действия - другие методы. Например:

            DoOperation(5, 4, Add);         // 9 //передаем функцию
            DoOperation(5, 4, Divide);    // 1
            DoOperation(5, 4, Multiply);    // 20

            void DoOperation(int a, int b, Operation op) //delegate int Operation(int x, int y);
            {
                Console.WriteLine(op(a, b));
            }


            //Возвращение делегатов из метода
            //Также делегаты можно возвращать из методов.
            //То есть мы можем возвращать из метода какое-то действие в виде другого метода.Например:

            Operation operation3 = SelectOperation(OperationType.Add);
            Console.WriteLine(operation3(10, 4));    // 14

            operation = SelectOperation(OperationType.Subtract);
            Console.WriteLine(operation3(10, 4));    // 6

            operation = SelectOperation(OperationType.Multiply);
            Console.WriteLine(operation3(10, 4));    // 40

            Operation SelectOperation(OperationType opType)
            {
                switch (opType)
                {
                    case OperationType.Add: return Add;
                    case OperationType.Subtract: return Subtract;
                    default: return Multiply;
                }
            }

            int Add(int x, int y) => x + y;
            int Subtract(int x, int y) => x - y;
            int Multiply(int x, int y) => x * y;
        }

      
        

        public override void Info()
        {

        }
        public override string Conclusion()
        {
            return "" +
                   "" +
                   "" +
                   "";
        }

        public override string MoreInfo()
        {
            return "";
        }

        public Test6()
        {
            this.title = "Делегаты";
        }
    }
}
