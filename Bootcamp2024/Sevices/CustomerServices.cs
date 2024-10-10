using BootCamp2024.Models;
using Microsoft.Data.SqlClient;


namespace BootCamp2024.Services
{
    public class CustomerService
    {
        public string ConnectionString { get; set; }

        public CustomerService()
        {

            ConnectionString = "Server=DESKTOP-J3LGOM3\\SQLEXPRESS;Database=Bootcamp2024;Trusted_Connection=True;TrustServerCertificate=True";
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Customer";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        Customer customer;
                        while (reader.Read())
                        {
                            customer = new Customer();

                            customer.Id = reader.GetInt32(0);
                            customer.FirstName = reader.GetString(1);
                            customer.LastName = reader.GetString(2);
                            customer.City = reader.GetString(3);
                            customer.Country = reader.GetString(4);
                            customer.Phone = reader.GetString(5);

                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }

        public void AddCustomer(Customer customer)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT into Customer(FirstName,LastName,City,Country,Phone) Values(@fname,@lname,@city,@country,@phone)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@fname", customer.FirstName);
                    command.Parameters.AddWithValue("@lname", customer.LastName);
                    command.Parameters.AddWithValue("@city", customer.City);
                    command.Parameters.AddWithValue("@country", customer.Country);
                    command.Parameters.AddWithValue("@phone", customer.Phone);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditCustomer(Customer customer)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Update Customer set Firstname=@Fname,Lastname=@lname,Country=@country,City=@city,Phone=@phone where id =@id";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@fname", customer.FirstName);
                    command.Parameters.AddWithValue("@lname", customer.LastName);
                    command.Parameters.AddWithValue("@city", customer.City);
                    command.Parameters.AddWithValue("@country", customer.Country);
                    command.Parameters.AddWithValue("@phone", customer.Phone);
                    command.Parameters.AddWithValue("@id", customer.Id);

                    command.ExecuteNonQuery();
                }
            }
        }
        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();

            
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Customer where Id = @id";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters. AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        
                        if (reader.Read())
                        {
                            

                            customer.Id = reader.GetInt32(0);
                            customer.FirstName = reader.GetString(1);
                            customer.LastName = reader.GetString(2);
                            customer.City = reader.GetString(3);
                            customer.Country = reader.GetString(4);
                            customer.Phone = reader.GetString(5);

                        }
                    }
                }
            }

            return customer;
        }

        public void DeleteCustomer(int id)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Delete from Customer where id =@id";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
