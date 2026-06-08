using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Purchase_Request
{
    public partial class deliveryRequestMappingInfo : Form
    {
        public deliveryRequestMappingInfo()
        {
            InitializeComponent();
        }

        public string getDeliveryNoteID()
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string sqlCommand = "SELECT COALESCE(MAX(deliveryNoteID), \"None\") FROM deliverynote";
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
                return "DN001";
            }

            int i = Convert.ToInt32(ID.Substring(3)) + 1;
            result.Close();
            con.Close();
            return string.Format("DN{0:D3}", i);
        }

        private void buttonGenerateDeliveryNote_Click(object sender, EventArgs e)
        {
            if (!Permission.TryExecute("deliveryNote.generate"))
                return;

            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string deliveryNoteID = getDeliveryNoteID();

            string sqlCommand1 = "INSERT INTO deliverynote VALUES (@deliveryNoteID, @warehouseID, @userID, @restaurantID, @remind, @deliveryRequestID, 'deliverying')";
            MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

            cmd1.Parameters.Add("@deliveryNoteID", MySqlDbType.VarChar).Value = deliveryNoteID;
            cmd1.Parameters.Add("@warehouseID", MySqlDbType.VarChar).Value = txtWarehouseID.Text;
            cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;
            cmd1.Parameters.Add("@restaurantID", MySqlDbType.VarChar).Value = txtShippingAddress.Text;
            cmd1.Parameters.Add("@remind", MySqlDbType.VarChar).Value = txtRemark.Text;
            cmd1.Parameters.Add("@deliveryRequestID", MySqlDbType.VarChar).Value = txtDeliveryRequestID.Text;

            cmd1.ExecuteNonQuery();

            foreach (DataGridViewRow row in deliveryRequestInfoTable.Rows)
            {
                string itemID = row.Cells[0].Value.ToString();
                int quantity = int.Parse(row.Cells[2].Value.ToString());

                string sqlCommand2 = "INSERT INTO deliverynote_item VALUES (@deliveryNoteID, @itemID, @quantity)";
                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                cmd2.Parameters.Add("@deliveryNoteID", MySqlDbType.VarChar).Value = deliveryNoteID;
                cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;

                cmd2.ExecuteNonQuery();
            }

            string sqlCommand3 = "UPDATE deliveryrequest SET status = 'finish' WHERE deliveryRequestID = @deliveryRequestID";
            MySqlCommand cmd3 = new MySqlCommand(sqlCommand3, con);

            cmd3.Parameters.Add("@deliveryRequestID", MySqlDbType.VarChar).Value = txtDeliveryRequestID.Text;

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Generate Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            con.Close();

            mainPage.form_deliveryNote.Display1();
            mainPage.form_deliveryNote.Display2();

            other.activityRecord(Permission.user.id, "Generate delivery note", deliveryNoteID);
            other.activityRecord(Permission.user.id, "Update delivery request status", txtDeliveryRequestID.Text);
        }
    }
}
