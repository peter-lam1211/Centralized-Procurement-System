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
    public partial class deliveryNote : Form
    {
        public deliveryNote()
        {
            InitializeComponent();
        }

        public void Display1()
        {
            other.DisplayAndSearch("SELECT deliveryRequestID, userID, shippingAddress, expectedDate FROM deliveryrequest WHERE status = 'waiting'", deliveryRequestQueueTable);
        }

        public void Display2()
        {
            other.DisplayAndSearch("SELECT deliveryNoteID, warehouseID, userID, restaurantID, status FROM deliverynote", deliveryNoteTable);
        }

        private void deliveryNote_Shown(object sender, EventArgs e)
        {
            Display1();
            Display2();
        }

        private void deliveryRequestQueueTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Display detail and handling 
            if (e.ColumnIndex == 0)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand1 = "SELECT warehouseID, remind, handlingPRID FROM deliveryrequest WHERE deliveryRequestID = \"" + deliveryRequestQueueTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);
                var result1 = cmd1.ExecuteReader();

                string warehouseID = "", remark = "", handlingPurchaseRequestID = "";

                if (result1.HasRows)
                {
                    result1.Read();
                    warehouseID = result1.GetString(0);
                    remark = result1.GetString(1);
                    handlingPurchaseRequestID = result1.GetString(2);
                }

                result1.Close();

                deliveryRequestMappingInfo deliveryRequestInfo = new deliveryRequestMappingInfo();
                deliveryRequestInfo.Show();

                deliveryRequestInfo.txtDeliveryRequestID.Text = deliveryRequestQueueTable.Rows[e.RowIndex].Cells[1].Value.ToString();
                deliveryRequestInfo.txtWarehouseID.Text = warehouseID;
                deliveryRequestInfo.txtUserID.Text = deliveryRequestQueueTable.Rows[e.RowIndex].Cells[2].Value.ToString();
                deliveryRequestInfo.txtExpectedDeliveryDate.Text = deliveryRequestQueueTable.Rows[e.RowIndex].Cells[4].Value.ToString();
                deliveryRequestInfo.txtShippingAddress.Text = deliveryRequestQueueTable.Rows[e.RowIndex].Cells[3].Value.ToString();
                deliveryRequestInfo.txtRemark.Text = remark;
                deliveryRequestInfo.txtPurchaseRequestID.Text = handlingPurchaseRequestID;

                other.DisplayAndSearch("SELECT di.itemID, i.itemName, di.quantity FROM deliveryrequest_item di INNER JOIN item i ON di.itemID = i.itemID WHERE di.deliveryRequestID = \"" + deliveryRequestQueueTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"", deliveryRequestInfo.deliveryRequestInfoTable);

                con.Close();
            }
        }

        private void deliveryNoteTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand1 = "SELECT remind, deliveryRequestID FROM deliverynote WHERE deliveryNoteID = \"" + deliveryNoteTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);
                var result1 = cmd1.ExecuteReader();

                string remind = "", deliveryRequestID = "";

                if (result1.HasRows)
                {
                    result1.Read();
                    remind = result1.GetString(0);
                    deliveryRequestID = result1.GetString(1);
                }

                result1.Close();

                createDeliveryNote newDeliveryNote = new createDeliveryNote();
                newDeliveryNote.Show();

                newDeliveryNote.txtDeliveryNoteID.Text = deliveryNoteTable.Rows[e.RowIndex].Cells[1].Value.ToString();
                newDeliveryNote.txtWarehouseID.Text = deliveryNoteTable.Rows[e.RowIndex].Cells[2].Value.ToString();
                newDeliveryNote.txtUserID.Text = deliveryNoteTable.Rows[e.RowIndex].Cells[3].Value.ToString();
                newDeliveryNote.txtShippingAddress.Text = deliveryNoteTable.Rows[e.RowIndex].Cells[4].Value.ToString();
                newDeliveryNote.txtDeliveryRequestID.Text = deliveryRequestID;
                newDeliveryNote.txtRemark.Text = remind;

                other.DisplayAndSearch("SELECT i.virtualItemID, di.itemID, i.itemName, di.quantity FROM deliverynote_item di INNER JOIN item i ON di.itemID = i.itemID WHERE di.deliveryNoteID = \"" + deliveryNoteTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"", newDeliveryNote.deliveryNoteItemInfoTable);
            }
        }

        private void buttonRefresh1_Click(object sender, EventArgs e)
        {
            Display1();
        }

        private void buttonRefresh2_Click(object sender, EventArgs e)
        {
            Display2();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchCategory = comboSearchCategory.Text;
            string searchThing = txtSearch.Text;

            other.DisplayAndSearch("SELECT deliveryNoteID, warehouseID, userID, restaurantID, status FROM deliveryrequest WHERE " + searchCategory + " LIKE'%" + searchThing + "%'", deliveryNoteTable);
        }

        private void deliveryRequestQueueTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            deliveryRequestQueueTable.RowHeadersVisible = true;

            if (e.RowIndex >= 0)
            {
                deliveryRequestQueueTable.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
            }
        }
    }
}
