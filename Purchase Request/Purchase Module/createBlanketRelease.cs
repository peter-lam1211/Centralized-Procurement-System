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
    public partial class createBlanketRelease : Form
    {
        public createBlanketRelease()
        {
            InitializeComponent();
        }

        public string getReleaseID()
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string sqlCommand = "SELECT COALESCE(MAX(blanketReleaseID), \"None\") FROM blanketrelease";
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
                return "BR001";
            }

            int i = Convert.ToInt32(ID.Substring(3)) + 1;
            result.Close();
            con.Close();
            return string.Format("BR{0:D3}", i);
        }

        public void Clear()
        {
            comboAgreementID1.SelectedIndex = 0;
            comboAgreementID2.SelectedIndex = 0;
            comboRestaurantID.SelectedIndex = 0;
            comboWarehouseID.SelectedIndex = 0;

            createDate.Text = expectedDeliveryDate.Text = txtRemark.Text = String.Empty;

            foreach (DataGridViewRow row in agreement1ItemInfoTable.Rows)
            {
                row.Cells[0].Value = String.Empty;
                row.Cells[1].Value = String.Empty;
                row.Cells[2].Value = String.Empty;
            }

            foreach (DataGridViewRow row in agreement2ItemInfoTable.Rows)
            {
                row.Cells[0].Value = String.Empty;
                row.Cells[1].Value = String.Empty;
                row.Cells[2].Value = String.Empty;
            }

            foreach (DataGridViewRow row in release1ItemInfoTable.Rows)
            {
                row.Cells[0].Value = "false";
                row.Cells[1].Value = String.Empty;
                row.Cells[2].Value = String.Empty;
            }

            foreach (DataGridViewRow row in release2ItemInfoTable.Rows)
            {
                row.Cells[0].Value = "false";
                row.Cells[1].Value = String.Empty;
                row.Cells[2].Value = String.Empty;
            }
        }

        private void createBlanketRelease_Load(object sender, EventArgs e)
        {
            other.InsertCombo("SELECT agreementID FROM purchaseagreement WHERE agreementType = 'Blanket Purchase Agreement'", comboAgreementID1, "agreementID");
            other.InsertCombo("SELECT agreementID FROM purchaseagreement WHERE agreementType = 'Blanket Purchase Agreement'", comboAgreementID2, "agreementID");
            other.InsertCombo("SELECT restaurantID FROM restaurant", comboRestaurantID, "restaurantID");
            other.InsertCombo("SELECT warehouseID FROM warehouse", comboWarehouseID, "warehouseID");

            txtReleaseID.ReadOnly = true;
            txtUserID.ReadOnly = true;
            createDate.Enabled = false;

            comboMutiple.SelectedIndex = 0;
            comboAgreementID1.SelectedIndex = 0;
            comboAgreementID2.SelectedIndex = 0;
            comboRestaurantID.SelectedIndex = 0;
            comboWarehouseID.SelectedIndex = 0;
        }

        private void comboMutiple_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMutiple.SelectedIndex == 0)
            {
                comboAgreementID2.Enabled = false;
                buttonAgreement2.Enabled = false;
                agreement2Panel.Visible = false;
            }
            else if (comboMutiple.SelectedIndex == 1)
            {
                comboAgreementID2.Enabled = true;
                buttonAgreement2.Enabled = true;
            }
        }

        private void comboAgreementID1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string agreementID = comboAgreementID1.SelectedItem.ToString();

            other.DisplayAndSearch("SELECT itemID, price, incompletedQuantity FROM purchaseagreement_item WHERE agreementID = '" + agreementID + "'", agreement1ItemInfoTable);
            other.DisplayAndSearch("SELECT agreementID, itemID, incompletedQuantity FROM purchaseagreement_item WHERE agreementID = '" + agreementID + "'", release1ItemInfoTable);
        }

        private void comboAgreementID2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string agreementID = comboAgreementID2.SelectedItem.ToString();
            
            other.DisplayAndSearch("SELECT itemID, price, incompletedQuantity FROM purchaseagreement_item WHERE agreementID = '" + agreementID + "'", agreement2ItemInfoTable);
            other.DisplayAndSearch("SELECT agreementID, itemID, incompletedQuantity FROM purchaseagreement_item WHERE agreementID = '" + agreementID + "'", release2ItemInfoTable);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (comboRestaurantID.Text == "Select one" && comboWarehouseID.Text == "Select one")
            {
                MessageBox.Show("The shipping address is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboRestaurantID.Text != "Select one" && comboWarehouseID.Text != "Select one")
            {
                MessageBox.Show("You are not allowed to choose two shipping address at the same time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.Now.CompareTo(expectedDeliveryDate.Value) == 1)
            {
                MessageBox.Show("The expected delivery date is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string releaseID = getReleaseID();

            if (comboMutiple.SelectedIndex == 0)
            {
                foreach (DataGridViewRow checkRow in release1ItemInfoTable.Rows)
                {
                    if ((string)checkRow.Cells[0].Value == "true" && checkRow.Cells[1].Value != null)
                    {
                        string itemID = checkRow.Cells[3].Value.ToString();
                        int quantity = int.Parse(checkRow.Cells[1].Value.ToString());
                        int oldIncompletedQuantity = int.Parse(checkRow.Cells[4].Value.ToString());

                        if (quantity > oldIncompletedQuantity)
                        {
                            MessageBox.Show("The release quantity of itemID " + itemID + " is large than agreed quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (quantity <= 0)
                        {
                            MessageBox.Show("The release quantity of itemID " + itemID + " cannot be 0 or less than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                string sqlCommand1 = "INSERT INTO blanketrelease (blanketReleaseID, agreementID_1, createDate, expectedDate, userID, shippingAddress, remind, status, handlingPRID) VALUES (@blanketReleaseID, @agreementID_1, @createDate, @expectedDate, @userID, @shippingAddress, @remind, 'deliverying', @handlingPRID)";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                cmd1.Parameters.Add("@blanketReleaseID", MySqlDbType.VarChar).Value = releaseID;
                cmd1.Parameters.Add("@agreementID_1", MySqlDbType.VarChar).Value = comboAgreementID1.Text;
                cmd1.Parameters.Add("@createDate", MySqlDbType.VarChar).Value = createDate.Text;
                cmd1.Parameters.Add("@expectedDate", MySqlDbType.VarChar).Value = expectedDeliveryDate.Text;
                cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;

                if (comboRestaurantID.Text != "Select one")
                {
                    cmd1.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = comboRestaurantID.Text;
                }
                else
                {
                    cmd1.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = comboWarehouseID.Text;
                }

                cmd1.Parameters.Add("@remind", MySqlDbType.VarChar).Value = txtRemark.Text;
                cmd1.Parameters.Add("@handlingPRID", MySqlDbType.VarChar).Value = txtHandlingRequestID.Text;

                cmd1.ExecuteNonQuery();

                foreach (DataGridViewRow row in release1ItemInfoTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null)
                    {
                        string itemID = row.Cells[3].Value.ToString();
                        int quantity = int.Parse(row.Cells[1].Value.ToString());
                        string agreementID = row.Cells[2].Value.ToString();
                        int oldIncompletedQuantity = int.Parse(row.Cells[4].Value.ToString());

                        string sqlCommand2 = "INSERT INTO blanketRelease_item VALUES (@agreementID, @blanketReleaseID ,@itemID, @quantity)";
                        MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                        cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = comboAgreementID1.Text;
                        cmd2.Parameters.Add("@blanketReleaseID", MySqlDbType.VarChar).Value = releaseID;
                        cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                        cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;

                        cmd2.ExecuteNonQuery();

                        int newIncompletedQuantity = oldIncompletedQuantity - quantity;

                        string sqlCommand3 = "UPDATE purchaseagreement_item SET incompletedQuantity = @newIncompletedQuantity WHERE agreementID = @agreementID AND itemID = @itemID";
                        MySqlCommand cmd3 = new MySqlCommand(sqlCommand3, con);

                        cmd3.Parameters.Add("@newIncompletedQuantity", MySqlDbType.Int32).Value = newIncompletedQuantity;
                        cmd3.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                        cmd3.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;

                        cmd3.ExecuteNonQuery();
                    }
                }
                Clear();
                MessageBox.Show("Create Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (txtHandlingRequestID.Text != "None")
                {
                    string sqlCommandUpdate = "UPDATE purchaserequest SET status = 'finished' WHERE status = 'mapping' AND purchaseRequestID = \"" + txtHandlingRequestID.Text + "\"";
                    MySqlCommand cmdUpdate = new MySqlCommand(sqlCommandUpdate, con);
                    cmdUpdate.ExecuteNonQuery();
                    mainPage.form_requestMapping.Display1();
                }
                other.activityRecord(Permission.user.id, "Create blanket release", releaseID);

                mainPage.form_order_release.Display2();

                this.Close();
            }

            if (comboMutiple.SelectedIndex == 1)
            {
                string agreementID_1 = comboAgreementID1.SelectedItem.ToString();
                string agreementID_2 = comboAgreementID2.SelectedItem.ToString();

                if (agreementID_1 == agreementID_2)
                {
                    MessageBox.Show("The agreementID 1 cannot same to agreementID 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboAgreementID2.SelectedIndex = 0;
                    return;
                }

                foreach (DataGridViewRow checkRow in release1ItemInfoTable.Rows)
                {
                    if ((string)checkRow.Cells[0].Value == "true" && checkRow.Cells[1].Value != null)
                    {
                        string itemID = checkRow.Cells[3].Value.ToString();
                        int quantity = int.Parse(checkRow.Cells[1].Value.ToString());
                        int oldIncompletedQuantity = int.Parse(checkRow.Cells[4].Value.ToString());

                        if (quantity > oldIncompletedQuantity)
                        {
                            MessageBox.Show("The release quantity of itemID " + itemID + " is large than agreed quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (quantity <= 0)
                        {
                            MessageBox.Show("The release quantity of itemID " + itemID + " cannot be 0 or less than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                foreach (DataGridViewRow checkRow in release2ItemInfoTable.Rows)
                {
                    if ((string)checkRow.Cells[0].Value == "true" && checkRow.Cells[1].Value != null)
                    {
                        string itemID = checkRow.Cells[3].Value.ToString();
                        int quantity = int.Parse(checkRow.Cells[1].Value.ToString());
                        int oldIncompletedQuantity = int.Parse(checkRow.Cells[4].Value.ToString());

                        if (quantity > oldIncompletedQuantity)
                        {
                            MessageBox.Show("The release quantity of itemID " + itemID + " is large than agreed quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (quantity <= 0)
                        {
                            MessageBox.Show("The release quantity of itemID " + itemID + " cannot be 0 or less than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                string sqlCommand1 = "INSERT INTO blanketrelease (blanketReleaseID, agreementID_1, agreementID_2, createDate, expectedDate, userID, shippingAddress, remind, status, handlingPRID) VALUES (@blanketReleaseID, @agreementID_1, @agreementID_2, @createDate, @expectedDate, @userID, @shippingAddress, @remind, 'deliverying', @handlingPRID)";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                cmd1.Parameters.Add("@blanketReleaseID", MySqlDbType.VarChar).Value = releaseID;
                cmd1.Parameters.Add("@agreementID_1", MySqlDbType.VarChar).Value = comboAgreementID1.Text;
                cmd1.Parameters.Add("@agreementID_2", MySqlDbType.VarChar).Value = comboAgreementID2.Text;
                cmd1.Parameters.Add("@createDate", MySqlDbType.VarChar).Value = createDate.Text;
                cmd1.Parameters.Add("@expectedDate", MySqlDbType.VarChar).Value = expectedDeliveryDate.Text;
                cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;

                if (comboRestaurantID.Text != "Select one")
                {
                    cmd1.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = comboRestaurantID.Text;
                }
                else
                {
                    cmd1.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = comboWarehouseID.Text;
                }

                cmd1.Parameters.Add("@remind", MySqlDbType.VarChar).Value = txtRemark.Text;
                cmd1.Parameters.Add("@handlingPRID", MySqlDbType.VarChar).Value = txtHandlingRequestID.Text;

                cmd1.ExecuteNonQuery();

                foreach (DataGridViewRow row in release1ItemInfoTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null)
                    {
                        string itemID = row.Cells[3].Value.ToString();
                        int quantity = int.Parse(row.Cells[1].Value.ToString());
                        string agreementID = row.Cells[2].Value.ToString();
                        int oldIncompletedQuantity = int.Parse(row.Cells[4].Value.ToString());

                        string sqlCommand2 = "INSERT INTO blanketRelease_item VALUES (@agreementID, @blanketReleaseID ,@itemID, @quantity)";
                        MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                        cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = comboAgreementID1.Text;
                        cmd2.Parameters.Add("@blanketReleaseID", MySqlDbType.VarChar).Value = releaseID;
                        cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                        cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;

                        cmd2.ExecuteNonQuery();

                        int newIncompletedQuantity = oldIncompletedQuantity - quantity;

                        string sqlCommand3 = "UPDATE purchaseagreement_item SET incompletedQuantity = @newIncompletedQuantity WHERE agreementID = @agreementID AND itemID = @itemID";
                        MySqlCommand cmd3 = new MySqlCommand(sqlCommand3, con);

                        cmd3.Parameters.Add("@newIncompletedQuantity", MySqlDbType.Int32).Value = newIncompletedQuantity;
                        cmd3.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                        cmd3.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;

                        cmd3.ExecuteNonQuery();
                    }
                }
                
                foreach (DataGridViewRow row in release2ItemInfoTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null)
                    {
                        string itemID = row.Cells[3].Value.ToString();
                        int quantity = int.Parse(row.Cells[1].Value.ToString());
                        string agreementID = row.Cells[2].Value.ToString();
                        int oldIncompletedQuantity = int.Parse(row.Cells[4].Value.ToString());

                        string sqlCommand2 = "INSERT INTO blanketRelease_item VALUES (@agreementID, @blanketReleaseID ,@itemID, @quantity)";
                        MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                        cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = comboAgreementID2.Text;
                        cmd2.Parameters.Add("@blanketReleaseID", MySqlDbType.VarChar).Value = releaseID;
                        cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                        cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;

                        cmd2.ExecuteNonQuery();

                        int newIncompletedQuantity = oldIncompletedQuantity - quantity;

                        string sqlCommand3 = "UPDATE purchaseagreement_item SET incompletedQuantity = @newIncompletedQuantity WHERE agreementID = @agreementID AND itemID = @itemID";
                        MySqlCommand cmd3 = new MySqlCommand(sqlCommand3, con);

                        cmd3.Parameters.Add("@newIncompletedQuantity", MySqlDbType.Int32).Value = newIncompletedQuantity;
                        cmd3.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                        cmd3.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;

                        cmd3.ExecuteNonQuery();
                    }
                }
                Clear();
                MessageBox.Show("Create Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (txtHandlingRequestID.Text != "None")
                {
                    string sqlCommandUpdate = "UPDATE purchaserequest SET status = 'finished' WHERE status = 'mapping' AND purchaseRequestID = \"" + txtHandlingRequestID.Text + "\"";
                    MySqlCommand cmdUpdate = new MySqlCommand(sqlCommandUpdate, con);
                    cmdUpdate.ExecuteNonQuery();
                    mainPage.form_requestMapping.Display1();
                }
                other.activityRecord(Permission.user.id, "Create blanket release", releaseID);

                mainPage.form_order_release.Display2();

                this.Close();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonAgreement1_Click(object sender, EventArgs e)
        {
            agreement1Panel.Visible = true;
            agreement2Panel.Visible = false;
        }

        private void buttonAgreement2_Click(object sender, EventArgs e)
        {
            agreement2Panel.Visible = true;
            agreement1Panel.Visible = false;
        }
    }
}
