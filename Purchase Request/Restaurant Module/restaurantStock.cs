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
    public partial class restaurantStock : Form
    {
        public restaurantStock()
        {
            InitializeComponent();
        }

        public void Display()
        {
            other.DisplayAndSearch("SELECT restaurantID, itemID, quantity FROM restaurant_item", restaurantItemTable);
        }

        private void restaurantStock_Shown(object sender, EventArgs e)
        {
            Display();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void restaurantItemTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                updateRItemQuantity quantityForm = new updateRItemQuantity();
                quantityForm.Show();

                quantityForm.txtRestaurantID.Text = restaurantItemTable.Rows[e.RowIndex].Cells[2].Value.ToString();
                string restaurantID = quantityForm.txtRestaurantID.Text;
                quantityForm.txtRestaurantID.ReadOnly = true;
                quantityForm.txtItemID.Text = restaurantItemTable.Rows[e.RowIndex].Cells[3].Value.ToString();
                string itemID = quantityForm.txtItemID.Text;
                quantityForm.txtItemID.ReadOnly = true;
                quantityForm.txtOldQuantity.Text = restaurantItemTable.Rows[e.RowIndex].Cells[4].Value.ToString();
                quantityForm.txtOldQuantity.ReadOnly = true;

            }

            if (e.ColumnIndex == 1)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand = "SELECT * FROM item WHERE itemID = \"" + restaurantItemTable.Rows[e.RowIndex].Cells[3].Value.ToString() + "\"";
                MySqlCommand cmd = new MySqlCommand(sqlCommand, con);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                itemDetailTable.DataSource = table;
                con.Close();
            }
        }

        private void restaurantStock_Load(object sender, EventArgs e)
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            string sqlCommand1 = "SELECT * FROM restaurant";
            MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);

            MySqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox1.Items.Add(reader1.GetString("restaurantID"));
            }
            reader1.Close();

            string sqlCommand2 = "SELECT * FROM item";
            MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

            MySqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox2.Items.Add(reader2.GetString("itemID"));
            }
            reader2.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string choice1 = comboBox1.SelectedItem.ToString();
                string choice2 = comboBox2.SelectedItem.ToString();

                //MessageBox.Show(choice1 + choice2);

                other.DisplayAndSearch("SELECT restaurantID, itemID, quantity FROM restaurant_item WHERE restaurantID = '" + choice1 + "' AND itemID = '" + choice2 + "'", restaurantItemTable);
            } 
            catch(System.NullReferenceException ex)
            {
                MessageBox.Show("Please Select. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
