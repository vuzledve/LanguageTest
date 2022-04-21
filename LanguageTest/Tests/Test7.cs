using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Tests.Base
{
    internal class Test7 : Base.BaseTest 
    {
        #region Logic
       
        /* class Account
        {
            public delegate void AccountHandler(Account sender, AccountEventArgs e);
            public event AccountHandler? notify;

            //public event AccountHandler? Notify;              // 1.Определение события
    
            public event AccountHandler Notify
            {
                add
                {
                    notify += value;
                    Console.WriteLine($"{value.Method.Name} добавлен");
                }
                remove
                {
                    notify -= value;
                    Console.WriteLine($"{value.Method.Name} удален");
                }
            }
            public Account(int sum) => Sum = sum;
            public int Sum { get; private set; }
            public void Put(int sum)
            {
                Sum += sum;
               // notify?.Invoke($"На счет поступило: {sum}");   // 2.Вызов события 
            }
            
        }
       */

        class Account
        {
            public delegate void AccountHandler(Account sender, AccountEventArgs e);
            public event AccountHandler? Notify;

            public int Sum { get; private set; }

            public Account(int sum) => Sum = sum;

            public void Put(int sum)
            {
                Sum += sum;
                Notify?.Invoke(this, new AccountEventArgs($"На счет поступило {sum}", sum));
            }
            public void Take(int sum)
            {
                if (Sum >= sum)
                {
                    Sum -= sum;
                    Notify?.Invoke(this, new AccountEventArgs($"Сумма {sum} снята со счета", sum));
                }
                else
                {
                    Notify?.Invoke(this, new AccountEventArgs("Недостаточно денег на счете", sum));
                }
            }
        }

        class AccountEventArgs
        {
            // Сообщение
            public string Message { get; }
            // Сумма, на которую изменился счет
            public int Sum { get; }
            public AccountEventArgs(string message, int sum) //конструктор
            {
                Message = message;
                Sum = sum;
            }
        }

        #endregion
        public override void Start()
        {
            //AccountEventArgs ku = new AccountEventArgs("ew",5);
            //ku.Sum = 3;
             /*
            Account account = new Account(100);


            account.Notify += DisplayMessage;       // добавляем обработчик DisplayMessage
            account.Notify += DisplayRedMessage;    // добавляем обработчик DisplayRedMessage
            account.Put(20);    // добавляем на счет 20
            account.Notify -= DisplayRedMessage;     // удаляем обработчик DisplayRedMessage
            account.Put(50);    // добавляем на счет 50

            void DisplayMessage(string message) => Console.WriteLine(message);
            void DisplayRedMessage(string message)
            {
                // Устанавливаем красный цвет символов
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                // Сбрасываем настройки цвета
                Console.ResetColor();
            }



            Account acc = new Account(100);
            // установка делегата, который указывает на метод DisplayMessage
            acc.Notify += new Account.AccountHandler(DisplayMessage);
            // установка в качестве обработчика метода DisplayMessage
            acc.Notify += DisplayMessage;       // добавляем обработчик DisplayMessage

            acc.Put(25);    // добавляем на счет 20

            acc.Notify += delegate (string mes)
            {
                Console.WriteLine(mes);
            };
            acc.Put(20);
           */

             Account acc = new Account(100);
            acc.Notify += DisplayMessage;
            acc.Put(20);
            acc.Take(70);
            acc.Take(150);

            void DisplayMessage(Account sender, AccountEventArgs e)
            {
                Console.WriteLine($"Сумма транзакции: {e.Sum}");
                Console.WriteLine(e.Message);
                Console.WriteLine($"Текущая сумма на счете: {sender.Sum}");
            }

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
        }
        public override string Conclusion()
        {
            return "События объявляются в классе (или в методе). [модификатор доступа] event [имя делегата] [имя события]\n" +
                   "Делегат: public delegate void AccountHandler(string message);\n" +
                   "Событие: public event AccountHandler notify;\n" +
                   "Обработчик события: notify += SomeMethod;\n" +
                   "Для события можно создать отдельный класс AccountEventArgs и передавать его объект в качестве параметра\n" +
                   "1. В классе объявляем event на основе делегата\n" +
                   "2. В каких то методах при каких то условиях класса вызываем событие [имя события].Invoke()\n" +
                   "3. В классе или где то еще добавляем обработчики события (вызываемые методы) к событию.";
        }

        public override string MoreInfo()
        {
            return "";
        }

        public Test7()
        {
            this.title = "События";
        }
    }
}
