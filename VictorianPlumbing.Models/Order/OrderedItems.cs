using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VictorianPlumbing.Models
{
    public class OrderedItems
    {
        public int ID { get; private set; }

        public string Name { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        public OrderedItems(int Id, string name, int quantity, decimal price)
        {
            ID = Id;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        // Looping through each item in cart and adding each newly created item into List for the return object.
        public static List<int> InsertItems(IEnumerable<OrderedItems> OrderedItem, int OrderReferenceNumber, string ConnectionString)
        {
            List<int> ReferenceIDs = new List<int>();

            foreach (var item in OrderedItem)
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("CreateItems", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", item.ID);
                        cmd.Parameters.AddWithValue("@Name", item.Name);
                        cmd.Parameters.AddWithValue("@Price", item.Price);
                        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("@OrderReferenceNumber", OrderReferenceNumber);
                        con.Open();
                        SqlDataReader Reader = cmd.ExecuteReader();
                        while (Reader.Read())
                        {
                            ReferenceIDs.Add(Convert.ToInt32(Reader[0]));
                        }
                    }
                }
            }

            return ReferenceIDs;
        }
    }
}