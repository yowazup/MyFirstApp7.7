using MyFirstApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    public class Order
    {
        public int OrderNumber;
        public string ClientName;
        public string ItemName;
        public int ItemQuantity;
        public string DeliveryAddress;
    }
    class OrdersDatabase
    {
        private Order[] database;

        public OrdersDatabase(Order[] database)
        {
            this.database = database;
        }
        public Order this[int index]
        {
            get
            {
                if (index >= 0 && index < database.Length)
                {
                    return database[index];
                }
                else
                {
                    return null;
                }
            }

            private set
            {
                if (index >= 0 && index < database.Length)
                {
                    database[index] = value;
                }
            }
        }
    
        public static void OrdersDatabaseUpdate(int number, string Name, string Item, int Quantity, string Address)
        {

            var array = new Order[]
            {
                new Order { OrderNumber = number , ClientName = Name , ItemName = Item , ItemQuantity = Quantity , DeliveryAddress = Address },
            };
            OrdersDatabase database = new OrdersDatabase(array);
        }

    }
}
