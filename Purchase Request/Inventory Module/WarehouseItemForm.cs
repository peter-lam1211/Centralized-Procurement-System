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
    public partial class WarehouseItemForm : Form
    {
        public static bool comboBoxEventBlock = false;

        public Item item = null;

        public WarehouseItemForm()
        {
            InitializeComponent();
        }

        private void WarehouseItemForm_Shown(object sender, EventArgs e)
        {
            Warehouse.UploadComboBox(this.comboBox1, null);
        }

        public void BeforeShow()
        {
            Warehouse.UploadComboBox(this.comboBox1, null);

            comboBoxEventBlock = true;
            this.comboBox1.SelectedIndex = 0;
            int quantity = item.GetQuantity((Warehouse)this.comboBox1.SelectedItem);
            textBox3.Text = "" + quantity;
            textBox4.Text = "0";
            comboBoxEventBlock = false;

            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(new object[] { WarehouseItem.EditMode.Modify, WarehouseItem.EditMode.Add, WarehouseItem.EditMode.Remove });
            comboBox2.SelectedItem = WarehouseItem.EditMode.Modify;
            textBox2.Text = item.name;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxEventBlock || item == null)
                return;
            int quantity = item.GetQuantity((Warehouse)this.comboBox1.SelectedItem);
            textBox3.Text = "" + quantity;
        }

        public void updateNewQuantity()
        {
            int quantity = 0, value = 0;
            try {
                quantity = Convert.ToInt32(textBox3.Text);
                value = Convert.ToInt32(textBox4.Text);
            }
            catch(FormatException ex)
            { 
                return;
            }
            switch(comboBox2.SelectedItem)
            {
                case WarehouseItem.EditMode.Add:
                    quantity += value;
                    break;
                case WarehouseItem.EditMode.Remove:
                    quantity -= value;
                    break;
                case WarehouseItem.EditMode.Modify:
                    quantity = value;
                    break;
            }
            textBox5.Text = "" + quantity;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEventBlock)
                return;
            updateNewQuantity();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxEventBlock)
                return;
            updateNewQuantity();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = 0;
            try
            {
                value = Convert.ToInt32(textBox4.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Value should be integer");
                return;
            }
            WarehouseItem.Update(WarehouseItem.GetWarehouseItem((Warehouse)this.comboBox1.SelectedItem, item), (WarehouseItem.EditMode)comboBox2.SelectedItem, value);
            WarehouseItem.Reload();
            mainPage.stockListForm.ReloadItems();
        }

        private void WarehouseItemForm_Load(object sender, EventArgs e)
        {

        }
    }
}
