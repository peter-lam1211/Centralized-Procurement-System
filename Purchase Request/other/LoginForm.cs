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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = User.Login(textBox1.Text, textBox2.Text);
            if(user == null)
            {
                MessageBox.Show("Email / Password is incorrent");
                return;
            }
            this.Hide();
            Program.form1.label5.Text = user.department.name.Replace(" ", "\n");
            Program.form1.label8.Text = user.position.Replace(" ", "\n");
            Program.form1.label9.Text = user.name;
            Program.form1.label10.Text = user.id;
            Permission.user = user;
            Program.form1.ShowDialog();
            Permission.user = null;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.Show();
        }
    }
}
