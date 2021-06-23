using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictorianPlumbing.Models;

namespace VictorianPlumbing.Services
{
    public interface ICreateOrderService
    {
        // Insert order will create an Account row, create an Order row and insert all items in cart into Table.
        public OrderCreated InsertOrder(Order Order);
    }
}
