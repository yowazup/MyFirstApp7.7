using MyFirstApp;
using System;
using System.Globalization;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace MyFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Survey.NewSurvey(out var survey);
            int number;

            if (survey.shipmentdata.DeliveryType == 1)
            {
                var order = new NewOrder<HomeDelivery>(new HomeDelivery(survey.shipmentdata.Address));
                order.DisplayOrderDetails();
                number = order.GetOrderNumber(out var CorrectNumber);
            }
            else if (survey.shipmentdata.DeliveryType == 2)
            {
                var order = new NewOrder<PickPointDelivery>(new PickPointDelivery());
                order.DisplayOrderDetails();
                number = order.GetOrderNumber(out var CorrectNumber);
            }
            else
            {
                var order = new NewOrder<ShopDelivery>(new ShopDelivery());
                order.DisplayOrderDetails();
                number = order.GetOrderNumber(out var CorrectNumber);
            }
            Client<string> name = new Client<string>();
            name.Name = survey.Name;

            OrdersDatabase.OrdersDatabaseUpdate(number, survey.Name, survey.Item, survey.Quantity, survey.shipmentdata.Address);

            Console.WriteLine("Спасибо за ваш заказ {0}. Наш магазин всегда к вашим услугам.", name.Name);

            Console.ReadKey();
        }
    }

}
