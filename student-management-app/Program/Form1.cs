using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRG282_Project.BusinessLogicLayer;
using PRG282_Project.PresentationLayer;
using System.Threading;

namespace PRG282_Project
{   
    public partial class Form1 : Form
    {
        Login login = new Login();                                                                      // create an instance of the login class
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if (login.ValidateCredentials(txtUsername.Text, txtPassword.Text) == true)                 // check if the details entered exist    
            {
                StudentForm sForm = new StudentForm();                                                 // create an instance of the user form
                MessageBox.Show("Login successful");                                                   // show a message that the login was successful       
                this.Hide();                                                                           // hide the current form
                sForm.Show();                                                                          // display the students form
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterUser registerUser = new RegisterUser();                                             // create instance of registration form
            this.Hide();                                                                                // hide the current form
            registerUser.Show();                                                                        // show the registration form
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;                              // show password 
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;                              // hide password 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
