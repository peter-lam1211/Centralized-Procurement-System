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
    public partial class CreateItemForm : Form
    {
        public CreateItemForm()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            textBox1.Text = textBox2.Text = richTextBox1.Text = String.Empty;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void CreateItemForm_Shown(object sender, EventArgs e)
        {
            ItemCategory.Reload();
            ItemCategory.UploadComboBox(this.comboBox1, "Select one");
            comboBox1.SelectedIndex = 0;
            Supplier.UploadComboBox(this.comboBox2, "Select one");
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedItem = this.comboBox1.SelectedItem;
            var selectedItem2 = this.comboBox2.SelectedItem;
            if (selectedItem == null || comboBox1.Text == "Select one")
            {
                MessageBox.Show("Please select the ItemCategory");
                return;
            }
            if(selectedItem2 == null || selectedItem2.GetType() != typeof(Supplier) || comboBox2.Text == "Select one")
            {
                MessageBox.Show("Please select the Supplier");
                return;
            }
            Supplier supplier = selectedItem2 as Supplier;
            ItemCategory itemCategory = ItemCategory.GetName(selectedItem.ToString());
            if (itemCategory == null)
                return;
            String name = this.textBox1.Text;
            if(name == "")
            {
                MessageBox.Show("Please input item's name");
                return;
            }
            Item item = new Item(Item.GetAllowID(itemCategory.id), name, this.textBox2.Text, "" + itemCategory.id, this.richTextBox1.Text, supplier.getStringId());
            Item.Create(item);
            mainPage.stockListForm.ReloadItems();

            Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
