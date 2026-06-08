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
    public partial class requestMapping : Form
    {
        public requestMapping()
        {
            InitializeComponent();
        }

        public void Display1()
        {
            other.DisplayAndSearch("SELECT purchaseRequestID, restaurantID, userID, status FROM purchaserequest WHERE status = 'waiting' OR status = 'mapping'", requestMappingTable);
        }

        private void requestMapping_Shown(object sender, EventArgs e)
        {
            Display1();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Display detail
            if (e.ColumnIndex == 0)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand1 = "SELECT expectedDeliveryDate, remind FROM purchaserequest WHERE purchaseRequestID = \"" + requestMappingTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);
                var result1 = cmd1.ExecuteReader();

                String deliveryDate = "", remark = "";

                if (result1.HasRows)
                {
                    result1.Read();
                    deliveryDate = result1.GetString(0);
                    remark = result1.GetString(1);
                }

                result1.Close();
       
                requestMappingInfo purchaseRequestInfo = new requestMappingInfo();
                purchaseRequestInfo.Show();

                purchaseRequestInfo.txtRequestID.Text = requestMappingTable.Rows[e.RowIndex].Cells[1].Value.ToString();
                purchaseRequestInfo.txtRestaurantID.Text = requestMappingTable.Rows[e.RowIndex].Cells[2].Value.ToString();
                purchaseRequestInfo.txtUserID.Text = requestMappingTable.Rows[e.RowIndex].Cells[3].Value.ToString();
                purchaseRequestInfo.txtDeliveryDate.Text = deliveryDate;
                purchaseRequestInfo.txtRemark.Text = remark;

                other.DisplayAndSearch("SELECT pri.itemID, pri.virtualItemID, i.itemName, pri.quantity FROM purchaserequest_item pri INNER JOIN item i ON pri.itemID = i.itemID WHERE pri.purchaseRequestID = \"" + requestMappingTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"", purchaseRequestInfo.itemQuantityTable);
                other.DisplayAndSearch("SELECT pai.agreementID, pai.itemID, i.itemName, pai.incompletedQuantity FROM purchaseagreement_item pai INNER JOIN item i ON pai.itemID = i.itemID INNER JOIN purchaserequest_item pri ON pai.itemID = pri.itemID WHERE pri.purchaseRequestID = \"" + requestMappingTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"", mainPage.form_requestMapping.agreementRelatedItemTable);
                other.DisplayAndSearch("SELECT wi.warehouseID, pri.itemID, i.itemName, wi.quantity FROM warehouse_item wi INNER JOIN item i ON wi.itemID = i.itemID INNER JOIN purchaserequest_item pri ON wi.itemID = pri.itemID WHERE pri.purchaseRequestID = \"" + requestMappingTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"", mainPage.form_requestMapping.warehouseRelatedItemTable);

                string sqlCommand2 = "UPDATE purchaserequest SET status = 'mapping' WHERE status = 'waiting' AND purchaseRequestID = \"" + requestMappingTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"";
                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);

                other.activityRecord(Permission.user.id, "Update purchase request status", requestMappingTable.Rows[e.RowIndex].Cells[1].Value.ToString());

                cmd2.ExecuteNonQuery();
            }
        }

        private void requestMappingTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            requestMappingTable.RowHeadersVisible = true;

            if (e.RowIndex >= 0)
            {
                requestMappingTable.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Display1();
        }
    }
}
