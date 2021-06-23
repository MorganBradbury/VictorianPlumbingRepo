using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VictorianPlumbing.Models;

namespace VictorianPlumbing.Services
{
    public class CreateOrderService : ICreateOrderService
    {
        // Get connection string from Startup.cs class and pass to each Method for inserting data.
        protected string ConnectionString { get; set; }
        public CreateOrderService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        // Create Order in Database
        public OrderCreated InsertOrder(Order order)
        {

            var _OrderCreated = new OrderCreated()
            {
                AccountId = Account.CreateAccount(order.Account, ConnectionString),
                OrderReferenceNumber = Order.CreateOrder(order, ConnectionString),
                OrderedItems = OrderedItems.InsertItems(order.OrderedItems, Order.OrderReferenceNumber, ConnectionString)
            };

            return _OrderCreated;
        }
    }
}
