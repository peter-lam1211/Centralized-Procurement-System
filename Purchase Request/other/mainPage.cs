using Purchase_Request.Properties;
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
    public partial class mainPage : Form
    {
        private bool isCollapsed1 = true;
        private bool isCollapsed2 = true;
        private bool isCollapsed3 = true;
        private bool isCollapsed4 = true;
        private bool isCollapsed5 = true;

        public static dashboard form_dashboard = new dashboard();

        //Restaurant Module
        public static purchaseRequest form_purchaseRequest = new purchaseRequest();
        public static restaurantStock form_restaurantStock = new restaurantStock();
        public static updateDeliveryNote form_updateDeliveryNote = new updateDeliveryNote();

        //Purchase Module
        public static purchaseAgreement form_purchaseAgreement = new purchaseAgreement();
        public static requestMapping form_requestMapping = new requestMapping();
        public static deliveryRequest form_deliveryRequest = new deliveryRequest();
        public static order_release form_order_release = new order_release();

        //Inventory Module
        public static StockListForm stockListForm = new StockListForm();
        public static deliveryNote form_deliveryNote = new deliveryNote();
        public static supplierList form_supplierList = new supplierList();

        //Accounting Module
        public static updateOrderRelease form_updateOrderRelease = new updateOrderRelease();


        //Admin Module
        public static StaffManageForm staffManageForm = new StaffManageForm();
        public static activityLogging form_activityLogging = new activityLogging();

        public mainPage()
        {
            InitializeComponent();
        }

        private void mainPage_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer2.Start();
        }

        public void loadform(object form)
        {
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);
            Form selectForm = form as Form;
            selectForm.TopLevel = false;
            selectForm.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(selectForm);
            this.mainPanel.Tag = selectForm;
            selectForm.Show();
        }

        private void buttonDashboard_Click_1(object sender, EventArgs e)
        {
            loadform(form_dashboard);
        }

        private void buttonRestaurant_Click(object sender, EventArgs e)
        {
            if (!Permission.TryExecute("restaurantModule.access"))
                return;
            timer1.Start();
        }

        private void buttonPurchase_Click(object sender, EventArgs e)
        {
            if (!Permission.TryExecute("purchaseModule.access"))
                return;
            timer3.Start();
        }

        private void buttonInventory_Click(object sender, EventArgs e)
        {
            if (!Permission.TryExecute("inventoryModule.access"))
                return;
            timer4.Start();
        }

        private void buttonAccounting_Click(object sender, EventArgs e)
        {
            if (!Permission.TryExecute("accountingModule.access"))
                return;
            timer5.Start();
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            if (!Permission.TryExecute("adminModule.access"))
                return;
            timer6.Start();
        }

        //Restaurant Module
        private void button_purchaseRequest_Click(object sender, EventArgs e)
        {
            loadform(form_purchaseRequest);
        }

        private void button_restaurantItem_Click(object sender, EventArgs e)
        {
            loadform(form_restaurantStock);
        }

        private void button_specialDelivery_Click(object sender, EventArgs e)
        {
            loadform(form_updateDeliveryNote);
        }

        //Purchase Module
        private void button_purchaseAgreement_Click(object sender, EventArgs e)
        {
            loadform(form_purchaseAgreement);
        }

        private void button_requestMapping_Click(object sender, EventArgs e)
        {
            loadform(form_requestMapping);
        }

        private void button_order_release_Click(object sender, EventArgs e)
        {
            loadform(form_order_release);
        }

        private void button_deliveryRequest_Click(object sender, EventArgs e)
        {
            loadform(form_deliveryRequest);
        }

        //Invenotry Module
        private void button_warehouseItem_Click(object sender, EventArgs e)
        {
            loadform(stockListForm);
        }

        private void button_deliveryNote_Click(object sender, EventArgs e)
        {
            loadform(form_deliveryNote);
        }

        private void button_supplierList_Click(object sender, EventArgs e)
        {
            if (!Permission.TryExecute("supplier.management"))
                return;
            loadform(form_supplierList);
        }

        //Admin Module
        private void button_userList_Click(object sender, EventArgs e)
        {
            loadform(staffManageForm);
        }

        private void button_activityLogging_Click(object sender, EventArgs e)
        {
            loadform(form_activityLogging);
        }

        //Accounting Module

        private void button_updateOrderRelease_Click(object sender, EventArgs e)
        {
            loadform(form_updateOrderRelease);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed1)
            {
                buttonRestaurant.Image = Resources.expand_icon__reverse_;
                dropDownPanel1.Height += 10;
                if (dropDownPanel1.Size == dropDownPanel1.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed1 = false;
                }
            }
            else
            {
                buttonRestaurant.Image = Resources.expand_icon;
                dropDownPanel1.Height -= 10;
                if (dropDownPanel1.Size == dropDownPanel1.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed1 = true;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {
                buttonPurchase.Image = Resources.expand_icon__reverse_;
                dropDownPanel2.Height += 10;
                if (dropDownPanel2.Size == dropDownPanel2.MaximumSize)
                {
                    timer3.Stop();
                    isCollapsed2 = false;
                }
            }
            else
            {
                buttonPurchase.Image = Resources.expand_icon;
                dropDownPanel2.Height -= 10;
                if (dropDownPanel2.Size == dropDownPanel2.MinimumSize)
                {
                    timer3.Stop();
                    isCollapsed2 = true;
                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (isCollapsed3)
            {
                buttonInventory.Image = Resources.expand_icon__reverse_;
                dropDownPanel3.Height += 10;
                if (dropDownPanel3.Size == dropDownPanel3.MaximumSize)
                {
                    timer4.Stop();
                    isCollapsed3 = false;
                }
            }
            else
            {
                buttonInventory.Image = Resources.expand_icon;
                dropDownPanel3.Height -= 10;
                if (dropDownPanel3.Size == dropDownPanel3.MinimumSize)
                {
                    timer4.Stop();
                    isCollapsed3 = true;
                }
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (isCollapsed4)
            {
                buttonAccounting.Image = Resources.expand_icon__reverse_;
                dropDownPanel4.Height += 10;
                if (dropDownPanel4.Size == dropDownPanel4.MaximumSize)
                {
                    timer5.Stop();
                    isCollapsed4 = false;
                }
            }
            else
            {
                buttonAccounting.Image = Resources.expand_icon;
                dropDownPanel4.Height -= 10;
                if (dropDownPanel4.Size == dropDownPanel4.MinimumSize)
                {
                    timer5.Stop();
                    isCollapsed4 = true;
                }
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (isCollapsed5)
            {
                buttonAdmin.Image = Resources.expand_icon__reverse_;
                dropDownPanel5.Height += 10;
                if (dropDownPanel5.Size == dropDownPanel5.MaximumSize)
                {
                    timer6.Stop();
                    isCollapsed5 = false;
                }
            }
            else
            {
                buttonAdmin.Image = Resources.expand_icon;
                dropDownPanel5.Height -= 10;
                if (dropDownPanel5.Size == dropDownPanel5.MinimumSize)
                {
                    timer6.Stop();
                    isCollapsed5 = true;
                }
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
