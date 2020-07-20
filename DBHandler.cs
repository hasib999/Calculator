using System;
using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WPFCalculator
{
    public class DBHandler
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public DBHandler()
        {
            server = "localhost";
            database = "connectcsharptomysql";
            uid = "username";
            password = "password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public System.Collections.ArrayList getAllOperations()
        {
            //connect to DB
            //get all operations and package them and return to the caller
            string query = "SELECT * FROM operations";

            //Create a list to store the result
            ArrayList list = new ArrayList();
            this.OpenConnection();
            //Open connection
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                Operation op = new Operation();
                op.id= (int)dataReader["id"];
                op.num1 = (int)dataReader["firstnum"];
                op.num2 = (int)dataReader["secondnum"];
                op.op = dataReader["operation"].ToString();
                list.Add(op);
            }

            //close Data Reader
            dataReader.Close();
             
            //close Connection
            this.CloseConnection();

            //return list to be displayed
            return list;
        }
        private void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        //Close connection
        private void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        //Update statement
        public void Update(Operation op)
        {
            string query = "UPDATE operations SET result="+op.result+ " WHERE id=" + op.id;

            //Open connection
            this.OpenConnection();
            
            //create mysql command
            MySqlCommand cmd = new MySqlCommand();
            //Assign the query using CommandText
            cmd.CommandText = query;
            //Assign the connection using Connection
            cmd.Connection = connection;

            //Execute query
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();
            
        }
    }
}