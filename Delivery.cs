using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    abstract class Delivery
    {
        public string Address;
        public Delivery(string address)
        {
            Address = address;
        }
        public abstract void DisplayAddress();
        protected bool CheckAddress()
        {
            if (Address == "")
            {
                Console.WriteLine("К сожалению, никуда доставить нельзя :(. Закажите заново на правильный адрес.");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class HomeDelivery : Delivery
    {
        
        public HomeDelivery(string address) : base(address)
        {

        }

        public override void DisplayAddress()
        {
            if (CheckAddress())
            {

            }
            else
            {
                Console.WriteLine("Заказ поедет к вам домой по адресу: {0}", Address);
            }
        }
    }

    class PickPointDelivery : Delivery
    {

        public PickPointDelivery() : base("Остоженка 25c1")
        {
        
        }
        public override void DisplayAddress()
        {
            Console.WriteLine("Заказ можно забрать завтра в нашем пункте выдачи по адресу: {0}", Address);
        }
    }

    class ShopDelivery : Delivery
    {

        public ShopDelivery() : base("сеть магазинов Мебель (тел. 8(999)999-99-99)")
        {

        }
        public override void DisplayAddress()
        {
            Console.WriteLine("Заказ завтра будет передан в {0} и его можно будет забрать в любом их магазине, предварительно согласовав по телефону.", Address);
        }
    }
    //Аггрегация
    class DeliveryData
    {
        private Delivery address;

        public DeliveryData(Delivery address)
        {
            this.address = address;
        }
    }



}
