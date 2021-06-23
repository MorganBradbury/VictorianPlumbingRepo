using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace VictorianPlumbing.Models
{
    public class Order
    {

        public Order(int id, string status, Account account, string currency, IEnumerable<OrderedItems> orderedItems)
        {
            ID = id;
            Status = status;
            Account = account;
            Currency = currency;
            OrderedItems = orderedItems;
        }

        public int ID { get; private set; }

        public string Status { get; private set; }

        public Account Account { get; private set; }

        public string Currency { get; private set; }

        public IEnumerable<OrderedItems> OrderedItems { get; private set; }

        public static int OrderReferenceNumber { get; set; }

        public static int CreateOrder(Order order, string ConnectionString)
        {
            // Inserting the Order data will generate an Order Reference Number which can be used to identify which items are against each order.
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CreateOrder", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", order.ID);
                    cmd.Parameters.AddWithValue("@Status", order.Status);
                    cmd.Parameters.AddWithValue("@Account", order.Account.Email);
                    cmd.Parameters.AddWithValue("@Currency", order.Currency);
                    con.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        OrderReferenceNumber = Convert.ToInt32(Reader[0].ToString());
                    }
                }
            }

            return OrderReferenceNumber;
        }
    }
}
