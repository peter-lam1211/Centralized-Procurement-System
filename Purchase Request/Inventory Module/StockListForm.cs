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
    public partial class StockListForm : Form
    {

        public Form createItemForm = new CreateItemForm();

        public EditItemForm editItemForm = new EditItemForm();

        public ItemCategoryForm itemCategoryForm = new ItemCategoryForm();

        public WarehouseItemForm warehouseItemForm = new WarehouseItemForm();

        public StockListForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit
            if(e.ColumnIndex == 5)
            {
                if (!Permission.TryExecute("item.edit"))
                    return;
                editItemForm.textBox1.Text = (string)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                editItemForm.OnShown();
                editItemForm.ShowDialog();
            }
            //delete
            else if (e.ColumnIndex == 6)
            {
                if (!Permission.TryExecute("item.delete"))
                    return;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                DialogResult dialogResult = MessageBox.Show("Are you sure to delete " + row.Cells[1].Value + "?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if(dialogResult == DialogResult.Yes)
                {
                    Item.Delete((String)row.Cells[0].Value);
                    ReloadItems();
                }
            }
            //stock
            else if (e.ColumnIndex == 7)
            {
                if (!Permission.TryExecute("item.update_stock"))
                    return;
                warehouseItemForm.item = Item.GetItem((string)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                warehouseItemForm.BeforeShow();
                warehouseItemForm.ShowDialog();
            }
        }

        public void LoadItems(IEnumerable<Item> items)
        {
            this.dataGridView1.Rows.Clear();
            foreach (Item item in items)
            {
                this.dataGridView1.Rows.Add(new object[] { item.GetStringId(), item.name, item.itemCategory.name, item.GetStringQuantity(), item.supplier.name });
            }
            Purchase_Request.ItemCategory.UploadComboBox(this.comboBox1, "All");
            Supplier.UploadComboBox(this.comboBox2, "All");
        }

        public void ReloadItems()
        {
            //LoadItems(Item.GetItems());
            SearchItems();
        }

        public void SearchItems()
        {
            ItemCategory itemCategory = comboBox1.SelectedItem.GetType() == typeof(ItemCategory) ? (ItemCategory)comboBox1.SelectedItem : null;
            Supplier supplier = comboBox2.SelectedItem.GetType() == typeof(Supplier) ? (Supplier)comboBox2.SelectedItem : null;
            LoadItems(Item.SearchItems(textBox1.Text, itemCategory, supplier));
        }

        private void StockListForm_Shown(object sender, EventArgs e)
        {
            LoadItems(Item.GetItems());
            StockListForm.comboBoxEventBlock = true;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            StockListForm.comboBoxEventBlock = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Permission.TryExecute("item.create"))
                return;
            createItemForm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchItems();
        }

        public static bool comboBoxEventBlock = false;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEventBlock)
                return;
            SearchItems();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Permission.TryExecute("itemCategory.management"))
                return;
            itemCategoryForm.ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEventBlock)
                return;
            SearchItems();
        }

        private void StockListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
