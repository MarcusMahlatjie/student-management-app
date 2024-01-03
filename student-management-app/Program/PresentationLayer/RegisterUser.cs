using PRG282_Project.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_Project.PresentationLayer
{
    public partial class RegisterUser : Form
    {
        Login login = new Login();
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 login = new Form1();                                                                                      // create an instance of the login form
            this.Hide();                                                                                                    // hide the current form
            login.Show();                                                                                                   // show the login form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirm.Text)                                                                        // check if the passwords match
            {
                MessageBox.Show("The passwords entered do not match, please ensure that the password is the same.");        // display an error saying passwords must match
            }
            else 
            {
                login.Register(txtUsername.Text,txtPassword.Text);                                                          // register the user, write details into the text file
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) 
            {
                txtPassword.UseSystemPasswordChar = false;                                      // show password
                txtConfirm.UseSystemPasswordChar = false;
            }
            else 
            {
                txtPassword.UseSystemPasswordChar = true;                                       // hide password
                txtConfirm.UseSystemPasswordChar = true;
            }
        }

        private void RegisterUser_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;                                       // hide password
            txtConfirm.UseSystemPasswordChar = true;
        }
    }
}
