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
    public partial class EditItemCategoryForm : Form
    {
        public EditItemCategoryForm()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            textBox2.Text = richTextBox1.Text = String.Empty;
        }

        public void OnShown()
        {
            ItemCategory itemCategory = ItemCategory.GetItemCategory(textBox1.Text);
            if (itemCategory == null)
                return;
            textBox2.Text = itemCategory.name;
            richTextBox1.Text = itemCategory.description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ItemCategory itemCategory = new ItemCategory(textBox1.Text, textBox2.Text, richTextBox1.Text);
            ItemCategory.Update(itemCategory);
            mainPage.stockListForm.itemCategoryForm.ReloadItemCategorys();
            mainPage.stockListForm.ReloadItems();

            Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void EditItemCategoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
