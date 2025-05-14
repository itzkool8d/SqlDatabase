using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlDatabase
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = userinput.Text.Trim();
            string password = passinput.Text.Trim();

            if (username == "admin" && password == "admin")
            {
                AdminForm adminForm = new AdminForm();
                adminForm.FormClosed += (s, args) =>
                {
                    this.Show();
                    userinput.Text = "";
                    passinput.Text = "";
                };
                adminForm.Show();
                this.Hide();
            }
            else if (username == "owner" && password == "owner")
            {
                OwnerForm ownerForm = new OwnerForm();
                ownerForm.FormClosed += (s, args) =>
                {
                    this.Show();
                    userinput.Text = "";
                    passinput.Text = "";
                };
                ownerForm.Show();
                this.Hide();
            }
            else if (username == "user" && password == "user")
            {
                UserForm userForm = new UserForm();
                userForm.FormClosed += (s, args) =>
                {
                    this.Show();
                    userinput.Text = "";
                    passinput.Text = "";
                };
                userForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

    }
}
