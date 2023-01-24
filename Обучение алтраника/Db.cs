using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Обучение_алтраника
{
    class Db
    {
        // string ConnectString = "datasourse=127.0.0.1;port=3306;username=root;password=;database=diplom";
        // MySqlConnection connection = new MySqlConnection(ConnectString);
        //MySqlConnection connection = new MySqlConnection();

        //SqlConnection connectionSt = new SqlConnection(@"Data Source =LAPTOP-J0AL0OMK\SQLEXPRESS; Initial Catalog = diplom; Integrated Security = True");


        public static string connection1 = @"Data Source =LAPTOP-J0AL0OMK\SQLEXPRESS; Initial Catalog = diplom; Integrated Security = True";
        /*
        
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
        */
    }
}
