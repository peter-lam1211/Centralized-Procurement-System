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
    public partial class createPurchaseRequest : Form
    {

        public createPurchaseRequest()
        {
            InitializeComponent();
        }

        public string getRequestID()
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string sqlCommand = "SELECT COALESCE(MAX(purchaseRequestID), \"None\") FROM purchaserequest;";
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
                return "PR001";
            }

            int i = Convert.ToInt32(ID.Substring(3)) + 1;
            result.Close();
            con.Close();
            return string.Format("PR{0:D3}", i);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            comboResaurantID.SelectedIndex = 0;
            comboSupplierID.SelectedIndex = 0;

            txtRequestID.Text = txtUserID.Text = deliveryDate.Text = txtRemark.Text = string.Empty;
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = "false";
                row.Cells[1].Value = String.Empty;
            }
        }

        public void DisplayUpdated()
        {
            other.DisplayAndSearch("SELECT purchaseRequestID, restaurantID, userID, supplierID, status FROM purchaserequest", mainPage.form_purchaseRequest.purchaseRequestTable);
        }

        private void createPurchaseRequest_Load(object sender, EventArgs e)
        {
            txtRequestID.ReadOnly = true;
            txtUserID.ReadOnly = true;

            other.InsertCombo("SELECT supplierID FROM supplier", comboSupplierID, "supplierID");
        }

        private void comboSupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string supplierID = comboSupplierID.SelectedItem.ToString();

            other.DisplayAndSearch("SELECT itemID, virtualItemID, itemName FROM item WHERE supplierID = '" + supplierID + "'", dataGridView1);
        }

        public void buttonNew_Click(object sender, EventArgs e)
        {
            if(comboResaurantID.Text == String.Empty || comboResaurantID.Text == "Select one")
            {
                MessageBox.Show("RestaurantID is empty");
                return; 
            }

            if (comboSupplierID.Text == String.Empty || comboSupplierID.Text == "Select one")
            {
                MessageBox.Show("WarehouseID is empty");
                return;
            }

            bool atLeastOneSelected = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null)
                {
                    atLeastOneSelected = true;
                    break;
                }
            }

            if (!atLeastOneSelected)
            {
                MessageBox.Show("Please select at least one item and input all related information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.Now.CompareTo(deliveryDate.Value) == 1)
            {
                MessageBox.Show("The delivery date is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string purchaseRequestID = getRequestID();

            //Create a new purchase request
            if (buttonNew.Text == "Create")
            {
                try
                {
                    string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                    MySqlConnection con = new MySqlConnection(sql);

                    string sqlCommand1 = "INSERT INTO purchaserequest VALUES (@purchaseRequestID, @restaurantID, @userID, @supplierID, @expectedDeliveryDate, @remind, 'waiting')";
                    MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                    cmd1.Parameters.Add("@purchaseRequestID", MySqlDbType.VarChar).Value = purchaseRequestID;
                    cmd1.Parameters.Add("@restaurantID", MySqlDbType.VarChar).Value = comboResaurantID.Text;
                    cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;
                    cmd1.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = comboSupplierID.Text;
                    cmd1.Parameters.Add("@expectedDeliveryDate", MySqlDbType.VarChar).Value = deliveryDate.Text;
                    cmd1.Parameters.Add("@remind", MySqlDbType.VarChar).Value = txtRemark.Text;

                    con.Open();
                    cmd1.ExecuteNonQuery();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[1].Value != null && (string)row.Cells[0].Value == "true")
                        {
                            string itemID = row.Cells[2].Value.ToString();
                            string virtualItemID = row.Cells[3].Value.ToString();
                            int quantity = int.Parse(row.Cells[1].Value.ToString());

                            string sqlCommand2 = "INSERT INTO purchaserequest_item (purchaseRequestID, itemID, virtualItemID, quantity) VALUES (@purchaseRequestID, @itemID, @virtualItemID, @quantity)";
                            MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                            cmd2.Parameters.Clear();
                            cmd2.Parameters.AddWithValue("@purchaseRequestID", purchaseRequestID);
                            cmd2.Parameters.AddWithValue("@itemID", itemID);
                            cmd2.Parameters.AddWithValue("@virtualItemID", virtualItemID);
                            cmd2.Parameters.AddWithValue("@quantity", quantity);

                            cmd2.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    con.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Request not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                other.activityRecord(Permission.user.id, "Create purchase request", purchaseRequestID);

                DisplayUpdated();

                this.Close();
            }
            
            //Update the purchase request
            if (buttonNew.Text == "Update")
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                try
                {
                    string sqlCommand3 = "UPDATE purchaserequest SET expectedDeliveryDate = @expectedDeliveryDate, remind = @remind WHERE purchaseRequestID = @purchasereqestID";
                    MySqlCommand cmd3 = new MySqlCommand(sqlCommand3, con);

                    cmd3.Parameters.Add("@expectedDeliveryDate", MySqlDbType.VarChar).Value = this.deliveryDate.Text;
                    cmd3.Parameters.Add("@remind", MySqlDbType.VarChar).Value = this.txtRemark.Text;
                    cmd3.Parameters.Add("@purchasereqestID", MySqlDbType.VarChar).Value = this.txtRequestID.Text;

                    cmd3.ExecuteNonQuery();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string sqlCommandOther = "SELECT * FROM purchaserequest_item WHERE purchaseRequestID = @purchaseRequestID AND itemID = @itemID";
                        MySqlCommand cmdOther = new MySqlCommand(sqlCommandOther, con);
                        cmdOther.Parameters.AddWithValue("@purchaseRequestID", this.txtRequestID.Text);
                        cmdOther.Parameters.AddWithValue("@itemID", row.Cells[2].Value.ToString());

                        var resultOther = cmdOther.ExecuteReader();

                        bool exist;

                        if (resultOther.HasRows)
                        {
                            exist = true;
                        }
                        else
                        {
                            exist = false;
                        }
                        resultOther.Close();

                        if (row.Cells[1].Value != null && (string)row.Cells[0].Value == "true")
                        {
                            string itemID = row.Cells[2].Value.ToString();
                            string virtualItemID = row.Cells[3].Value.ToString();
                            int quantity = int.Parse(row.Cells[1].Value.ToString());

                            if (!exist)
                            {
                                string sqlCommand4 = "INSERT INTO purchaserequest_item (purchaseRequestID, itemID, virtualItemID, quantity) VALUES (@purchaseRequestID, @itemID, @virtualItemID, @quantity)";
                                MySqlCommand cmd4 = new MySqlCommand(sqlCommand4, con);

                                cmd4.Parameters.Clear();
                                cmd4.Parameters.AddWithValue("@purchaseRequestID", this.txtRequestID.Text);
                                cmd4.Parameters.AddWithValue("@itemID", itemID);
                                cmd4.Parameters.AddWithValue("@virtualItemID", virtualItemID);
                                cmd4.Parameters.AddWithValue("@quantity", quantity);

                                cmd4.ExecuteNonQuery();
                            }
                            else
                            {
                                string sqlCommand4 = "UPDATE purchaserequest_item SET quantity = @quantity WHERE purchaseRequestID = @purchaseRequestID AND itemID = @itemID";
                                MySqlCommand cmd4 = new MySqlCommand(sqlCommand4, con);

                                cmd4.Parameters.Clear();
                                cmd4.Parameters.AddWithValue("@quantity", quantity);
                                cmd4.Parameters.AddWithValue("@purchaseRequestID", this.txtRequestID.Text);
                                cmd4.Parameters.AddWithValue("@itemID", itemID);

                                cmd4.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string sqlCommand4 = "DELETE FROM purchaserequest_item WHERE purchaseRequestID = @purchaseRequestID AND itemID = @itemID";
                            MySqlCommand cmd4 = new MySqlCommand(sqlCommand4, con);

                            cmd4.Parameters.Clear();
                            cmd4.Parameters.AddWithValue("@purchaseRequestID", this.txtRequestID.Text);
                            cmd4.Parameters.AddWithValue("@itemID", row.Cells[2].Value.ToString());

                            cmd4.ExecuteNonQuery();

                        }
                    }

                    MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Request not update. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                other.activityRecord(Permission.user.id, "Edit purchase request", this.txtRequestID.Text);

                DisplayUpdated();
            }
        }
    }
}



