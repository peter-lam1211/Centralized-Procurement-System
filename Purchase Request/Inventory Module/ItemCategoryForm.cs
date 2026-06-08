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
    public partial class ItemCategoryForm : Form
    {
        public EditItemCategoryForm editItemCategoryForm = new EditItemCategoryForm();

        public CreateItemCategoryForm createItemCategoryForm = new CreateItemCategoryForm();
        public ItemCategoryForm()
        {
            InitializeComponent();
        }

        private void ItemCategoryForm_Shown(object sender, EventArgs e)
        {
            ReloadItemCategorys();
        }

        public void ReloadItemCategorys()
        {
            ItemCategory.Reload();
            this.dataGridView1.Rows.Clear();
            foreach (ItemCategory itemCategory in ItemCategory.GetItemCategorys())
            {
                this.dataGridView1.Rows.Add(itemCategory.id, itemCategory.name);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit
            if (e.ColumnIndex == 2)
            {
                editItemCategoryForm.textBox1.Text = "" + this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                editItemCategoryForm.OnShown();
                editItemCategoryForm.ShowDialog();
            }
            //delete
            else if (e.ColumnIndex == 3)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                DialogResult dialogResult = MessageBox.Show("Are you sure to delete " + row.Cells[1].Value + "?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    ItemCategory.Delete((string)row.Cells[0].Value);
                    ReloadItemCategorys();
                    mainPage.stockListForm.ReloadItems();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createItemCategoryForm.ShowDialog();
        }

        private void ItemCategoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
