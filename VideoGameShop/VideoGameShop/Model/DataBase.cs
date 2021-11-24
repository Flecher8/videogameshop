using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace VideoGameShop
{
    class DataBase
    {
        private const string ConnectionString = @"Data Source=Desktop;Initial Catalog=DBVideoGameShop;Integrated Security=True";
        private SqlConnection connection = new SqlConnection(ConnectionString);

        public SqlConnection Connection
        {
            get
            {
                return connection;
            }
        }
            
        public DataBase()
        {

        }
        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        // Обработка запроса SELECT с последующим возвращением результата
        public DataTable GetDataBase(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(dataTable);
                connection.Close();
            }
            catch(Exception ex)
            {
                connection.Close();
                MessageBox.Show($"GetDataBase Error:  {ex.Message}");
            }
            
            return dataTable;
        }
        public void UpdateDataBase(string query)
        {
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show($"UpdateDataBase Error:  {ex.Message}");
            }
        }
    }
}
