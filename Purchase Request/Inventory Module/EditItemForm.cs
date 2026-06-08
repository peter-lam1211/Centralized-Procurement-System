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
    public partial class EditItemForm : Form
    {
        public EditItemForm()
        {
            InitializeComponent();
        }

        public void OnShown()
        {
            Item item = Item.GetItem(this.textBox1.Text);
            if (item == null)
            {
                MessageBox.Show("Item not found");
                return;
            }
            ItemCategory.UploadComboBox(this.comboBox1, null);
            Supplier.UploadComboBox(this.comboBox2, null);
            this.comboBox1.SelectedItem = item.itemCategory;
            this.comboBox2.SelectedItem = item.supplier;
            this.textBox2.Text = item.name;
            this.textBox3.Text = item.GetStringQuantity();
            this.richTextBox1.Text = item.description;
            this.textBox4.Text = item.unit;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item item = new Item(textBox1.Text, this.textBox2.Text, this.textBox4.Text, "" + (comboBox1.SelectedItem as ItemCategory).id, richTextBox1.Text, (comboBox2.SelectedItem as Supplier).getStringId(), "V" + textBox1.Text);
            Item.Update(item);
            mainPage.stockListForm.ReloadItems();
        }

        private void EditItemForm_Load(object sender, EventArgs e)
        {

        }
    }
}
