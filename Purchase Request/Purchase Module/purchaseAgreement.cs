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
    public partial class purchaseAgreement : Form
    {
        public purchaseAgreement()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            createPurchaseAgreement newPurchaseAgreement = new createPurchaseAgreement();
            newPurchaseAgreement.txtUserID.Text = Permission.user.id;
            newPurchaseAgreement.Show();
        }

        public void DisplayAgreement()
        {
            other.DisplayAndSearch("SELECT agreementID, agreementType, supplierID, createDate, effectiveDate, status FROM purchaseagreement", agreementTable);

            foreach (DataGridViewRow row in agreementTable.Rows)
            {
                if (row.Cells[8].Value.ToString() == "Active")
                {
                    row.Cells[8].Style.BackColor = Color.Khaki;
                }

                if (row.Cells[8].Value.ToString() == "Complete")
                {
                    row.Cells[8].Style.BackColor = Color.PowderBlue;
                }
            }
        }

        public void DisplayStatusChange()
        {
            other.DisplayAndSearch("SELECT agreementID FROM purchaseagreement", agreementStatusTable);
        }

        private void purchaseAgreement_Shown(object sender, EventArgs e)
        {
            //txtSearch.Text = "Search...";
            DisplayAgreement();
            DisplayStatusChange();
        }

        private void agreementTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && agreementTable.Rows[e.RowIndex].Cells[8].Value.ToString() == "Active") 
            {
                MessageBox.Show("The agreement is active. \nYou are not allow to edit ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (e.ColumnIndex == 0 && agreementTable.Rows[e.RowIndex].Cells[8].Value.ToString() == "Complete")
            {
                MessageBox.Show("The agreement is complete. \nYou are not allow to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Edit (put the original value to edit form)
            if (e.ColumnIndex == 0)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand = "SELECT userID, termAndCondition FROM purchaseagreement WHERE agreementID = \"" + agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd = new MySqlCommand(sqlCommand, con);
                var result = cmd.ExecuteReader();

                String userID = "", termAndCondition = "";

                if (result.HasRows)
                {
                    result.Read();
                    userID = result.GetString(0);
                    termAndCondition = result.GetString(1);
                }

                result.Close();

                createPurchaseAgreement updatePurchaseAgreement = new createPurchaseAgreement();
                updatePurchaseAgreement.Show();

                //common value
                updatePurchaseAgreement.lblheading.Text = "Update Purchase Agreement";
                updatePurchaseAgreement.buttonCreate.Text = "Update";
                updatePurchaseAgreement.txtAgreementID.Text = agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString();
                updatePurchaseAgreement.comboAgreementType.Text = agreementTable.Rows[e.RowIndex].Cells[4].Value.ToString();
                updatePurchaseAgreement.comboAgreementType.Enabled = false;
                updatePurchaseAgreement.txtUserID.Text = userID;
                updatePurchaseAgreement.txtUserID.Enabled = false;
                updatePurchaseAgreement.comboSupplierID.Text = agreementTable.Rows[e.RowIndex].Cells[5].Value.ToString();
                updatePurchaseAgreement.comboSupplierID.Enabled = false;
                updatePurchaseAgreement.createDate.Text = agreementTable.Rows[e.RowIndex].Cells[6].Value.ToString();
                updatePurchaseAgreement.effectiveDate.Text = agreementTable.Rows[e.RowIndex].Cells[7].Value.ToString();
                updatePurchaseAgreement.txtTermAndCondition.Text = termAndCondition;

                //value for blanket purchase agreement
                if (updatePurchaseAgreement.comboAgreementType.Text == "Blanket Purchase Agreement")
                {
                    string sqlCommand2 = "SELECT currency, discount FROM purchaseagreement WHERE agreementID = \"" + agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                    MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);
                    var result2 = cmd2.ExecuteReader();

                    string currency = "", discount = "";

                    if (result2.HasRows)
                    {
                        result2.Read();
                        currency = result2.GetString(0);
                        discount = result2.GetString(1);
                    }

                    result2.Close();

                    updatePurchaseAgreement.comboCurrency.Text = currency;
                    updatePurchaseAgreement.txtExpectedDiscount.Text = discount;

                    string sqlCommand3 = "SELECT itemID, quantity, amountAgreed, MoQ FROM purchaseagreement_item WHERE agreementID = \"" + agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                    MySqlCommand cmd3 = new MySqlCommand(sqlCommand3, con);
                    var result3 = cmd3.ExecuteReader();

                    Dictionary<string, int> dict1 = new Dictionary<string, int>();
                    Dictionary<string, int> dict2 = new Dictionary<string, int>();
                    Dictionary<string, int> dict3 = new Dictionary<string, int>();

                    if (result3.HasRows)
                    {
                        while (result3.Read())
                        {
                            string itemID = " ";
                            int quantity = 0, amountAgreed = 0, MoQ = 0;

                            itemID = result3.GetString(0);
                            quantity = result3.GetInt32(1);
                            amountAgreed = result3.GetInt32(2);
                            MoQ = result3.GetInt32(3);

                            dict1.Add(itemID, quantity);
                            dict2.Add(itemID, amountAgreed);
                            dict3.Add(itemID, MoQ);
                        }
                    }

                    foreach (DataGridViewRow row in updatePurchaseAgreement.agreementItemTable.Rows)
                    {
                        if (dict1.ContainsKey((string)row.Cells[4].Value) && dict2.ContainsKey((string)row.Cells[4].Value) && dict3.ContainsKey((string)row.Cells[4].Value))
                        {
                            row.Cells[0].Value = "true";
                        }

                        if (dict1.ContainsKey((string)row.Cells[4].Value))
                        {
                            row.Cells[1].Value = dict1[(string)row.Cells[4].Value];
                        }

                        if (dict2.ContainsKey((string)row.Cells[4].Value))
                        {
                            row.Cells[2].Value = dict2[(string)row.Cells[4].Value];
                        }

                        if (dict3.ContainsKey((string)row.Cells[4].Value))
                        {
                            row.Cells[3].Value = dict3[(string)row.Cells[4].Value];
                        }
                    }
                    con.Close();
                }

                //value for contract purchase agreement
                if (updatePurchaseAgreement.comboAgreementType.Text == "Contract Purchase Agreement")
                {
                    string sqlCommand2 = "SELECT itemID FROM purchaseagreement_item WHERE agreementID = \"" + agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                    MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);
                    var result2 = cmd2.ExecuteReader();

                    string[] itemIDArray = new string[100];
                    int number = 0;

                    if (result2.HasRows)
                    {
                        while (result2.Read())
                        {
                            string itemID = " ";

                            itemID = result2.GetString(0);
                            itemIDArray[number] = itemID;

                            number++;
                        }
                    }

                    int number2 = 0;

                    foreach (DataGridViewRow row in updatePurchaseAgreement.agreementItemTable.Rows)
                    {
                        if (itemIDArray[number2] == (string)(row.Cells[4].Value))
                        {
                            row.Cells[0].Value = "true";
                            number2++;
                        }
                    }
                }
                 
                //value for planned purchase agreement
                if (updatePurchaseAgreement.comboAgreementType.Text == "Planned Purchase Agreement")
                {
                    string sqlCommand2 = "SELECT currency, tentativeSchedules FROM purchaseagreement WHERE agreementID = \"" + agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                    MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);
                    var result2 = cmd2.ExecuteReader();

                    string currency = "",tentativeSchedules1 = "", tentativeSchedules2 = "";

                    if (result2.HasRows)
                    {
                        result2.Read();
                        currency = result2.GetString(0);
                        string[] array = result2.GetString(1).Split(' ');
                        //MessageBox.Show(array[0]);
                        tentativeSchedules1 = array[0];
                        tentativeSchedules2 = array[1];
                    }

                    result2.Close();

                    updatePurchaseAgreement.comboCurrency.Text = currency;
                    updatePurchaseAgreement.txtTentativeSchedule.Text = tentativeSchedules1;
                    updatePurchaseAgreement.comboTentativeSchedule.Text = tentativeSchedules2;

                    string sqlCommand3 = "SELECT itemID, quantity, amountAgreed, MoQ FROM purchaseagreement_item WHERE agreementID = \"" + agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                    MySqlCommand cmd3 = new MySqlCommand(sqlCommand3, con);
                    var result3 = cmd3.ExecuteReader();

                    Dictionary<string, int> dict1 = new Dictionary<string, int>();
                    Dictionary<string, int> dict2 = new Dictionary<string, int>();
                    Dictionary<string, int> dict3 = new Dictionary<string, int>();

                    if (result3.HasRows)
                    {
                        while (result3.Read())
                        {
                            string itemID = " ";
                            int quantity = 0, amountAgreed = 0, MoQ = 0;

                            itemID = result3.GetString(0);
                            quantity = result3.GetInt32(1);
                            amountAgreed = result3.GetInt32(2);
                            MoQ = result3.GetInt32(3);

                            dict1.Add(itemID, quantity);
                            dict2.Add(itemID, amountAgreed);
                            dict3.Add(itemID, MoQ);
                        }
                    }

                    foreach (DataGridViewRow row in updatePurchaseAgreement.agreementItemTable.Rows)
                    {
                        if (dict1.ContainsKey((string)row.Cells[4].Value) && dict2.ContainsKey((string)row.Cells[4].Value) && dict3.ContainsKey((string)row.Cells[4].Value))
                        {
                            row.Cells[0].Value = "true";
                        }

                        if (dict1.ContainsKey((string)row.Cells[4].Value))
                        {
                            row.Cells[1].Value = dict1[(string)row.Cells[4].Value];
                        }

                        if (dict2.ContainsKey((string)row.Cells[4].Value))
                        {
                            row.Cells[2].Value = dict2[(string)row.Cells[4].Value];
                        }

                        if (dict3.ContainsKey((string)row.Cells[4].Value))
                        {
                            row.Cells[3].Value = dict3[(string)row.Cells[4].Value];
                        }
                    }
                    con.Close();
                }
            }

            //Delete
            if (e.ColumnIndex == 1)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand1 = "DELETE FROM purchaseagreement_item WHERE agreementID = \"" + agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                string sqlCommand2 = "DELETE FROM purchaseagreement WHERE agreementID = \"" + agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                if (MessageBox.Show("Are you want to delete purchase agreement?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Delete Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Agreement not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    DisplayAgreement();
                    DisplayStatusChange();
                    return;
                }

                con.Close();
            }

            //Detail
            if (e.ColumnIndex == 2)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand1 = "SELECT currency, discount, tentativeSchedules, termAndCondition, userID, revision FROM purchaseagreement WHERE agreementID = \"" + agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

                MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                agreementDetailTable1.DataSource = table1;

                string sqlCommand2 = "SELECT itemID, price, quantity, amountAgreed, UOM, MoQ FROM purchaseagreement_item WHERE agreementID = \"" + agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                agreementDetailTable2.DataSource = table2;

                con.Close();
            }
        }

        //Update status
        private void agreementStatusTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand = "UPDATE purchaseagreement SET status = 'Active' WHERE status = 'Inactive' AND agreementID = \"" + agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd = new MySqlCommand(sqlCommand, con);

                if (MessageBox.Show("Are you want to update purchase agreement?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes && agreementTable.Rows[e.RowIndex].Cells[8].Value.ToString() == "Inactive")
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayAgreement();
                }
                else
                {
                    MessageBox.Show("Update Unsuccessfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();
            }

            if (e.ColumnIndex == 1)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand = "UPDATE purchaseagreement SET status = 'Complete' WHERE status = 'Active' AND agreementID = \"" + agreementTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd = new MySqlCommand(sqlCommand, con);


                if (MessageBox.Show("Are you want to complete purchase agreement?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes && agreementTable.Rows[e.RowIndex].Cells[8].Value.ToString() == "Active")
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayAgreement();
                }
                else
                {
                    MessageBox.Show("Update Unsuccessfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchCategory = comboSearchCategory.Text;
            string searchThing = txtSearch.Text;

            other.DisplayAndSearch("SELECT agreementID, agreementType, supplierID, createDate, effectiveDate, status FROM purchaseagreement WHERE " + searchCategory + " LIKE'%" + searchThing + "%'", agreementTable);
        }

        //Refresh
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DisplayAgreement();

            while (agreementDetailTable1.Rows.Count > 0)
            {
                agreementDetailTable1.Rows.RemoveAt(0);
            }

            while (agreementDetailTable2.Rows.Count > 0)
            {
                agreementDetailTable2.Rows.RemoveAt(0);
            }
        }
    }
}
