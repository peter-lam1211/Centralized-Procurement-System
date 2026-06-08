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
    public partial class CreateItemCategoryForm : Form
    {
        public CreateItemCategoryForm()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            textBox1.Text = richTextBox1.Text = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = this.textBox1.Text;
            if (name == "")
            {
                MessageBox.Show("Please input item category's name");
                return;
            }
            ItemCategory itemCategory = new ItemCategory(ItemCategory.GetAllowID(name), name, this.richTextBox1.Text);
            ItemCategory.Create(itemCategory);
            mainPage.stockListForm.itemCategoryForm.ReloadItemCategorys();
            mainPage.stockListForm.ReloadItems();

            Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void CreateItemCategoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
