using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRG282_Project.BusinessLogicLayer;
using PRG282_Project.DataLayer;
using PRG282_Project.PresentationLayer;

namespace PRG282_Project.PresentationLayer
{
    public partial class ModuleForm : Form
    {
        public ModuleForm()
        {
            InitializeComponent();
        }

        DataHandler handler = new DataHandler();                                                                         // create an instance of the datahandler class

        private void ModuleForm_Load(object sender, EventArgs e)
        {
            dgvModules.DataSource = handler.GetModules();                                                                // read all modules in database
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Module module = new Module(int.Parse(txtModCode.Text), txtModName.Text, txtModDesc.Text, txtLinks.Text);     // create an instance of module classs and fill with textbox values        
            handler.InsertModule(module);                                                                                // add module to database
            MessageBox.Show("Module added successfully.");                                                               // display a message to show that module was added successfully
        }

        private void btnUpdate_Click(object sender, EventArgs e)    
        {
            Module module = new Module(int.Parse(txtModCode.Text), txtModName.Text, txtModDesc.Text, txtLinks.Text);     // create an instance of module classs and fill with textbox values
            try
            {
                handler.UpdateModule(module);                                                                           // update module in database
                MessageBox.Show("Module updated successfully");                                                         // show a message for successful update completion
            }
            catch (Exception error)
            {
                Console.WriteLine($"An error occured while trying to update module:\n{error.Message}");                 // show that an error occured and show the error message
            }
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {    
            int id= int.Parse(txtModCode.Text);                                                                         // set the module code textbox as the value for the id
            this.dgvModules.DataSource = null;                                                                          // clear the dataGridView(DGV)
            this.dgvModules.Rows.Clear();
            dgvModules.DataSource = handler.SearchModule(id);                                                           // set the search result as the output of the DGV
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtModCode.Text);                                                                         // set the module code textbox as the value for the id
            try
            {
                handler.DeleteModule(id);                                                                                // delete the module from the database
                MessageBox.Show("Module deleted succesfully.");                                                          // show a message that the module has been deleted                      
            }
            catch (Exception em)
            {

                Console.WriteLine($"An error occured while trying to delete the module with id {id}:\n{em.Message}");     // show that an error occured and show the error message
            }
          
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentForm sForm = new StudentForm();                                                                        // create instance of student form
            this.Hide();                                                                                                  // hide the current form
            sForm.Show();                                                                                                 // show the student form            
        }
    }
}
