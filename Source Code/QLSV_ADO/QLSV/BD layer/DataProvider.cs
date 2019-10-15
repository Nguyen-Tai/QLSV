using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.BD_layer
{
    class DataProvider
    {
        string ConnStr = "Data Source=DESKTOP-B2TNFDV;Initial Catalog=QLSV;Integrated Security=True";
        public DataTable MyExecuteQuery(string query)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }

        public int MyExecuteNonQuery(string query)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(ConnStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);  

                data = command.ExecuteNonQuery();

                connection.Close();
            }
            return data;
        }
    }
}
