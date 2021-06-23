using System;
using System.Data.SqlClient;

namespace VictorianPlumbing.Models
{
    public class Account
    {
        public Account(string email, string firstName, string lastName, string phoneNumber)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public string Email { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string PhoneNumber { get; private set; }
        public static string CreateAccount(Account account, string ConnectionString)
        {
            // Below using statement inserts an account for every order.
            // An account would usually have already been created but for this project instance I will create a new account per order just for design purposes.
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CreateAccount", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", account.Email);
                    cmd.Parameters.AddWithValue("@FirstName", account.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", account.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", account.PhoneNumber);
                    cmd.Parameters.AddWithValue("@DateJoined", DateTime.Now);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            return account.Email;
        }

    }
}