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
    public partial class createPurchaseAgreementItemDetail : Form
    {
        public createPurchaseAgreementItemDetail()
        {
            InitializeComponent();
        }

        public void Display()
        {
            other.DisplayAndSearch("SELECT itemID, itemName FROM item", dataGridView1);
        }

        private void createPurchaseAgreementItemDetail_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            other.DisplayAndSearch("SELECT itemID, itemName FROM item WHERE itemID LIKE '%" + txtSearch.Text + "%'", dataGridView1);
        }
    }
}
