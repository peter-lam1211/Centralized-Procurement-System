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
    public partial class StaffManageForm : Form
    {
        public CreateStaffForm createStaffForm = new CreateStaffForm();

        public EditStaffForm editStaffForm = new EditStaffForm();

        public StaffManageForm()
        {
            InitializeComponent();
        }

        public static bool EventBlock = false;

        public void ReloadUsers()
        {
            dataGridView1.Rows.Clear();
            foreach (User user in User.GetUsers())
            {
                dataGridView1.Rows.Add(new object[] { user.id, user.name, user.department.name, user.position, user.createDate.ToString("yyyy-MM-dd") });
            }
            Department.UploadComboBox(comboBox1, "All");
            EventBlock = true;
            comboBox1.SelectedIndex = 0;
            EventBlock = false;
        }

        private void StaffManageForm_Shown(object sender, EventArgs e)
        {

            ReloadUsers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //Edit
            if (e.ColumnIndex == 5)
            {
                editStaffForm.user = User.GetUser((string)row.Cells[0].Value);
                editStaffForm.OnShow();
                editStaffForm.ShowDialog();
            }
            //Delete
            else if(e.ColumnIndex == 6)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete " + row.Cells[1].Value + "?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    User.Delete((string)row.Cells[0].Value);
                    ReloadUsers();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createStaffForm.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(EventBlock)
                return;
            dataGridView1.Rows.Clear();
            IEnumerable<User> users = comboBox1.SelectedItem.GetType() == typeof(string) ? User.GetUsers() : User.SearchUsers("", (Department)comboBox1.SelectedItem);
            foreach (User user in users)
            {
                dataGridView1.Rows.Add(new object[] { user.id, user.name, user.department.name, user.position, user.createDate.ToString("yyyy-MM-dd") });
            }
        }
    }
}
