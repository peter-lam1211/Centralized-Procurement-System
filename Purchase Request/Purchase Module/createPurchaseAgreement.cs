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
    public partial class createPurchaseAgreement : Form
    {
        public createPurchaseAgreement()
        {
            InitializeComponent();
        }

        public string getAgreementID()
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string sqlCommand = "SELECT COALESCE(MAX(agreementID), \"None\") FROM purchaseagreement;";
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
                return "PA001";
            }

            int i = Convert.ToInt32(ID.Substring(3)) + 1;
            result.Close();
            con.Close();
            return string.Format("PA{0:D3}", i);
        }

        private void createPurchaseAgreement_Load(object sender, EventArgs e)
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string sqlCommand = "SELECT supplierID FROM supplier";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboSupplierID.Items.Add(reader.GetString("supplierID"));
            }
            reader.Close();

            txtAgreementID.Enabled = false;
            createDate.Enabled = false;
            txtTotalAmount.Enabled = false;

            comboAgreementType.SelectedIndex = 0;
            comboSupplierID.SelectedIndex = 0;
            comboCurrency.SelectedIndex = 0;
            comboTentativeSchedule.SelectedIndex = 0;
        }

        public void Clear()
        {
            comboAgreementType.SelectedIndex = 0;
            comboSupplierID.SelectedIndex = 0;
            comboCurrency.SelectedIndex = 0;
            comboTentativeSchedule.SelectedIndex = 0;

            txtUserID.Text = createDate.Text = effectiveDate.Text = txtExpectedDiscount.Text = txtTentativeSchedule.Text = comboTentativeSchedule.Text = txtTermAndCondition.Text = txtTotalAmount.Text = String.Empty;

            foreach (DataGridViewRow row in agreementItemTable.Rows)
            {
                row.Cells[0].Value = "false";
                row.Cells[1].Value = String.Empty;
                row.Cells[2].Value = String.Empty;
                row.Cells[3].Value = String.Empty;
            }
        }

        private void comboSupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string supplierID = comboSupplierID.SelectedItem.ToString();

            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string sqlCommand = "SELECT itemID, price, unit FROM item WHERE supplierID = '" + supplierID + "'";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, con);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            agreementItemTable.DataSource = table;
            con.Close();
        }
       
        private void comboAgreementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string choice1 = comboAgreementType.SelectedItem.ToString();
            string choice2 = comboAgreementType.SelectedItem.ToString();
            string choice3 = comboAgreementType.SelectedItem.ToString();

            if (choice1 == "Blanket Purchase Agreement")
            {
                DataGridViewColumn quantityColumn = agreementItemTable.Columns["quantity"];
                quantityColumn.ReadOnly = false;
                DataGridViewColumn amountAgreedColumn = agreementItemTable.Columns["amountAgreed"];
                amountAgreedColumn.ReadOnly = false;
                DataGridViewColumn MoQColumn = agreementItemTable.Columns["MoQ"];
                MoQColumn.ReadOnly = false;

                comboCurrency.Enabled = true;
                txtExpectedDiscount.Enabled = true;
                txtTentativeSchedule.Enabled = false;
                comboTentativeSchedule.Enabled = false;
                txtRevision.Enabled = false;
                txtTotalAmount.Enabled = false;
            }

            if (choice2 == "Contract Purchase Agreement")
            {
                DataGridViewColumn quantityColumn = agreementItemTable.Columns["quantity"];
                quantityColumn.ReadOnly = true;
                DataGridViewColumn amountAgreedColumn = agreementItemTable.Columns["amountAgreed"];
                amountAgreedColumn.ReadOnly = true;
                DataGridViewColumn MoQColumn = agreementItemTable.Columns["MoQ"];
                MoQColumn.ReadOnly = true;

                comboCurrency.Enabled = false;
                txtExpectedDiscount.Enabled = false;
                txtTentativeSchedule.Enabled = false;
                comboTentativeSchedule.Enabled = false;
                txtRevision.Enabled = false;
                txtTotalAmount.Enabled = false;
            }

            if (choice3 == "Planned Purchase Agreement")
            {
                DataGridViewColumn quantityColumn = agreementItemTable.Columns["quantity"];
                quantityColumn.ReadOnly = false;
                DataGridViewColumn amountAgreedColumn = agreementItemTable.Columns["amountAgreed"];
                amountAgreedColumn.ReadOnly = false;
                DataGridViewColumn MoQColumn = agreementItemTable.Columns["MoQ"];
                MoQColumn.ReadOnly = false;

                comboCurrency.Enabled = true;
                txtExpectedDiscount.Enabled = false;
                txtTentativeSchedule.Enabled = true;
                comboTentativeSchedule.Enabled = true;
                txtRevision.Enabled = false;
                txtTotalAmount.Enabled = false;
            }
        }

        private bool AtLeastOneSelected()
        {
            if (comboAgreementType.Text == "Blanket Purchase Agreement" || comboAgreementType.Text == "Planned Purchase Agreement")
            {
                foreach(DataGridViewRow row in agreementItemTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach(DataGridViewRow row in agreementItemTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsPurchaseagreementItemExist(string agreementID, string itemID)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost; port=3306; username=root; password=; database=sdp_db");
            con.Open();
            string sql = "SELECT * FROM purchaseagreement_item WHERE agreementID = '" + agreementID + "' AND itemID = '" + itemID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
            cmd.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
            bool result = cmd.ExecuteReader().HasRows;
            con.Close();
            return result;
        }

        public bool CheckRowDataCorrect(DataGridViewRow row)
        {
            return (string)row.Cells[0].Value == "true" && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (comboAgreementType.Text == String.Empty || comboAgreementType.Text == "Select one")
            {
                MessageBox.Show("The agreement type is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboSupplierID.Text == String.Empty || comboSupplierID.Text == "Select one")
            {
                MessageBox.Show("The supplierID is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string agreementID;

            //Update Blanket Purchase Agreement
            if(buttonCreate.Text == "Update")
            {
                agreementID = txtAgreementID.Text;

                if (comboAgreementType.SelectedItem.ToString() == "Blanket Purchase Agreement")
                {
                    if (comboCurrency.Text == String.Empty || comboCurrency.Text == "Select one")
                    {
                        MessageBox.Show("The currency is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (txtExpectedDiscount.Text == String.Empty || txtExpectedDiscount.Text == "Select one")
                    {
                        MessageBox.Show("The expected discount is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!AtLeastOneSelected())
                    {
                        MessageBox.Show("Please select at least one item and input all related information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sqlCommand1 = "UPDATE purchaseagreement SET agreementType = @agreementType, supplierID = @supplierID, createDate = @createDate, effectiveDate = @effectiveDate, currency = @currency, discount = @discount, termAndCondition = @termAndCondition, userID = @userID WHERE agreementID = @agreementID";
                    MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                    cmd1.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                    cmd1.Parameters.Add("@agreementType", MySqlDbType.VarChar).Value = comboAgreementType.Text;
                    cmd1.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = comboSupplierID.Text;
                    cmd1.Parameters.Add("@createDate", MySqlDbType.VarChar).Value = createDate.Text;
                    cmd1.Parameters.Add("@effectiveDate", MySqlDbType.VarChar).Value = effectiveDate.Text;
                    cmd1.Parameters.Add("@currency", MySqlDbType.VarChar).Value = comboCurrency.Text;
                    cmd1.Parameters.Add("@discount", MySqlDbType.VarChar).Value = txtExpectedDiscount.Text;
                    cmd1.Parameters.Add("@termAndCondition", MySqlDbType.VarChar).Value = txtTermAndCondition.Text;
                    cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;

                    cmd1.ExecuteNonQuery();

                    foreach (DataGridViewRow row in agreementItemTable.Rows)
                    {
                        string itemID = row.Cells[4].Value.ToString();
                        double price = double.Parse(row.Cells[5].Value.ToString());
                        string UOM = row.Cells[6].Value.ToString();

                        if(IsPurchaseagreementItemExist(agreementID, itemID))
                        {
                            if((string)row.Cells[0].Value == "true")
                            {
                                if(CheckRowDataCorrect(row))
                                {
                                    int quantity = int.Parse(row.Cells[1].Value.ToString());
                                    double amountAgreed = double.Parse(row.Cells[2].Value.ToString());
                                    int MoQ = int.Parse(row.Cells[3].Value.ToString());

                                    string sqlCommand2 = "UPDATE purchaseagreement_item SET price = @price, quantity = @quantity, amountAgreed = @amountAgreed, UOM = @UOM, MoQ = @MoQ WHERE agreementID = @agreementID AND itemID = @itemID";
                                    MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                                    cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                                    cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                                    cmd2.Parameters.Add("@price", MySqlDbType.Double).Value = price;
                                    cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
                                    cmd2.Parameters.Add("@amountAgreed", MySqlDbType.Double).Value = amountAgreed;
                                    cmd2.Parameters.Add("@UOM", MySqlDbType.VarChar).Value = UOM;
                                    cmd2.Parameters.Add("@MoQ", MySqlDbType.Int32).Value = MoQ;

                                    cmd2.ExecuteNonQuery();
                                }
                                else
                                {
                                    MessageBox.Show("Row of itemID " + itemID + "should have quantity, amountAgreed and MoQ");
                                }
                            }
                            else
                            {
                                string sqlCommand2 = "DELETE FROM purchaseagreement_item WHERE `purchaseagreement_item`.`agreementID` = @agreementID AND `purchaseagreement_item`.`itemID` = @itemID";
                                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);
                                cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                                cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;

                                cmd2.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                            {
                                int quantity = int.Parse(row.Cells[1].Value.ToString());
                                double amountAgreed = double.Parse(row.Cells[2].Value.ToString());
                                int MoQ = int.Parse(row.Cells[3].Value.ToString());

                                string sqlCommand2 = "INSERT INTO purchaseagreement_item VALUES (@agreementID, @itemID, @price, @quantity, @amountAgreed, @UOM, @MoQ, @incompletedQuantity)";
                                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                                cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                                cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                                cmd2.Parameters.Add("@price", MySqlDbType.Double).Value = price;
                                cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
                                cmd2.Parameters.Add("@amountAgreed", MySqlDbType.Double).Value = amountAgreed;
                                cmd2.Parameters.Add("@UOM", MySqlDbType.VarChar).Value = UOM;
                                cmd2.Parameters.Add("@MoQ", MySqlDbType.Int32).Value = MoQ;
                                cmd2.Parameters.Add("@incompletedQuantity", MySqlDbType.Int32).Value = quantity;

                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                    Clear();
                    MessageBox.Show("Update Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    other.activityRecord(Permission.user.id, "Update blanket purchase agreement", agreementID);
                    displayUpdate();
                }
                else if (comboAgreementType.SelectedItem.ToString() == "Contract Purchase Agreement") //Update Contract Purchase Agreement
                {
                    if (!AtLeastOneSelected())
                    {
                        MessageBox.Show("Please select at least one item and input all related information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sqlCommand1 = "UPDATE purchaseagreement SET agreementType = @agreementType, supplierID = @supplierID, createDate = @createDate, effectiveDate = @effectiveDate, termAndCondition = @termAndCondition, userID = @userID WHERE agreementID = @agreementID";
                    MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                    cmd1.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                    cmd1.Parameters.Add("@agreementType", MySqlDbType.VarChar).Value = comboAgreementType.Text;
                    cmd1.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = comboSupplierID.Text;
                    cmd1.Parameters.Add("@createDate", MySqlDbType.VarChar).Value = createDate.Text;
                    cmd1.Parameters.Add("@effectiveDate", MySqlDbType.VarChar).Value = effectiveDate.Text;
                    cmd1.Parameters.Add("@termAndCondition", MySqlDbType.VarChar).Value = txtTermAndCondition.Text;
                    cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;

                    cmd1.ExecuteNonQuery();

                    foreach (DataGridViewRow row in agreementItemTable.Rows)
                    {
                        string itemID = row.Cells[4].Value.ToString();
                        double price = double.Parse(row.Cells[5].Value.ToString());
                        string UOM = row.Cells[6].Value.ToString();

                        if (IsPurchaseagreementItemExist(agreementID, itemID))
                        {
                            if ((string)row.Cells[0].Value == "false")
                            {
                                string sqlCommand2 = "DELETE FROM purchaseagreement_item WHERE `purchaseagreement_item`.`agreementID` = @agreementID AND `purchaseagreement_item`.`itemID` = @itemID";
                                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);
                                cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                                cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;

                                cmd2.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            if ((string)row.Cells[0].Value == "true")
                            {
                                string sqlCommand2 = "INSERT INTO purchaseagreement_item(agreementID, itemID, price, UOM) VALUES(@agreementID, @itemID, @price, @UOM)";
                                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                                cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                                cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                                cmd2.Parameters.Add("@price", MySqlDbType.Double).Value = price;
                                cmd2.Parameters.Add("@UOM", MySqlDbType.VarChar).Value = UOM;

                                cmd2.ExecuteNonQuery();
                            }

                        }
                    }

                    Clear();
                    MessageBox.Show("Update Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    other.activityRecord(Permission.user.id, "Update contract purchase agreement", agreementID);
                    displayUpdate();
                }
                else //Update Planned Purchase Request
                {
                    if (comboCurrency.Text == String.Empty || comboCurrency.Text == "Select one")
                    {
                        MessageBox.Show("The currency is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (txtTentativeSchedule.Text == String.Empty || comboTentativeSchedule.Text == String.Empty || comboTentativeSchedule.Text == "Select one")
                    {
                        MessageBox.Show("The tentative schedule is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!AtLeastOneSelected())
                    {
                        MessageBox.Show("Please select at least one item and input all related information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sqlCommand1 = "UPDATE purchaseagreement SET agreementType = @agreementType, supplierID = @supplierID, createDate = @createDate, effectiveDate = @effectiveDate, currency = @currency, tentativeSchedules = @tentativeSchedules, termAndCondition = @termAndCondition, userID = @userID WHERE agreementID = @agreementID";
                    MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                    cmd1.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                    cmd1.Parameters.Add("@agreementType", MySqlDbType.VarChar).Value = comboAgreementType.Text;
                    cmd1.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = comboSupplierID.Text;
                    cmd1.Parameters.Add("@createDate", MySqlDbType.VarChar).Value = createDate.Text;
                    cmd1.Parameters.Add("@effectiveDate", MySqlDbType.VarChar).Value = effectiveDate.Text;
                    cmd1.Parameters.Add("@currency", MySqlDbType.VarChar).Value = comboCurrency.Text;
                    cmd1.Parameters.Add("@tentativeSchedules", MySqlDbType.VarChar).Value = txtTentativeSchedule.Text + " " + comboTentativeSchedule.Text;
                    cmd1.Parameters.Add("@termAndCondition", MySqlDbType.VarChar).Value = txtTermAndCondition.Text;
                    cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;

                    cmd1.ExecuteNonQuery();

                    foreach (DataGridViewRow row in agreementItemTable.Rows)
                    {
                        string itemID = row.Cells[4].Value.ToString();
                        double price = double.Parse(row.Cells[5].Value.ToString());
                        string UOM = row.Cells[6].Value.ToString();

                        if (IsPurchaseagreementItemExist(agreementID, itemID))
                        {
                            if ((string)row.Cells[0].Value == "true")
                            {
                                if (CheckRowDataCorrect(row))
                                {

                                    int quantity = int.Parse(row.Cells[1].Value.ToString());
                                    double amountAgreed = double.Parse(row.Cells[2].Value.ToString());
                                    int MoQ = int.Parse(row.Cells[3].Value.ToString());
                                    string sqlCommand2 = "UPDATE purchaseagreement_item SET price = @price, quantity = @quantity, amountAgreed = @amountAgreed, UOM = @UOM, MoQ = @MoQ WHERE agreementID = @agreementID AND itemID = @itemID";
                                    MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                                    cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                                    cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                                    cmd2.Parameters.Add("@price", MySqlDbType.Double).Value = price;
                                    cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
                                    cmd2.Parameters.Add("@amountAgreed", MySqlDbType.Double).Value = amountAgreed;
                                    cmd2.Parameters.Add("@UOM", MySqlDbType.VarChar).Value = UOM;
                                    cmd2.Parameters.Add("@MoQ", MySqlDbType.Int32).Value = MoQ;

                                    cmd2.ExecuteNonQuery();
                                }
                                else
                                {
                                    MessageBox.Show("Row of itemID " + itemID + "should have quantity, amountAgreed and MoQ");
                                }
                            }
                            else
                            {
                                string sqlCommand2 = "DELETE FROM purchaseagreement_item WHERE `purchaseagreement_item`.`agreementID` = @agreementID AND `purchaseagreement_item`.`itemID` = @itemID";
                                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);
                                cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                                cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;

                                cmd2.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                            {
                                int quantity = int.Parse(row.Cells[1].Value.ToString());
                                double amountAgreed = double.Parse(row.Cells[2].Value.ToString());
                                int MoQ = int.Parse(row.Cells[3].Value.ToString());

                                string sqlCommand2 = "INSERT INTO purchaseagreement_item VALUES (@agreementID, @itemID, @price, @quantity, @amountAgreed, @UOM, @MoQ, @incompletedQuantity)";
                                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                                cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                                cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                                cmd2.Parameters.Add("@price", MySqlDbType.Double).Value = price;
                                cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
                                cmd2.Parameters.Add("@amountAgreed", MySqlDbType.Double).Value = amountAgreed;
                                cmd2.Parameters.Add("@UOM", MySqlDbType.VarChar).Value = UOM;
                                cmd2.Parameters.Add("@MoQ", MySqlDbType.Int32).Value = MoQ;
                                cmd2.Parameters.Add("@incompletedQuantity", MySqlDbType.Int32).Value = quantity;

                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                    Clear();
                    MessageBox.Show("Update Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    other.activityRecord(Permission.user.id, "Update planned purchase agreement", agreementID);
                    displayUpdate();
                }
                return;
            }

            //Create agreementID for different type of purchase agreement 
            agreementID = getAgreementID();

            //Create Blanket purchase agreement
            if (comboAgreementType.SelectedItem.ToString() == "Blanket Purchase Agreement")
            {
                if (comboCurrency.Text == String.Empty || comboCurrency.Text == "Select one")
                {
                    MessageBox.Show("The currency is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtExpectedDiscount.Text == String.Empty || txtExpectedDiscount.Text == "Select one")
                {
                    MessageBox.Show("The expected discount is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!AtLeastOneSelected())
                {
                    MessageBox.Show("Please select at least one item and input all related information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sqlCommand1 = "INSERT INTO purchaseagreement (agreementID, agreementType, supplierID, createDate, effectiveDate, currency, discount, termAndCondition, userID, status) VALUES (@agreementID, @agreementType, @supplierID, @createDate, @effectiveDate, @currency, @discount, @termAndCondition, @userID, 'Inactive')";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                cmd1.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                cmd1.Parameters.Add("@agreementtype", MySqlDbType.VarChar).Value = comboAgreementType.Text;
                cmd1.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = comboSupplierID.Text;
                cmd1.Parameters.Add("@createDate", MySqlDbType.VarChar).Value = createDate.Text;
                cmd1.Parameters.Add("@effectiveDate", MySqlDbType.VarChar).Value = effectiveDate.Text;
                cmd1.Parameters.Add("@currency", MySqlDbType.VarChar).Value = comboCurrency.Text;
                cmd1.Parameters.Add("@discount", MySqlDbType.VarChar).Value = txtExpectedDiscount.Text;
                cmd1.Parameters.Add("@termAndCondition", MySqlDbType.VarChar).Value = txtTermAndCondition.Text;
                cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;

                cmd1.ExecuteNonQuery();

                foreach (DataGridViewRow row in agreementItemTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                    {
                        int quantity = int.Parse(row.Cells[1].Value.ToString());
                        double amountAgreed = double.Parse(row.Cells[2].Value.ToString());
                        int MoQ = int.Parse(row.Cells[3].Value.ToString());
                        string itemID = row.Cells[4].Value.ToString();
                        double price = double.Parse(row.Cells[5].Value.ToString());
                        string UOM = row.Cells[6].Value.ToString();

                        string sqlCommand2 = "INSERT INTO purchaseagreement_item VALUES (@agreementID, @itemID, @price, @quantity, @amountAgreed, @UOM, @MoQ, @incompletedQuantity)";
                        MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                        cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                        cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                        cmd2.Parameters.Add("@price", MySqlDbType.Double).Value = price;
                        cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
                        cmd2.Parameters.Add("@amountAgreed", MySqlDbType.Double).Value = amountAgreed;
                        cmd2.Parameters.Add("@UOM", MySqlDbType.VarChar).Value = UOM;
                        cmd2.Parameters.Add("@MoQ", MySqlDbType.Int32).Value = MoQ;
                        cmd2.Parameters.Add("@incompletedQuantity", MySqlDbType.Int32).Value = quantity;

                        cmd2.ExecuteNonQuery();
                    } 
                }

                Clear();
                MessageBox.Show("Create Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                other.activityRecord(Permission.user.id, "Create blanket purchase agreement", agreementID);
                displayUpdate();

                this.Close();
            }

            //Create contract purchase agreement
            if (comboAgreementType.SelectedItem.ToString() == "Contract Purchase Agreement")
            {
                bool atLeastOneSelected = false;
                foreach (DataGridViewRow row in agreementItemTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true")
                    {
                        atLeastOneSelected = true;
                        break;
                    }
                }

                if (!atLeastOneSelected)
                {
                    MessageBox.Show("Please select at least one item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sqlCommand1 = "INSERT INTO purchaseagreement (agreementID, agreementType, supplierID, createDate, effectiveDate, termAndCondition, userID, status) VALUES (@agreementID, @agreementType, @supplierID, @createDate, @effectiveDate, @termAndCondition, @userID, 'Inactive')";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                cmd1.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                cmd1.Parameters.Add("@agreementtype", MySqlDbType.VarChar).Value = comboAgreementType.Text;
                cmd1.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = comboSupplierID.Text;
                cmd1.Parameters.Add("@createDate", MySqlDbType.VarChar).Value = createDate.Text;
                cmd1.Parameters.Add("@effectiveDate", MySqlDbType.VarChar).Value = effectiveDate.Text;
                cmd1.Parameters.Add("@termAndCondition", MySqlDbType.VarChar).Value = txtTermAndCondition.Text;
                cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;

                cmd1.ExecuteNonQuery();

                foreach (DataGridViewRow row in agreementItemTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true")
                    {
                        string itemID = row.Cells[4].Value.ToString();
                        double price = double.Parse(row.Cells[5].Value.ToString());
                        string UOM = row.Cells[6].Value.ToString();

                        string sqlCommand2 = "INSERT INTO purchaseagreement_item (agreementID, itemID, price, UOM) VALUES (@agreementID, @itemID, @price, @UOM)";
                        MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                        cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                        cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                        cmd2.Parameters.Add("@price", MySqlDbType.Double).Value = price;
                        cmd2.Parameters.Add("@UOM", MySqlDbType.VarChar).Value = UOM;

                        cmd2.ExecuteNonQuery();
                    }
                }

                Clear();
                MessageBox.Show("Create Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                other.activityRecord(Permission.user.id, "Create contract purchase agreement", agreementID);
                displayUpdate();

                this.Close();
            }

            //Create planned purchase agreement
            if (comboAgreementType.SelectedItem.ToString() == "Planned Purchase Agreement")
            {
                if (comboCurrency.Text == String.Empty || comboCurrency.Text == "Select one")
                {
                    MessageBox.Show("The currency is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtTentativeSchedule.Text == String.Empty || comboTentativeSchedule.Text == String.Empty || comboTentativeSchedule.Text == "Select one")
                {
                    MessageBox.Show("The tentative schedule is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!AtLeastOneSelected())
                {
                    MessageBox.Show("Please select at least one item and input all related information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sqlCommand1 = "INSERT INTO purchaseagreement (agreementID, agreementType, supplierID, createDate, effectiveDate, currency, tentativeSchedules, termAndCondition, userID, status) VALUES (@agreementID, @agreementType, @supplierID, @createDate, @effectiveDate, @currency, @tentativeSchedules, @termAndCondition, @userID, 'Inactive')";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                cmd1.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                cmd1.Parameters.Add("@agreementtype", MySqlDbType.VarChar).Value = comboAgreementType.Text;
                cmd1.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = comboSupplierID.Text;
                cmd1.Parameters.Add("@createDate", MySqlDbType.VarChar).Value = createDate.Text;
                cmd1.Parameters.Add("@effectiveDate", MySqlDbType.VarChar).Value = effectiveDate.Text;
                cmd1.Parameters.Add("@currency", MySqlDbType.VarChar).Value = comboCurrency.Text;
                cmd1.Parameters.Add("@tentativeSchedules", MySqlDbType.VarChar).Value = txtTentativeSchedule.Text + " " + comboTentativeSchedule.Text;
                //MessageBox.Show(txtTentativeSchedule.Text + " " + comboTentativeSchedule.Text);
                cmd1.Parameters.Add("@termAndCondition", MySqlDbType.VarChar).Value = txtTermAndCondition.Text;
                cmd1.Parameters.Add("@userID", MySqlDbType.VarChar).Value = txtUserID.Text;

                cmd1.ExecuteNonQuery();

                foreach (DataGridViewRow row in agreementItemTable.Rows)
                {
                    if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                    {
                        int quantity = int.Parse(row.Cells[1].Value.ToString());
                        double amountAgreed = double.Parse(row.Cells[2].Value.ToString());
                        int MoQ = int.Parse(row.Cells[3].Value.ToString());
                        string itemID = row.Cells[4].Value.ToString();
                        double price = double.Parse(row.Cells[5].Value.ToString());
                        string UOM = row.Cells[6].Value.ToString();

                        string sqlCommand2 = "INSERT INTO purchaseagreement_item VALUES (@agreementID, @itemID, @price, @quantity, @amountAgreed, @UOM, @MoQ, @incompletedQuantity)";
                        MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                        cmd2.Parameters.Add("@agreementID", MySqlDbType.VarChar).Value = agreementID;
                        cmd2.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = itemID;
                        cmd2.Parameters.Add("@price", MySqlDbType.Double).Value = price;
                        cmd2.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
                        cmd2.Parameters.Add("@amountAgreed", MySqlDbType.Double).Value = amountAgreed;
                        cmd2.Parameters.Add("@UOM", MySqlDbType.VarChar).Value = UOM;
                        cmd2.Parameters.Add("@MoQ", MySqlDbType.Int32).Value = MoQ;
                        cmd2.Parameters.Add("@incompletedQuantity", MySqlDbType.Int32).Value = quantity;

                        cmd2.ExecuteNonQuery();
                    }
                }

                Clear();
                MessageBox.Show("Create Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                other.activityRecord(Permission.user.id, "Create planned purchase agreement", agreementID);
                displayUpdate();

                this.Close();
            }

            con.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void displayUpdate()
        {
            other.DisplayAndSearch("SELECT agreementID, agreementType, supplierID, createDate, effectiveDate, status FROM purchaseagreement", mainPage.form_purchaseAgreement.agreementTable);
            other.DisplayAndSearch("SELECT agreementID FROM purchaseagreement", mainPage.form_purchaseAgreement.agreementStatusTable);
        }

        private void agreementItemTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double totalAgreedAmount = 0;

            foreach (DataGridViewRow row in agreementItemTable.Rows)
            {
                if ((string)row.Cells[0].Value == "true" && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    totalAgreedAmount += double.Parse(row.Cells[2].Value.ToString());
                }
            }

            txtTotalAmount.Text = "$" + totalAgreedAmount;
        }

        private void buttonItemName_Click(object sender, EventArgs e)
        {
            createPurchaseAgreementItemDetail agreementItemDetail = new createPurchaseAgreementItemDetail();
            agreementItemDetail.Show();
        }
    }
}
