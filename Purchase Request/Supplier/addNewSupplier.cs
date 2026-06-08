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
    public partial class addNewSupplier : Form
    {
        public addNewSupplier()
        {
            InitializeComponent();
        }

        public string getSupplierID()
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string sqlCommand = "SELECT COALESCE(MAX(supplierID), \"None\") FROM supplier;";
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
                return "SUP001";
            }

            int i = Convert.ToInt32(ID.Substring(3)) + 1;
            result.Close();
            con.Close();
            return string.Format("SUP{0:D3}", i);
        }

        public void Clear()
        {
            txtSupplierID.Text = txtSupplierName.Text = txtAddress.Text = txtContactPerson.Text = txtPhone.Text = String.Empty;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string sqlCommand = "INSERT INTO supplier VALUES (@supplierID, @supplierName, @address, @contactPerson, @phone)";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, con);

            string supplierID = getSupplierID();

            cmd.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = supplierID;
            cmd.Parameters.Add("@supplierName", MySqlDbType.VarChar).Value = txtSupplierName.Text;
            cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = txtAddress.Text;
            cmd.Parameters.Add("@contactPerson", MySqlDbType.VarChar).Value = txtContactPerson.Text;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = txtPhone.Text;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("New supplier not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            mainPage.form_supplierList.Display();

            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
