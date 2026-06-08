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
    public partial class supplierList : Form
    {
        public supplierList()
        {
            InitializeComponent();
        }

        public void Display()
        {
            other.DisplayAndSearch("SELECT * FROM supplier", supplierTable);
        }

        private void supplierList_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand = "SELECT * FROM item WHERE supplierID = \"" + supplierTable.Rows[e.RowIndex].Cells[2].Value.ToString() + "\"";
                MySqlCommand cmd = new MySqlCommand(sqlCommand, con);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                supplierItemTable.DataSource = table;
                con.Close();
            }

            /*
            if (e.ColumnIndex == 1)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                //string sqlCommand = "DELETE FROM "; 
            }
            */
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addNewSupplier addNewForm = new addNewSupplier();
            addNewForm.Show();
        }
    }
}
