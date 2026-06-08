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
    public partial class activityLogging : Form
    {
        public activityLogging()
        {
            InitializeComponent();
        }

        public void Display()
        {
            other.DisplayAndSearch("SELECT * FROM activitylogging", activityHistoryTable);
        }

        private void activityLogging_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void activityHistoryTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand = "DELETE FROM activitylogging WHERE activityloggingID = \"" + activityHistoryTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"";
                MySqlCommand cmd = new MySqlCommand(sqlCommand, con);
                cmd.ExecuteNonQuery();
                /*
                if (MessageBox.Show("Are you want to delete activity record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                */
                Display();
                con.Close();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchCategory = comboSearchCategory.Text;
            string searchThing = txtSearch.Text;

            other.DisplayAndSearch("SELECT * FROM activitylogging WHERE " + searchCategory + " LIKE'%" + searchThing + "%'", activityHistoryTable);
        }
    }
}
