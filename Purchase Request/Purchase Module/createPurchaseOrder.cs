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
    public partial class createPurchaseOrder : Form
    {
        public createPurchaseOrder()
        {
            InitializeComponent();
        }

        public string getOrderID()
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string sqlCommand = "SELECT COALESCE(MAX(purchaseOrderID), \"None\") FROM purchaseorder";
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
                return "PO001";
            }

            int i = Convert.ToInt32(ID.Substring(3)) + 1;
            result.Close();
            con.Close();
            return string.Format("PO{0:D3}", i);
        }

        public void Clear()
        {
            comboOrderType.SelectedIndex = 0;
            comboAgreementID.SelectedIndex = 0;
            comboSupplierID.SelectedIndex = 0;
            comboRestaurantID.SelectedIndex = 0;
            comboWarehouseID.SelectedIndex = 0;

            createDate.Text = effectiveDate.Text = txtTermAndCondition.Text = txtRemark.Text = String.Empty;

            foreach (DataGridViewRow row in standardOrderItemTable.Rows)
            {
                row.Cells[0].Value = "false";
                row.Cells[1].Value = String.Empty;
                row.Cells[2].Value = String.Empty;
                row.Cells[3].Value = String.Empty;
                row.Cells[4].Value = String.Empty;
            }

            foreach (DataGridViewRow row in orderItemInfoTable.Rows)
            {
                row.Cells[0].Value = "false";
                row.Cells[1].Value = String.Empty;
                row.Cells[2].Value = String.Empty;
            }

            foreach (DataGridViewRow row in agreementItemInfoTable.Rows)
            {
                row.Cells[0].Value = String.Empty;
                row.Cells[1].Value = String.Empty;
                row.Cells[2].Value = String.Empty;
            }
        }

        public void deleteComboData(ComboBox name, String deletedCharacter)
        {
            for (int i = name.Items.Count - 1; i >= 0; i--)
            {
                string itemText = name.Items[i].ToString();
                if (itemText.StartsWith(deletedCharacter))
                {
                    name.Items.RemoveAt(i);
                }
            }
        }

        private void createPurchaseOrder_Load(object sender, EventArgs e)
        {
            other.InsertCombo("SELECT supplierID FROM supplier", comboSupplierID, "supplierID");
            other.InsertCombo("SELECT restaurantID FROM restaurant", comboRestaurantID, "restaurantID");
            other.InsertCombo("SELECT warehouseID FROM warehouse", comboWarehouseID, "warehouseID");

            comboAgreementID.Enabled = false;
            comboSupplierID.Enabled = false;
            txtOrderID.ReadOnly = true;
            txtUserID.ReadOnly = true;
            createDate.Enabled = false;
            lblAgreementItemInfo.Text = "Supplier item info :";
            lblOrderItemInfo.Text = "";

            comboOrderType.SelectedIndex = 0;
            comboAgreementID.SelectedIndex = 0;
            comboSupplierID.SelectedIndex = 0;
            comboRestaurantID.SelectedIndex = 0;
            comboWarehouseID.SelectedIndex = 0;
        }

        private void comboOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderType = comboOrderType.SelectedItem.ToString();

            if (orderType == "Planned Purchase Order")
            {
                standardOrderItemTable.Visible = false;
                comboAgreementID.Enabled = true;
                comboSupplierID.Enabled = false;
                lblAgreementItemInfo.Text = "Agreement item info :";
                lblOrderItemInfo.Text = "Order item info";
                deleteComboData(comboAgreementID, "PA");
                other.InsertCombo("SELECT agreementID FROM purchaseagreement WHERE status = 'Active' AND agreementType = 'Planned Purchase Agreement'", comboAgreementID, "agreementID");
            } 
            else if (orderType == "Contract Purchase Order")
            {
                standardOrderItemTable.Visible = false;
                comboAgreementID.Enabled = true;
                comboSupplierID.Enabled = false;
                lblAgreementItemInfo.Text = "Agreement item info :";
                lblOrderItemInfo.Text = "Order item info";
                deleteComboData(comboAgreementID, "PA");
                other.InsertCombo("SELECT agreementID FROM purchaseagreement WHERE status = 'Active' AND agreementType = 'Contract Purchase Agreement'", comboAgreementID, "agreementID");
            }
            else if (orderType == "Standard Purchase Order")
            {
                standardOrderItemTable.Visible = true;
                comboAgreementID.Enabled = false;
                comboSupplierID.Enabled = true;
                lblAgreementItemInfo.Text = "Supplier item info :";
                deleteComboData(comboAgreementID, "PA");
                lblOrderItemInfo.Text = "";
            }
        }

        private void comboAgreementID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string agreementID = comboAgreementID.SelectedItem.ToString();

            other.DisplayAndSearch("SELECT agreementID, itemID, price, incompletedQuantity FROM purchaseagreement_item WHERE agreementID = '" + agreementID + "'", agreementItemInfoTable);
            other.DisplayAndSearch("SELECT agreementID, itemID, incompletedQuantity FROM purchaseagreement_item WHERE agreementID = '" + agreementID + "'", orderItemInfoTable);
        }

        private void comboSupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string supplierID = comboSupplierID.SelectedItem.ToString();

            other.DisplayAndSearch("SELECT itemID, price, unit FROM item WHERE supplierID = '" + supplierID + "'", standardOrderItemTable);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (comboOrderType.Text == String.Empty || comboOrderType.Text == "Select one")
            {
                MessageBox.Show("The order type is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            if (DateTime.Now.CompareTo(effectiveDate.Value) == 1)
            {
                MessageBox.Show("The effective date is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string orderID = getOrderID();

            //Create planned purchase order
            if (comboOrderType.Text == "Planned Purchase Order")
            {
                foreach (DataGridViewRow row in orderItemInfoTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null)
                    {
                        string itemID = row.Cells[3].Value.ToString();
                        int quantity = int.Parse(row.Cells[1].Value.ToString());
                        int oldIncompletedQuantity = int.Parse(row.Cells[4].Value.ToString());

                        if (quantity > oldIncompletedQuantity)
                        {
                            MessageBox.Show("The order quantity of itemID " + itemID + " is large than agreed quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (quantity <= 0)
                        {
                            MessageBox.Show("The order quantity of itemID " + itemID + " cannot be 0 or less than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                string sqlCommand1 = "INSERT INTO purchaseorder (purchaseOrderID, agreementID, purchaseOrderType, createDate, expectedDate, shippingAddress, userID, termAndCondition, remind, status, handlingPRID) VALUES (@purchaseOrderID, @agreementID, @purchaseOrderType, @createDate, @expectedDate, @shippingAddress, @userID, @termAndCondition, @remind, 'deliverying', @handlingPRID)";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                cmd1.Parameters.Add("@purchaseOrderID", MySqlDbType.VarChar).Value = orderID;
                cmd1.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = comboAgreementID.Text;
                cmd1.Parameters.Add("@purchaseOrderType", MySqlDbType.VarChar).Value = comboOrderType.Text;
                cmd1.Parameters.Add("@createDate", MySqlDbType.VarChar).Value = createDate.Text;
                cmd1.Parameters.Add("@expectedDate", MySqlDbType.VarChar).Value = effectiveDate.Text;

                if (comboRestaurantID.Text != "Select one")
                {
                    cmd1.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = comboRestaurantID.Text;
                }
                else
                {
                    cmd1.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = comboWarehouseID.Text;
                }

                cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;
                cmd1.Parameters.Add("@termAndCondition", MySqlDbType.VarChar).Value = txtTermAndCondition.Text;
                cmd1.Parameters.Add("@remind", MySqlDbType.VarChar).Value = txtRemark.Text;
                cmd1.Parameters.Add("@handlingPRID", MySqlDbType.VarChar).Value = txtHandlingRequestID.Text;

                cmd1.ExecuteNonQuery();

                foreach (DataGridViewRow row in orderItemInfoTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null)
                    {
                        string itemID = row.Cells[3].Value.ToString();
                        int quantity = int.Parse(row.Cells[1].Value.ToString());
                        string agreementID = row.Cells[2].Value.ToString();
                        int oldIncompletedQuantity = int.Parse(row.Cells[4].Value.ToString());

                        string sqlCommand2 = "INSERT INTO purchaseorder_item VALUES (@purchaseOrderID ,@itemID, @quantity)";
                        MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                        cmd2.Parameters.Add("@purchaseOrderID", MySqlDbType.VarChar).Value = orderID;
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
                other.activityRecord(Permission.user.id, "Create planned purchase order", orderID);

                mainPage.form_order_release.Display1();

                this.Close();
            }

            //Create contract purchase order
            if (comboOrderType.Text == "Contract Purchase Order")
            {
                foreach (DataGridViewRow row in orderItemInfoTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null)
                    {
                        string itemID = row.Cells[3].Value.ToString();
                        int quantity = int.Parse(row.Cells[1].Value.ToString());

                        if (quantity <= 0)
                        {
                            MessageBox.Show("The order quantity of itemID " + itemID + " cannot be 0 or less than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                string sqlCommand1 = "INSERT INTO purchaseorder (purchaseOrderID, agreementID, purchaseOrderType, createDate, expectedDate, shippingAddress, userID, termAndCondition, remind, status, handlingPRID) VALUES (@purchaseOrderID, @agreementID, @purchaseOrderType, @createDate, @expectedDate, @shippingAddress, @userID, @termAndCondition, @remind, 'deliverying', @handlingPRID)";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                cmd1.Parameters.Add("@purchaseOrderID", MySqlDbType.VarChar).Value = orderID;
                cmd1.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = comboAgreementID.Text;
                cmd1.Parameters.Add("@purchaseOrderType", MySqlDbType.VarChar).Value = comboOrderType.Text;
                cmd1.Parameters.Add("@createDate", MySqlDbType.VarChar).Value = createDate.Text;
                cmd1.Parameters.Add("@expectedDate", MySqlDbType.VarChar).Value = effectiveDate.Text;

                if (comboRestaurantID.Text != "Select one")
                {
                    cmd1.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = comboRestaurantID.Text;
                }
                else
                {
                    cmd1.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = comboWarehouseID.Text;
                }

                cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;
                cmd1.Parameters.Add("@termAndCondition", MySqlDbType.VarChar).Value = txtTermAndCondition.Text;
                cmd1.Parameters.Add("@remind", MySqlDbType.VarChar).Value = txtRemark.Text;
                cmd1.Parameters.Add("@handlingPRID", MySqlDbType.VarChar).Value = txtHandlingRequestID.Text;

                cmd1.ExecuteNonQuery();

                foreach (DataGridViewRow row in orderItemInfoTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null)
                    {
                        string itemID = row.Cells[3].Value.ToString();
                        int quantity = int.Parse(row.Cells[1].Value.ToString());

                        string sqlCommand2 = "INSERT INTO purchaseorder_item VALUES (@purchaseOrderID ,@itemID, @quantity)";
                        MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                        cmd2.Parameters.Add("@purchaseOrderID", MySqlDbType.VarChar).Value = orderID;
                        cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                        cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;

                        cmd2.ExecuteNonQuery();
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
                other.activityRecord(Permission.user.id, "Create contract purchase order", orderID);

                mainPage.form_order_release.Display1();

                this.Close();

            }

            //Create standard purchasr order
            if (comboOrderType.Text == "Standard Purchase Order")
            {
                string sqlCommand1 = "INSERT INTO purchaseorder (purchaseOrderID, purchaseOrderType, supplierID, createDate, expectedDate, shippingAddress, userID, termAndCondition, remind, status, handlingPRID) VALUES (@purchaseOrderID, @purchaseOrderType, @supplierID, @createDate, @expectedDate, @shippingAddress, @userID, @termAndCondition, @remind, 'deliverying', @handlingPRID)";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                cmd1.Parameters.Add("@purchaseOrderID", MySqlDbType.VarChar).Value = orderID;
                cmd1.Parameters.Add("@purchaseOrderType", MySqlDbType.VarChar).Value = comboOrderType.Text;
                cmd1.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = comboSupplierID.Text;
                cmd1.Parameters.Add("@createDate", MySqlDbType.VarChar).Value = createDate.Text;
                cmd1.Parameters.Add("@expectedDate", MySqlDbType.VarChar).Value = effectiveDate.Text;

                if (comboRestaurantID.Text != "Select one")
                {
                    cmd1.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = comboRestaurantID.Text;
                }
                else
                {
                    cmd1.Parameters.Add("@shippingAddress", MySqlDbType.VarChar).Value = comboWarehouseID.Text;
                }

                cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;
                cmd1.Parameters.Add("@termAndCondition", MySqlDbType.VarChar).Value = txtTermAndCondition.Text;
                cmd1.Parameters.Add("@remind", MySqlDbType.VarChar).Value = txtRemark.Text;
                cmd1.Parameters.Add("@handlingPRID", MySqlDbType.VarChar).Value = txtHandlingRequestID.Text;

                cmd1.ExecuteNonQuery();

                foreach (DataGridViewRow row in standardOrderItemTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null)
                    {
                        string itemID = row.Cells[2].Value.ToString();
                        int quantity = int.Parse(row.Cells[1].Value.ToString());

                        string sqlCommand2 = "INSERT INTO purchaseorder_item VALUES (@purchaseOrderID ,@itemID, @quantity)";
                        MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                        cmd2.Parameters.Add("@purchaseOrderID", MySqlDbType.VarChar).Value = orderID;
                        cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                        cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;

                        cmd2.ExecuteNonQuery();
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
                other.activityRecord(Permission.user.id, "Create standard purchase order", orderID);

                mainPage.form_order_release.Display1();

                this.Close();
            }

        }

        private void buttonItemName_Click(object sender, EventArgs e)
        {
            createPurchaseAgreementItemDetail itemDetail = new createPurchaseAgreementItemDetail();
            itemDetail.Show();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
