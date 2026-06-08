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
    class other
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);

            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

        public static void DisplayAndSearch(string query, DataGridView dgy)
        {
            string sql = query;
            MySqlConnection con = GetConnection();

            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandTimeout = 2000;
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgy.DataSource = tbl;
            con.Close();
        }

        public static void InsertCombo(string query, ComboBox cb, string selectedColumn)
        {
            string sql = query;
            MySqlConnection con = GetConnection();

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cb.Items.Add(reader.GetString(selectedColumn));
            }
            reader.Close();
        }

        /*
        public static string getActivityLoggingID()
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string sqlCommand = "SELECT COALESCE(MAX(activityloggingID), \"None\") FROM activitylogging";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, con);

            var result = cmd.ExecuteReader();
            string ID = "None";

            if (result.HasRows)
            {
                result.Read();
                ID = result.GetString(0);
            }

            if (ID == "None")
            {
                return "AL00001";
            }

            int i = Convert.ToInt32(ID.Substring(5)) + 1;
            result.Close();
            con.Close();
            return string.Format("AL{0:D3}", i);
        }
        */

        public static void activityRecord(string user, string activity, string activityObject)
        {
            string userID = user;
            string notedActivity = activity;
            //string activityLoggingID = getActivityLoggingID();

            MySqlConnection con = GetConnection();
            string sql = "INSERT INTO activitylogging (userID, activity) VALUES (@userID, @activity)";
            MySqlCommand cmd = new MySqlCommand(sql, con);

            //cmd.Parameters.Add("@activityloggingID", MySqlDbType.VarChar).Value = activityLoggingID;
            cmd.Parameters.Add("@userID", MySqlDbType.VarChar).Value = userID;
            cmd.Parameters.Add("@activity", MySqlDbType.VarChar).Value = notedActivity + " " + activityObject;

            cmd.ExecuteNonQuery();
        }
    }
}
