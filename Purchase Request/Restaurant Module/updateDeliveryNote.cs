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
    public partial class updateDeliveryNote : Form
    {
        public updateDeliveryNote()
        {
            InitializeComponent();
        }

        public void Display1()
        {
            other.DisplayAndSearch("SELECT purchaseOrderID, handlingPRID, status FROM purchaseorder WHERE status = 'deliverying' AND handlingPRID <> 'None'", purchaseOrderHandlingTable);
        }

        public void Display2()
        {
            other.DisplayAndSearch("SELECT blanketReleaseID, handlingPRID, status FROM blanketrelease WHERE status = 'deliverying' AND handlingPRID <> 'None'", blanketReleaseHandlingTable);
        }

        public void Display3()
        {
            other.DisplayAndSearch("SELECT dn.deliveryNoteID, dn.deliveryRequestID, dr.handlingPRID, dn.status FROM deliverynote dn JOIN deliveryrequest dr ON dn.deliveryRequestID = dr.deliveryRequestID WHERE dn.status = 'deliverying' AND dr.handlingPRID != 'None'", updateDeliveryNoteStatusTable);
        }

        private void updateDeliveryNote_Shown(object sender, EventArgs e)
        {
            Display1();
            Display2();
            Display3();
        }

        private void purchaseOrderHandlingTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand1 = "SELECT COALESCE(agreementID, 'None') as agreementID, purchaseOrderType, COALESCE(supplierID, 'None') as supplierID, createDate, expectedDate, shippingAddress, userID, termAndCondition, remind, handlingPRID FROM purchaseorder WHERE purchaseOrderID = \"" + purchaseOrderHandlingTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);
                var result1 = cmd1.ExecuteReader();

                string agreementID = "", purchaseOrderType = "", supplierID = "", createDate = "", expectedDate = "", shippingAddress = "", userID = "", termAndCondition = "", remind = "", handlingPRID = "";

                if (result1.HasRows)
                {
                    result1.Read();
                    agreementID = result1.GetString(0);
                    purchaseOrderType = result1.GetString(1);
                    supplierID = result1.GetString(2);
                    createDate = result1.GetString(3);
                    expectedDate = result1.GetString(4);
                    shippingAddress = result1.GetString(5);
                    userID = result1.GetString(6);
                    termAndCondition = result1.GetString(7);
                    remind = result1.GetString(8);
                    handlingPRID = result1.GetString(9);
                }

                result1.Close();

                purchaseOrderInfo orderInfo = new purchaseOrderInfo();
                orderInfo.Show();
                orderInfo.orderItemInfoTable.Columns[1].Visible = false;

                orderInfo.txtOrderID.Text = purchaseOrderHandlingTable.Rows[e.RowIndex].Cells[1].Value.ToString();
                orderInfo.txtTargetAgreementID.Text = agreementID;
                orderInfo.txtOrderType.Text = purchaseOrderType;
                orderInfo.txtSupplierID.Text = supplierID;
                orderInfo.txtCreateDate.Text = createDate;
                orderInfo.txtExpectedDate.Text = expectedDate;
                orderInfo.txtShippingAddress.Text = shippingAddress;
                orderInfo.txtUserID.Text = userID;
                orderInfo.txtTermAndCondition.Text = termAndCondition;
                orderInfo.txtRemark.Text = remind;
                orderInfo.txtTargetRequestID.Text = handlingPRID;

                other.DisplayAndSearch("SELECT i.virtualItemID, pi.itemID, i.itemName, i.price, pi.quantity FROM purchaseorder_item pi JOIN item i ON pi.itemID = i.itemID WHERE pi.purchaseOrderID = \"" + purchaseOrderHandlingTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"", orderInfo.orderItemInfoTable);

                string sqlCommand2 = "SELECT SUM(i.price * pi.quantity) AS total_amount FROM purchaseorder_item pi JOIN item i ON pi.itemID = i.itemID WHERE pi.purchaseOrderID = \"" + purchaseOrderHandlingTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"";
                MySqlCommand cmd2 = new MySqlCommand(sqlCommand2, con);
                var result2 = cmd2.ExecuteReader();

                string totalAmount = "";

                if (result2.HasRows)
                {
                    result2.Read();
                    totalAmount = result2.GetString(0);
                }
                result2.Close();

                orderInfo.txtOrderAmount.Text = totalAmount;
            }
        }

        private void blanketReleaseHandlingTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string sqlCommand1 = "SELECT agreementID_1, COALESCE(agreementID_2, 'None') as agreementID_2, createDate, expectedDate, userID, shippingAddress, remind, handlingPRID FROM blanketrelease WHERE blanketReleaseID = \"" + blanketReleaseHandlingTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);
                var result1 = cmd1.ExecuteReader();

                string agreementID_1 = "", agreementID_2 = "", createDate = "", expectedDate = "", userID = "", shippingAddress = "", remind = "", handlingPRID = "";

                if (result1.HasRows)
                {
                    result1.Read();
                    agreementID_1 = result1.GetString(0); 
                    agreementID_2 = result1.GetString(1);
                    createDate = result1.GetString(2);
                    expectedDate = result1.GetString(3);
                    userID = result1.GetString(4);
                    shippingAddress = result1.GetString(5);
                    remind = result1.GetString(6);
                    handlingPRID = result1.GetString(7);
                }

                result1.Close();

                blanketReleaseInfo releaseInfo = new blanketReleaseInfo();
                releaseInfo.Show();
                releaseInfo.releaseItemInfoTable.Columns[1].Visible = false;

                releaseInfo.txtReleaseID.Text = blanketReleaseHandlingTable.Rows[e.RowIndex].Cells[1].Value.ToString();
                releaseInfo.txtAgreementID1.Text = agreementID_1;
                releaseInfo.txtAgreementID2.Text = agreementID_2;
                releaseInfo.txtCreateDate.Text = createDate;
                releaseInfo.txtExpectedDate.Text = expectedDate;
                releaseInfo.txtUserID.Text = userID;
                releaseInfo.txtShippingAddress.Text = shippingAddress;
                releaseInfo.txtRemark.Text = remind;
                releaseInfo.txtTargetRequestID.Text = handlingPRID;

                other.DisplayAndSearch("SELECT blanketrelease_item.agreementID, item.virtualItemID, blanketrelease_item.itemID, item.itemName, item.price, blanketrelease_item.quantity FROM item INNER JOIN blanketrelease_item ON item.itemID = blanketrelease_item.itemID WHERE blanketrelease_item.blanketReleaseID = \"" + blanketReleaseHandlingTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"", releaseInfo.releaseItemInfoTable);

                //Original Price
                string sqlCommand3 = "SELECT SUM(item.price * blanketrelease_item.quantity) AS total_amount FROM blanketrelease_item JOIN item ON blanketrelease_item.itemID = item.itemID WHERE blanketrelease_item.blanketReleaseID = \"" + blanketReleaseHandlingTable.Rows[e.RowIndex].Cells[1].Value.ToString() + "\"";
                MySqlCommand cmd3 = new MySqlCommand(sqlCommand3, con);
                var result3 = cmd3.ExecuteReader();

                string totalAmount = "";

                if (result3.HasRows)
                {
                    result3.Read();
                    totalAmount = result3.GetString(0);
                }
                result3.Close();

                releaseInfo.txtOriginalAmount.Text = totalAmount;

                //Find Discount 
                string discount = "";
                string discount2 = "";
                double realDiscount = 0;
                double realDiscount2 = 0;

                if (agreementID_2 == "None")
                {
                    string sqlCommand2_1 = "SELECT discount FROM purchaseagreement WHERE agreementID = \"" + agreementID_1 + "\"";
                    MySqlCommand cmd2_1 = new MySqlCommand(sqlCommand2_1, con);
                    var result2_1 = cmd2_1.ExecuteReader();

                    if (result2_1.HasRows)
                    {
                        result2_1.Read();
                        discount = result2_1.GetString(0);
                    }
                    result2_1.Close();

                    string withoutPercent = discount.Replace("%", "");
                    realDiscount = int.Parse(withoutPercent);
                    realDiscount = realDiscount / 100;

                    releaseInfo.txtDiscountRate.Text = discount;

                    double discountPrice = int.Parse(totalAmount) - (int.Parse(totalAmount) * realDiscount);
                    releaseInfo.txtDiscountAmount.Text = discountPrice.ToString();
                }
                else
                {
                    //Agreement 1 discount rate
                    string sqlCommand2_1 = "SELECT discount FROM purchaseagreement WHERE agreementID = \"" + agreementID_1 + "\"";
                    MySqlCommand cmd2_1 = new MySqlCommand(sqlCommand2_1, con);
                    var result2_1 = cmd2_1.ExecuteReader();

                    if (result2_1.HasRows)
                    {
                        result2_1.Read();
                        discount = result2_1.GetString(0);
                    }
                    result2_1.Close();

                    string withoutPercent = discount.Replace("%", "");
                    realDiscount = int.Parse(withoutPercent);
                    realDiscount = realDiscount / 100;

                    //Agreement 2 discount rate
                    string sqlCommand2_2 = "SELECT discount FROM purchaseagreement WHERE agreementID = \"" + agreementID_2 + "\"";
                    MySqlCommand cmd2_2 = new MySqlCommand(sqlCommand2_2, con);
                    var result2_2 = cmd2_2.ExecuteReader();

                    if (result2_2.HasRows)
                    {
                        result2_2.Read();
                        discount2 = result2_2.GetString(0);
                    }
                    result2_1.Close();

                    string withoutPercent2 = discount2.Replace("%", "");
                    realDiscount2 = int.Parse(withoutPercent2);
                    realDiscount2 = realDiscount2 / 100;

                    //Put the biggest discount rate in text box
                    if (realDiscount == realDiscount2)
                    {
                        releaseInfo.txtDiscountRate.Text = discount;

                        double discountPrice = int.Parse(totalAmount) - (int.Parse(totalAmount) * realDiscount);
                        releaseInfo.txtDiscountAmount.Text = discountPrice.ToString();
                    }
                    else
                    {
                        double biggestDiscount = Math.Max(int.Parse(withoutPercent), int.Parse(withoutPercent2));
                        releaseInfo.txtDiscountRate.Text = biggestDiscount.ToString() + "%";

                        double discountPrice = int.Parse(totalAmount) - (int.Parse(totalAmount) * (biggestDiscount / 100));
                        releaseInfo.txtDiscountAmount.Text = discountPrice.ToString();
                    }
                }
                con.Close();
            }
        }

        private void updateDeliveryNoteStatusTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string sql = "datasource=localhost; port=3306; username=root; password=; database=sdp_db";
                MySqlConnection con = new MySqlConnection(sql);
                con.Open();

                string deliveryNoteID = updateDeliveryNoteStatusTable.Rows[e.RowIndex].Cells[2].Value.ToString();

                string sqlCommand = "UPDATE deliverynote SET status = 'finished' WHERE status = 'deliverying' AND deliveryNoteID = \"" + deliveryNoteID + "\"";
                MySqlCommand cmd = new MySqlCommand(sqlCommand, con);

                if (MessageBox.Show("Are you want to update the status of delivery note with ID " + deliveryNoteID + "?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes && updateDeliveryNoteStatusTable.Rows[e.RowIndex].Cells[5].Value.ToString() == "deliverying")
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    other.activityRecord(Permission.user.id, "Update delivery note status", deliveryNoteID);
                    Display3();
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

                string sqlCommand1 = "SELECT warehouseID, userID, restaurantID, remind, deliveryRequestID FROM deliverynote WHERE deliveryNoteID = \"" + updateDeliveryNoteStatusTable.Rows[e.RowIndex].Cells[2].Value.ToString() + "\"";
                MySqlCommand cmd1 = new MySqlCommand(sqlCommand1, con);
                var result1 = cmd1.ExecuteReader();

                string warehouseID = "", userID = "", restaurantID = "", remind = "", deliveryRequestID = "";

                if (result1.HasRows)
                {
                    result1.Read();
                    warehouseID = result1.GetString(0);
                    userID = result1.GetString(1);
                    restaurantID = result1.GetString(2);
                    remind = result1.GetString(3);
                    deliveryRequestID = result1.GetString(4);
                }

                result1.Close();

                createDeliveryNote newDeliveryNote = new createDeliveryNote();
                newDeliveryNote.Show();
                newDeliveryNote.deliveryNoteItemInfoTable.Columns[1].Visible = false;

                newDeliveryNote.txtDeliveryNoteID.Text = updateDeliveryNoteStatusTable.Rows[e.RowIndex].Cells[2].Value.ToString();
                newDeliveryNote.txtWarehouseID.Text = warehouseID;
                newDeliveryNote.txtUserID.Text = userID;
                newDeliveryNote.txtShippingAddress.Text = restaurantID;
                newDeliveryNote.txtDeliveryRequestID.Text = deliveryRequestID;
                newDeliveryNote.txtRemark.Text = remind;

                other.DisplayAndSearch("SELECT i.virtualItemID, di.itemID, i.itemName, di.quantity FROM deliverynote_item di INNER JOIN item i ON di.itemID = i.itemID WHERE di.deliveryNoteID = \"" + updateDeliveryNoteStatusTable.Rows[e.RowIndex].Cells[2].Value.ToString() + "\"", newDeliveryNote.deliveryNoteItemInfoTable);
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

        private void buttonRefresh3_Click(object sender, EventArgs e)
        {
            Display3();
        }
    }

    
}
