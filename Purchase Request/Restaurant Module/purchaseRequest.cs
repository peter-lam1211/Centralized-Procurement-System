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
    public partial class purchaseRequest : Form
    {

        public static createPurchaseRequest createRequest = new createPurchaseRequest();

        public purchaseRequest()
        {
            InitializeComponent();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            createRequest.lblheading.Text = "Create Purchase Request";
            createRequest.buttonNew.Text = "Create";
            createRequest.txtUserID.Text = Permission.user.id;
            createRequest.ShowDialog();
        }

        public void Display1()
        {
            other.DisplayAndSearch("SELECT purchaseRequestID, restaurantID, userID, supplierID, status FROM purchaserequest", purchaseRequestTable);

            foreach (DataGridViewRow row in purchaseRequestTable.Rows)
            {
                if (row.Cells[7].Value.ToString() == "mapping")
                {
                    row.Cells[7].Style.BackColor = Color.Khaki;
                }

                if (row.Cells[7].Value.ToString() == "finished")
                {
                    row.Cells[7].Style.BackColor = Color.PowderBlue;
                }
            }
        }

        private void purchaseRequest_Shown(object sender, EventArgs e)
        {
            Display1();
        }

        private void purchaseRequestTable_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && purchaseRequestTable.Rows[e.RowIndex].Cells[7].Value.ToString() == "mapping")
            {
                MessageBox.Show("The request is mapping. \nYou are not allow to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (e.ColumnIndex == 0 && purchaseRequestTable.Rows[e.RowIndex].Cells[7].Value.ToString() == "finished")
            {
                MessageBox.Show("The request is finished. \nYou are not allow to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //edit
            if (e.ColumnIndex == 0)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand = "SELECT remind, expectedDeliveryDate FROM purchaserequest WHERE purchaseRequestID = \"" + purchaseRequestTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd = new MySqlCommand(sqlCommand, con);
                var result = cmd.ExecuteReader();

                String remind = "", expectdedDeliveryDate = "";

                if (result.HasRows)
                {
                    result.Read();
                    remind = result.GetString(0);
                    expectdedDeliveryDate = result.GetString(1);
                }
                else
                {
                    MessageBox.Show("Connected database error", "Error");
                    return;
                }
                result.Close();

                createPurchaseRequest createRequest = new createPurchaseRequest();
                createRequest.Show();

                //put the original value to update form
                createRequest.lblheading.Text = "Edit Purchase Request";
                createRequest.buttonNew.Text = "Update";
                createRequest.txtRequestID.Text = purchaseRequestTable.Rows[e.RowIndex].Cells[3].Value.ToString();
                createRequest.comboResaurantID.Text = purchaseRequestTable.Rows[e.RowIndex].Cells[4].Value.ToString();
                createRequest.comboResaurantID.Enabled = false;
                createRequest.txtUserID.Text = purchaseRequestTable.Rows[e.RowIndex].Cells[5].Value.ToString();
                createRequest.txtUserID.Enabled = false;
                createRequest.comboSupplierID.Text = purchaseRequestTable.Rows[e.RowIndex].Cells[6].Value.ToString();
                createRequest.comboSupplierID.Enabled = false;
                createRequest.deliveryDate.Text = expectdedDeliveryDate;
                createRequest.txtRemark.Text = remind;

                string sqlCommand2 = "SELECT virtualItemID, quantity FROM purchaserequest_item WHERE purchaseRequestID = \"" + purchaseRequestTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);
                var result2 = cmd2.ExecuteReader();

                Dictionary<string, int> dict = new Dictionary<string, int>();

                if (result2.HasRows)
                {
                    while (result2.Read())
                    {
                        string virtualItemID = "";
                        int quantity = 0;

                        virtualItemID = result2.GetString(0);
                        quantity = result2.GetInt32(1);

                        dict.Add(virtualItemID, quantity);
                    }
                }

                foreach (DataGridViewRow row in createRequest.dataGridView1.Rows)
                {
                    if (dict.ContainsKey((string)row.Cells[3].Value))
                    {
                        row.Cells[1].Value = dict[(string)row.Cells[3].Value];
                        row.Cells[0].Value = "true";
                    }
                }
                result2.Close();

                con.Close();
            }

            //delete
            if (e.ColumnIndex == 1)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand1 = "DELETE FROM purchaserequest_item WHERE purchaseRequestID = \"" + purchaseRequestTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                string sqlCommand2 = "DELETE FROM purchaserequest WHERE purchaseRequestID = \"" + purchaseRequestTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                if (MessageBox.Show("Are you want to delete purchase request?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Delete Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        other.activityRecord(Permission.user.id, "Delete purchase request", purchaseRequestTable.Rows[e.RowIndex].Cells[3].Value.ToString());
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Request not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Display1();
                    return;
                }
                con.Close();
            }

            //detail
            if (e.ColumnIndex == 2)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand1 = "SELECT i.itemName, pri.purchaseRequestID, pri.itemID, pri.virtualItemID, pri.quantity FROM item i INNER JOIN purchaserequest_item pri ON i.itemID = pri.itemID AND i.virtualItemID = pri.virtualItemID WHERE pri.purchaseRequestID = \"" + purchaseRequestTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                itemDetailTable.DataSource = table1;

                string sqlCommand2 = "SELECT expectedDeliveryDate, remind FROM purchaserequest WHERE purchaseRequestID = \"" + purchaseRequestTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
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

                con.Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchCategory = comboSearchCategory.Text;
            string searchThing = txtSearch.Text;

            other.DisplayAndSearch("SELECT purchaseRequestID, restaurantID, userID, status FROM purchaserequest WHERE " + searchCategory + " LIKE'%" + searchThing + "%'", purchaseRequestTable);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Display1();

            while (itemDetailTable.Rows.Count > 0)
            {
                itemDetailTable.Rows.RemoveAt(0);
            }

        }
    }
}
