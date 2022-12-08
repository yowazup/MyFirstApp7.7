using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    class NewOrder<TDelivery> where TDelivery : Delivery
    {

        public TDelivery Delivery { get; set; }

        public int Number;

        public NewOrder(TDelivery delivery)
        {
            Delivery = delivery;
            Number = new Random().Next(-100, 100);
        }

        public void DisplayOrderDetails()
        {

            if (Number > 0)
            {
                Console.WriteLine("Ваш правильный номер заказа {0}, а случайным образом выбралось {1}.", Number.GetNegative().GetPositive(), Number);
            }
            else 
            {
                Console.WriteLine("Ваш правильный номер заказа {0}, а случайным образом выбралось {1}.", Number.GetPositive(), Number);
            }
            
            Delivery.DisplayAddress();

        }
        public int GetOrderNumber(out int CorrectNumber)
        {

            if (Number > 0)
            {
                return CorrectNumber = Number;
            }
            else
            {
                return CorrectNumber = Number.GetPositive();
            }
        }

    }

    class Number
    {
        public int Value = new Random().Next(-100, 100);

        public static Number operator + (Number a, Number b)
        {
            return new Number
            {
                Value = a.Value + b.Value,
            };
        }
    }

    static class Extensions
    {
        public static int GetNegative(this int number)
        {
            if (number > 0)
            {
                return -number;
            }
            else
            {
                return number;
            }
        }
        public static int GetPositive(this int number)
        {
            if (number < 0)
            {
                return -number;
            }
            else
            {
                return number;
            }
        }
    }

}
