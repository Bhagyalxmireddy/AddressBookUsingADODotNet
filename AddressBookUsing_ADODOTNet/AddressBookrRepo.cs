using System;
using System.Collections.Generic;
using System.Data;
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
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool AddPersonToDB(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddPerson", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (!result.Equals(0))
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool AddRelationShip_TypeToDB(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddTypes", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RelationShip_name", model.RelationShip_name);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (!result.Equals(0))
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool AddpersonsTypeToDB(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddRelationTypes", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", model.ID);
                    command.Parameters.AddWithValue("@Relationship_ID", model.Relationship_ID);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (!result.Equals(0))
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool UpadatePersonDetails(AddressBookModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spUpdatePerson", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@City", model.City);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool DeletePersonFromDb(AddressBookModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spDeletePerson", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void RetrevingDataBased_OnCityOrState(AddressBookModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = "spRetreveBasedOncityorstate";
                    SqlCommand command = new SqlCommand(query,connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.FirstName = dataReader.GetString(0);
                            model.City = dataReader.GetString(1);
                            model.State = dataReader.GetString(2);
                            Console.WriteLine("{0},{1},{2}",
                                 model.FirstName, model.City, model.State);
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
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }

        }
        public void RetrevingDataBased_OnCityANDState(AddressBookModel model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    string query = "spRetreveBasedOncityAndstate";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.FirstName = dataReader.GetString(0);
                            model.City = dataReader.GetString(1);
                            model.State = dataReader.GetString(2);
                            Console.WriteLine("{0},{1},{2}",
                                 model.FirstName, model.City, model.State);
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
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }

        }
        public void RetreveData_InSortedOrder(AddressBookModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = "spRetreveDataInsortedOrder";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@City", model.City);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.FirstName = dataReader.GetString(0);
                            model.City = dataReader.GetString(1);
                            Console.WriteLine("{0},{1}",
                                 model.FirstName, model.City);
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
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }

        }
        public void GetCountByPersonType()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (connection)
                {
                    string query = "spGetpersonsCountByType";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.RelationShip_name = dataReader.GetString(0);
                            model.ID = dataReader.GetInt32(1);
                            Console.WriteLine("{0},{1}",
                                 model.RelationShip_name,model.ID);
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
            }
            catch (Exception e)
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
