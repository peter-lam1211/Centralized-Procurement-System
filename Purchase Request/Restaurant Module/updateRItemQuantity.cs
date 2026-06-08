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
    public partial class updateRItemQuantity : Form
    {
        public updateRItemQuantity()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
            MySqlConnection con = new MySqlConnection(sql);
            con.Open();

            int input = Convert.ToInt32(txtNewQuantity.Text);
            string sqlCommand = "UPDATE restaurant_item SET quantity = '" + input + "' WHERE restaurantID = '" + txtRestaurantID.Text + "' AND itemID = '" + txtItemID.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sqlCommand, con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Item not update. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            mainPage.form_restaurantStock.Display();
            txtNewQuantity.Text = String.Empty;
            con.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            txtNewQuantity.Text = String.Empty;
        }
    }
}
