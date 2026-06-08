using MySql.Data.MySqlClient;
using Purchase_Request.Purchase_Module;
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
    public partial class deliveryRequest : Form
    {
        public deliveryRequest()
        {
            InitializeComponent();
        }

        public void Display1()
        {
            other.DisplayAndSearch("SELECT deliveryRequestID, warehouseID, userID, shippingAddress, status FROM deliveryrequest", deliveryRequestTable);
        }

        private void deliveryRequest_Shown(object sender, EventArgs e)
        {
            Display1();
        }

        private void buttonCreateDeliveryRequest_Click(object sender, EventArgs e)
        {
            createDeliveryRequest newDeliveryRequest = new createDeliveryRequest();
            newDeliveryRequest.txtHandlingRequestID.Text = "None";
            newDeliveryRequest.txtUserID.Text = Permission.user.id;
            newDeliveryRequest.Show();
        }

        private void deliveryRequestTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand1 = "SELECT di.deliveryRequestID, di.itemID, i.itemName, di.quantity FROM deliveryrequest_item di INNER JOIN item i ON di.itemID = i.itemID WHERE di.deliveryRequestID = \"" + deliveryRequestTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"";
                MySqlCommand cmd = new MySqlCommand(sqlCommand1, con);

                MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                deliveryRequestItemTable.DataSource = table1;

                string sqlCommand2 = "SELECT expectedDate ,remind FROM deliveryrequest WHERE deliveryRequestID = \"" + deliveryRequestTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"";
                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);
                var result = cmd2.ExecuteReader();

                String remind = "", expectedDate = "";

                if (result.HasRows)
                {
                    result.Read();
                    expectedDate = result.GetString(0);
                    remind = result.GetString(1);
                }
                result.Close();

                expectedDeliveryDate.Text = expectedDate;
                txtRemark.Text = remind;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Display1();

            while (deliveryRequestItemTable.Rows.Count > 0)
            {
                deliveryRequestItemTable.Rows.RemoveAt(0);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchCategory = comboSearchCategory.Text;
            string searchThing = txtSearch.Text;

            other.DisplayAndSearch("SELECT deliveryRequestID, warehouseID, userID, shippingAddress, remind FROM deliveryrequest WHERE " + searchCategory + " LIKE'%" + searchThing + "%'", deliveryRequestTable);
        }
    }
}
