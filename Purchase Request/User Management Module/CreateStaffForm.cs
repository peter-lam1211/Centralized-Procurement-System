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
    public partial class CreateStaffForm : Form
    {
        public CreateStaffForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Select one")
            {
                MessageBox.Show("The department is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBox2.Text == "Select one")
            {
                MessageBox.Show("The position is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String name = textBox1.Text;
            if(name == "")
            {
                MessageBox.Show("Please input the staff's name");
                return;
            }
            User user = new User(User.GetAllowID(), name, dateTimePicker1.Value, ((Department)comboBox1.SelectedItem).id, comboBox2.Text, textBox3.Text, textBox2.Text, DateTime.Now);
            User.Create(user);
            mainPage.staffManageForm.ReloadUsers();
        }

        private void CreateStaffForm_Load(object sender, EventArgs e)
        {
            Department.UploadComboBox(comboBox1, "Select one");
            comboBox1.SelectedIndex = 0;

            comboBox2.SelectedIndex = 0;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            textBox1.Text = dateTimePicker1.Text = textBox2.Text = textBox3.Text = String.Empty;
        }
    }
}
