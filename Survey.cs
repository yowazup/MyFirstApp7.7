using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    public static class Survey
    {
        public static void NewSurvey(out (string Name, string Item, int Quantity, ShipmentData shipmentdata) Survey)
        {
            Survey = (null, null, 0, new ShipmentData());

            //Приветствие
            Console.WriteLine("Добро пожаловать в наш магазин.");
            Console.WriteLine("Сегодня у нас есть в наличии следующие товары:");

            //Клиент
            Console.WriteLine("Как вас зовут?");
            Survey.Name = Console.ReadLine();

            //Витрина продаж
            string[] Items = new string[3] { "Табуретка", "Стол", "Диван" };

            for (int i = 0; i < Items.Count(); i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Items[i]);
            }

            //Товар
            Console.WriteLine("Что хотите заказать?");

            int Item = 0;

            while (!int.TryParse(Console.ReadLine(), out Item) || Item < 0 || Item > 3)
            {
                Console.WriteLine("Вы ввели неверное значение. Ответ должен быть целым числом больше нуля и меньше трех. Введите правильное значение: ");
            }

            Survey.Item = Items[Item - 1];

            //Количество
            Console.WriteLine("Сколько товаров {0} хотите заказать?", Survey.Item);

            Survey.Quantity = 0;

            while (!int.TryParse(Console.ReadLine(), out Survey.Quantity) || Survey.Quantity <= 0)
            {
                Console.WriteLine("Вы ввели неверное значение. Ответ должен быть целым числом больше нуля. Введите правильное значение: ");
            }

            //Виды доставок
            Console.WriteLine("Как хотите получить заказ?");

            string[] DeliveryTypes = new string[3] { "Домой", "В пункт выдачи", "В розничный магазин" };

            for (int i = 0; i < DeliveryTypes.Count(); i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, DeliveryTypes[i]);
            }

            //Вид доставки
            int DeliveryType = 0;

            while (!int.TryParse(Console.ReadLine(), out DeliveryType) || DeliveryType < 0 || DeliveryType > 3)
            {
                Console.WriteLine("Вы ввели неверное значение. Ответ должен быть целым числом больше нуля и меньше трех. Введите правильное значение: ");
            }

            Survey.shipmentdata.DeliveryType = DeliveryType;

            //Адрес
            if (Survey.shipmentdata.DeliveryType == 1)
            {
                Console.WriteLine("На какой адрес хотите заказать?");
                Survey.shipmentdata.Address = Console.ReadLine();
            }
        }
    }

    //Использование свойств с логикой в get и/или set блоках.

    public class ShipmentData
    {
        private string _Address;
        public int DeliveryType { get; set; }
        public string Address 
        { 
            get
            {
                return _Address;
            }
            set
            {
                if (DeliveryType == 1)
                {
                    _Address = value;
                }
                else
                {
                    _Address = null;
                }
            }
        }
    }

}
