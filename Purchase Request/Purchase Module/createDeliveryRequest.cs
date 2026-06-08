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

namespace Purchase_Request.Purchase_Module
{
    public partial class createDeliveryRequest : Form
    {
        public createDeliveryRequest()
        {
            InitializeComponent();
        }

        public string getDeliveryRequestID()
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string sqlCommand = "SELECT COALESCE(MAX(deliveryRequestID), \"None\") FROM deliveryrequest";
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
                return "DR001";
            }

            int i = Convert.ToInt32(ID.Substring(3)) + 1;
            result.Close();
            con.Close();
            return string.Format("DR{0:D3}", i);
        }

        public void Clear()
        {
            comboWarehouseID.SelectedIndex = 0;
            comboRestaurantID.SelectedIndex = 0;
            txtRemark.Text = String.Empty;

            foreach (DataGridViewRow row in selectDeliveryRequestItemTable.Rows)
            {
                row.Cells[0].Value = "false";
                row.Cells[1].Value = String.Empty;
            }
        }

        private void createDeliveryRequest_Load(object sender, EventArgs e)
        {
            other.InsertCombo("SELECT warehouseID FROM warehouse", comboWarehouseID,"warehouseID");
            other.InsertCombo("SELECT restaurantID FROM restaurant", comboRestaurantID, "restaurantID");

            txtDeliveryRequestID.ReadOnly = true;
            txtUserID.ReadOnly = true;

            comboWarehouseID.SelectedIndex = 0;
            comboRestaurantID.SelectedIndex = 0;
        }

        private void comboWarehouseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string warehouseID = comboWarehouseID.SelectedItem.ToString();

            other.DisplayAndSearch("SELECT wi.itemID, i.itemName, wi.quantity FROM warehouse_item wi JOIN item i ON wi.itemID = i.itemID WHERE wi.warehouseID = '" + warehouseID + "'", selectDeliveryRequestItemTable);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (comboWarehouseID.Text == String.Empty || comboWarehouseID.Text == "Select one")
            {
                MessageBox.Show("The warehouseID is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboRestaurantID.Text == String.Empty || comboRestaurantID.Text == "Select one")
            {
                MessageBox.Show("The restaurantID is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.Now.CompareTo(expectedDeliveryDate.Value) == 1)
            {
                MessageBox.Show("The expected delivery date is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow checkRow in selectDeliveryRequestItemTable.Rows)
            {
                if ((string)checkRow.Cells[0].Value == "true" && checkRow.Cells[1].Value != null)
                {
                    if ((string)checkRow.Cells[0].Value == "true" && checkRow.Cells[1].Value != null)
                    {
                        string itemID = checkRow.Cells[2].Value.ToString();
                        int quantity = int.Parse(checkRow.Cells[1].Value.ToString());
                        int stockQuantity = int.Parse(checkRow.Cells[4].Value.ToString());

                        if (quantity > stockQuantity)
                        {
                            MessageBox.Show("The request quantity of itemID " + itemID + " is large than stock quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (quantity <= 0)
                        {
                            MessageBox.Show("The request quantity of itemID " + itemID + " cannot be 0 or less than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string deliveryRequestID = getDeliveryRequestID();

            string sqlCommand1 = "INSERT INTO deliveryrequest VALUES (@deliveryRequestID, @warehouseID, @userID, @shippingAddress, @expectedDate, @remind, @handlingPRID, 'waiting')";
            MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

            cmd1.Parameters.Add("@deliveryRequestID", MySqlDbType.VarChar).Value = deliveryRequestID;
            cmd1.Parameters.Add("@warehouseID", MySqlDbType.VarChar).Value = comboWarehouseID.Text;
            cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;
            cmd1.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = comboRestaurantID.Text;
            cmd1.Parameters.Add("@expectedDate", MySqlDbType.VarChar).Value = expectedDeliveryDate.Text;
            cmd1.Parameters.Add("@remind", MySqlDbType.VarChar).Value = txtRemark.Text;
            cmd1.Parameters.Add("@handlingPRID", MySqlDbType.VarChar).Value = txtHandlingRequestID.Text;

            cmd1.ExecuteNonQuery();

            foreach (DataGridViewRow row in selectDeliveryRequestItemTable.Rows)
            {
                if (row.Cells[1].Value != null && (string)row.Cells[0].Value == "true")
                {
                    string itemID = row.Cells[2].Value.ToString();
                    int quantity = int.Parse(row.Cells[1].Value.ToString());
                    int stockQuantity = int.Parse(row.Cells[4].Value.ToString());

                    string sqlCommand2 = "INSERT INTO deliveryrequest_item VALUES (@deliveryRequestID, @itemID, @quantity)";
                    MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                    cmd2.Parameters.Add("@deliveryRequestID", MySqlDbType.VarChar).Value = deliveryRequestID;
                    cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                    cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;

                    cmd2.ExecuteNonQuery();

                    int newStockQuantity = stockQuantity - quantity;

                    String sqlCommand3 = "UPDATE warehouse_item SET quantity = @newStockQuantity WHERE warehouseID = @warehouseID AND itemID = @itemID";
                    MySqlCommand cmd3 = new MySqlCommand(sqlCommand3, con);

                    cmd3.Parameters.Add("@newStockQuantity", MySqlDbType.Int32).Value = newStockQuantity;
                    cmd3.Parameters.Add("@warehouseID", MySqlDbType.VarChar).Value = comboWarehouseID.Text;
                    cmd3.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;

                    cmd3.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();

            if (txtHandlingRequestID.Text != "None")
            {
                string sqlCommandUpdate = "UPDATE purchaserequest SET status = 'finished' WHERE status = 'mapping' AND purchaseRequestID = \"" + txtHandlingRequestID.Text + "\"";
                MySqlCommand cmdUpdate = new MySqlCommand(sqlCommandUpdate, con);
                cmdUpdate.ExecuteNonQuery();
                mainPage.form_requestMapping.Display1();
            }

            other.activityRecord(Permission.user.id, "Create delivery request", deliveryRequestID);

            con.Close();

            mainPage.form_deliveryRequest.Display1();

            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
