using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Purchase_Request
{
    public static class Db
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection conn = new MySqlConnection(sql);

            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }

        public static string ConvertString(object str)
        {
            if (str == null || str.GetType() == typeof(DBNull))
                return "";
            return (string)str;
        }
    }
}
