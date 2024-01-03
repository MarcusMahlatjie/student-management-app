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
using System.Data.SqlClient;
using PRG282_Project.DataLayer;
using PRG282_Project.PresentationLayer;
using System.Drawing.Imaging;
using System.IO;

namespace PRG282_Project.PresentationLayer
{
    public partial class StudentForm : Form
    {
        const string DB = "SERVER = EYECON-PC\\SQLEXPRESS; INITIAL CATALOG = BCiTs ; INTEGRATED SECURITY = SSPI";
        public StudentForm()
        {
            InitializeComponent();
        }

        DataHandler handler = new DataHandler();

        private void StudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvStudents.DataSource = handler.GetStudents();                                         // show all students in DataGridView
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error has occured:\n{ex.Message}");
            }
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Student student = new Student(int.Parse(txtStdNo.Text), txtFirstName.Text, txtSurname.Text,
                              txtDOB.Text, char.Parse(txtGender.Text), int.Parse(txtPhone.Text), txtAddress.Text);

            handler.InsertStudent(student);                                                         // add student to database
            handler.InsertStudentModule(student, int.Parse(txtModCode.Text));                       // add student to module in database

            MessageBox.Show("Student added successfully.");                                         // show message for successful insert completion

            dgvStudents.DataSource = "";                                                            // remove all data from DataGridView
            dgvStudents.DataSource = handler.GetStudents();                                         // fetch all data in database 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = new Student(int.Parse(txtStdNo.Text), txtFirstName.Text, txtSurname.Text,
                              txtDOB.Text, char.Parse(txtGender.Text), int.Parse(txtPhone.Text), txtAddress.Text);   //  Create an instance of the student class and fill values from textboxes

            handler.UpdateStudent(student);                                                         // update student in database 

            MessageBox.Show("Changes saved succesfully.");                                          // display a message showing that the details were changed successfully
            dgvStudents.DataSource = "";                                                            // remove all data from DataGridView
            dgvStudents.DataSource = handler.GetStudents();                                         // fetch all data in database 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtStdNo.Text);                                                      // set the id as the value in the student number textbox
            this.dgvStudents.DataSource = null;                                                     // clear the dataGridView
            this.dgvStudents.Rows.Clear();
            dgvStudents.DataSource = handler.SearchStudent(id);                                     // set the result of rhe search to be the input for the dataGridView
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtStdNo.Text);                                                      // set the id as the value in the student number textbox
            try
            {               
                handler.DeleteStudent(id);                                                          // delete the record of the student in the database
                MessageBox.Show("Student deleted successfully.");                                   // show a message stating that the delete was successful
            }
            catch (Exception err)                                                                   // catch exception error
            {

                Console.WriteLine($"An error occured while attempting the removal of the student with id {id}:\n{err.Message}");  // display a message for the error and what the error is
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModuleForm form = new ModuleForm();                                                             
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";
            openFileDialog.Title = "Select an Image";
            byte[] imageBytes = null;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Bitmap selectedImage = new System.Drawing.Bitmap(openFileDialog.FileName))           // store the selected image in a variable
                    {
                        // Convert the selected image to a byte array
                        using (MemoryStream stream = new MemoryStream())
                        {
                            selectedImage.Save(stream, ImageFormat.Jpeg);                                       // Change picture format to the one selected
                            imageBytes = stream.ToArray();
                        }
                    }

                    studPicture.Image = new Bitmap(openFileDialog.FileName);                                    // display the slected image in the picturebox
                    studPicture.SizeMode = PictureBoxSizeMode.AutoSize;                                         // auto-size the image to display correctly

                    using (SqlConnection conn = new SqlConnection(DB))
                    {
                        SqlCommand cmd = new SqlCommand("sp_InsertImage", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", txtStdNo.Text);
                        cmd.Parameters.AddWithValue("@Picture", imageBytes);                                    // Pass byte array instead of Bitmap object
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }               
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }
    }
}
