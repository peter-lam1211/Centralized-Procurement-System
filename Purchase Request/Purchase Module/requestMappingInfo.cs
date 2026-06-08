using MySql.Data.MySqlClient;
using Purchase_Request.Properties;
using Purchase_Request.Purchase_Module;
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
    public partial class requestMappingInfo : Form
    {
        private bool isCollapsed1 = true;

        public requestMappingInfo()
        {
            InitializeComponent();
        }

        private void buttonHandlingMethod_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void buttonCreateRelease_Click(object sender, EventArgs e)
        {
            createBlanketRelease newRelease = new createBlanketRelease();
            newRelease.txtUserID.Text = Permission.user.id;
            newRelease.txtHandlingRequestID.Text = txtRequestID.Text;
            newRelease.Show();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            createPurchaseOrder newOrder = new createPurchaseOrder();
            newOrder.txtUserID.Text = Permission.user.id;
            newOrder.txtHandlingRequestID.Text = txtRequestID.Text;
            newOrder.Show();
        }

        private void buttonCreateDeliveryRequest_Click(object sender, EventArgs e)
        {
            createDeliveryRequest newDeliveryRequest = new createDeliveryRequest();
            newDeliveryRequest.txtUserID.Text = Permission.user.id;
            newDeliveryRequest.txtHandlingRequestID.Text = txtRequestID.Text;
            newDeliveryRequest.Show();
        }

        private void buttonCreateAgreement_Click(object sender, EventArgs e)
        {
            createPurchaseAgreement newAgreement = new createPurchaseAgreement();
            newAgreement.txtUserID.Text = Permission.user.id;
            newAgreement.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed1)
            {
                buttonHandlingMethod.Image = Resources.expand_icon__reverse_;
                dropDownPanel1.Height += 10;
                if (dropDownPanel1.Size == dropDownPanel1.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed1 = false;
                }
            }
            else
            {
                buttonHandlingMethod.Image = Resources.expand_icon;
                dropDownPanel1.Height -= 10;
                if (dropDownPanel1.Size == dropDownPanel1.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed1 = true;
                }
            }
        }
    }
}
