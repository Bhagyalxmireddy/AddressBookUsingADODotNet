using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookUsing_ADODOTNet
{
     public class AddressBookrRepo
     {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Address_Book;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        
        public void RetreveTheData_FromDB()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.connection)
                {
                    string query = "spRetreviData";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.ID = dataReader.GetInt32(0);
                            model.FirstName = dataReader.GetString(1);
                            model.LastName = dataReader.GetString(2);
                            model.Address = dataReader.GetString(3);
                            model.City = dataReader.GetString(4);
                            model.State = dataReader.GetString(5);
                            model.Zip = dataReader.GetString(6);
                            model.PhoneNumber = dataReader.GetString(7);
                            model.Email = dataReader.GetString(8);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                model.ID, model.FirstName, model.LastName, model.Address, model.City, model.State, model.Zip, model.PhoneNumber, model.Email);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dataReader.Close();
                    this.connection.Close();
                }
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        } 

    }
}
