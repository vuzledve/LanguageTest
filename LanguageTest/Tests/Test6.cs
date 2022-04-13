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

        #region СИГНАТУРА, КОНТРАКТ И СПЕЦИФИКАЦИЯ МЕТОДА
        /* СИГНАТУРА, КОНТРАКТ И СПЕЦИФИКАЦИЯ МЕТОДА
        Определение.Два компонента объявления метода включают сигнатуру метода - имя метода и параметры.

        Пример метода, описанного определения выше:

        calculateAnswer(double, int, double, double)
        Cигнатура метода в сочетании с типом возвращаемого значения называется контрактом метода.

        Спецификация метода может рассматриваться как документация для метода.

        Итог:

                    moveTo(int x, int y)                    — сигнатура

        public void moveTo(int x, int y) throws IOException — контракт

        **                                                  — Спецификация
         * Method - Description of the method
         * @param int x - description of parameter
         * @param int y - description of parameter
         * @return int - description of the return value
         **
         int moveTo(int x, int y) { ...}
        */
        #endregion

        #region Объявление делегатов
        delegate void Message();                    // делегат с сигнатурой? void (void)
        delegate int MathDel(int x, int y);       // int (int, int)
        delegate T GenericDel<T, K>(K val);          // T (K)

        //делегаты необязательно могут указывать только на методы, которые определены в том же классе, 
        //где определена переменная делегата.Это могут быть также методы из других классов и структур.
        //делегат можно определять внутри класса Либо вне класса (но не в методе) 
        #endregion

        /* У делегатов одинаковое имя но VS не жалуется (перегрузка?)
        //delegate int Operation(int x, int y);       // int (int, int)
        //delegate T Operation<T, K>(K val);          // T (K)
        */

        #region Объявление методов для работы с делегатами
        #region delegate void Message();
        void Hello() => Console.WriteLine("Hello");
        void HowAreYou() => Console.WriteLine("How Are You");
        #endregion

        #region delegate int MathDel(int x, int y); 
        int Add(int x, int y) => x + y;
        int Multiply(int x, int y) => x * y;
        int Divide(int x, int y) => x / y;
        #endregion

        #region Соответствие методов делегату
        //Как было написано выше, методы соответствуют делегату, если они имеют один и тот же возвращаемый тип
        //и один и тот же набор параметров.Но надо учитывать, что во внимание также принимаются модификаторы
        //ref, in и out. Например, пусть у нас есть делегат:

        delegate void SomeDel(int a, double b);     // void (int, double) 
        //Этому делегату соответствует, например, следующий метод:
        void SomeMethod1(int g, double n) { } //сигнатура совпадает
        //А следующие методы НЕ соответствуют:
        double SomeMethod2(int g, double n) { return g + n; } //другой возвращаемый тип
        void SomeMethod3(double n, int g) { } //другой набор параметров
        void SomeMethod4(ref int g, double n) { } //имеет модификатор ref 
        void SomeMethod5(out int g, double n) { g = 6; }// имеет модификатор out. 
        #endregion

        #region delegate T GenericDel<T, K>(K val);
        decimal Square(int n) => n * n;
        int Double(int n) => n + n;

        enum OperationType
        {
            Add, Subtract, Multiply
        }
        #endregion 
        #endregion

        #endregion
        public override void Start()
        {
            //delegate void Message(); /внутри функции объявлять нельзя
            Message mes;            // 2. Создаем переменную делегата
            mes = Hello;            // 3. Присваиваем этой переменной адрес метода
            mes();                  // 4. Вызываем метод

            //Operation gdf = Add;
            //gdf.GetType();
            //Console.WriteLine(gdf.GetType().ToString());      // 20


            #region Параметры и результат делегата 

            MathDel operation = Add;      // делегат указывает на метод Add
            int result = operation(4, 5);   // фактически Add(4, 5)
            Console.WriteLine(result);      // 9

            operation = Multiply;           // теперь делегат указывает на метод Multiply
            result = operation(4, 5);       // фактически Multiply(4, 5)
            Console.WriteLine(result);      // 20 

            #endregion

            #region Присвоение ссылки на метод

            MathDel operation1 = Add;//переменной делегата напрямую присваивался метод.
            MathDel operation2 = new MathDel(Add);// создание объекта делегата с помощью конструктора, в который передается нужный метод
                                                //Оба способа равноценны.
            #endregion

            #region Добавление и удаление методов в делегате
            //делегат может указывать на множество методов, которые имеют ту же сигнатуру и возвращаемые тип.
            //Все методы в делегате попадают в специальный список - список вызова или invocation list.
            //И при вызове делегата все методы из этого списка последовательно вызываются.
            //И мы можем добавлять в этот список не один, а несколько методов.
            //Для добавления методов в делегат применяется операция +=:
            MathDel manyOperations = Add;
            manyOperations += Multiply;
            //При добавлении делегатов следует учитывать, что мы можем добавить ссылку на один и тот же метод несколько раз,
            //и в списке вызова делегата тогда будет несколько ссылок на один и то же метод.
            //Соответственно при вызове делегата добавленный метод будет вызываться столько раз, сколько он был добавлен:
            manyOperations += Divide;
            manyOperations += Divide;
            manyOperations += Divide;


            manyOperations -= Add;   // удаляем метод Add
            if (manyOperations != null) manyOperations(5, 2); // вызывается метод Hello
                                                              //При удалении методов из делегата фактически будет создаватья новый делегат,
                                                              //который в списке вызова методов будет содержать на один метод меньше.
            Message? message = Hello;
            message += HowAreYou;
            message();  // вызываются все методы из message
            message -= HowAreYou;   // удаляем метод HowAreYou
            if (message != null) message(); // вызывается метод Hello

            //При удалении следует учитывать, что если делегат содержит несколько ссылок на один и тот же метод,
            //то операция -= начинает поиск с конца списка вызова делегата и удаляет только первое найденное вхождение.
            //Если подобного метода в списке вызова делегата нет, то операция -= не имеет никакого эффекта. 
            #endregion

            #region Объединение делегатов
            Console.WriteLine("кук");
            Message mes1 = Hello;
            Message mes2 = HowAreYou;
            Message mes3 = mes1 + mes2; // объединяем делегаты
            mes3(); // вызываются все методы из mes1 и mes2 

            #endregion

            #region Вызов делегата

            //Вызов делегата
            operation1(5, 2); //при вызове для параметров передавались необходимые значения:
            operation1.Invoke(5, 2);//Другой способ вызова делегата представляет метод Invoke():
                                    //Если делегат возвращает некоторое значение, то возвращается значение последнего метода из списка вызова (если в списке вызова несколько методов).

            #endregion

            #region Обобщенные делегаты

            //Обобщенные делегаты //delegate T Operation<T, K>(K val);
            GenericDel<decimal, int> squareOperation = Square;
            decimal result1 = squareOperation(5);
            Console.WriteLine(result1);  // 25

            GenericDel<int, int> doubleOperation = Double;
            int result2 = doubleOperation(5);
            Console.WriteLine(result2);  // 10

            #endregion

            #region Делегаты как параметры методов

            // делегаты могут быть параметрами методов.
            // Благодаря этому один метод в качестве параметров может получать действия - другие методы. Например:

            DoOperation(5, 4, Add);         // 9 //передаем функцию
            DoOperation(5, 4, Divide);    // 1
            DoOperation(5, 4, Multiply);    // 20

            void DoOperation(int a, int b, MathDel op) //delegate int Operation(int x, int y);
            {
                Console.WriteLine(op(a, b));
            }
            #endregion

            #region Возвращение делегатов из метода
            //Возвращение делегатов из метода
            //Также делегаты можно возвращать из методов.
            //То есть мы можем возвращать из метода какое-то действие в виде другого метода.Например:

            MathDel operation3 = SelectOperation(OperationType.Add);
            Console.WriteLine(operation3(10, 4));    // 14

            operation3 = SelectOperation(OperationType.Subtract);
            Console.WriteLine(operation3(10, 4));    // 6

            operation3 = SelectOperation(OperationType.Multiply);
            Console.WriteLine(operation3(10, 4));    // 40

            MathDel SelectOperation(OperationType opType)
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
            #endregion
        }


        public override void Info()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        public override string Conclusion()
        {
            return "delegate [возвращаемый_тип] [название_делегата] ([возвращаемые параметры]);\n" +
                   "delegate T GenericDel<T, K> (K val); Делегат с сигнатурой T (K). После имени указываем универсальные параметры<T, K>\n" +
                   "Делегат можно объявлять в классах или в namespase (но не в методе).\n" +
                   "Экземпляр делегата: [название_делегата] [название_переменной] = [функция];\n" +
                   "MathDel operation = Add;\n" +
                   "Или так: [название_делегата] [название_переменной] = new [название_делегата]([функция]);\n" +
                   "MathDel operation = new MathDel(Add);\n" +
                   "Параметры и результат делегата: int result = operation(4, 5); - фактически result = Add(4, 5)\n" +
                   "Прибавить функцию +=, вычесть -=. Делегаты одного типа можно складывать. " +
                   "Метод .Invoke() вызывает делегат. Если в делегате несколько функций - вернется результат последней.\n" +
                   "Делегат можно объявить как параметр метода. Благодаря этому один метод в качестве параметров может получать действия - другие методы\n" +
                   "Также делегаты можно возвращать из методов. То есть мы можем возвращать из метода какое-то действие в виде другого метода." +
                   "В этом случае возвращаемым параметром из метода будет делегат, а в return записывается функция: return MyFunc" +
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
