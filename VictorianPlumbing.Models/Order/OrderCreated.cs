using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VictorianPlumbing.Models
{
    public class OrderCreated
    {
        public int OrderReferenceNumber { get; set; }

        public string AccountId { get; set; }

        public List<int> OrderedItems { get; set; }
    }
}
