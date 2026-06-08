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
    public partial class EditStaffForm : Form
    {
        public User user = null;

        public EditStaffForm()
        {
            InitializeComponent();
        }

        public void OnShow()
        {
            textBox1.Text = user.id;
            textBox2.Text = user.name;
            Department.UploadComboBox(comboBox1, null);
            comboBox1.SelectedItem = user.department;
            comboBox2.Text = user.position;
            textBox3.Text = user.email;
            textBox4.Text = user.password;
            dateTimePicker1.Value = user.birthday;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user.id = textBox1.Text;
            user.name = textBox2.Text;
            user.department = (Department)comboBox1.SelectedItem;
            user.position = comboBox2.Text;
            user.email = textBox3.Text;
            user.password = textBox4.Text;
            user.birthday = dateTimePicker1.Value;
            User.Update(user);
            mainPage.staffManageForm.ReloadUsers();
        }

        private void EditStaffForm_Load(object sender, EventArgs e)
        {

        }
    }
}
