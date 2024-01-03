using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PRG282_Project.DataLayer;

namespace PRG282_Project.BusinessLogicLayer
{
    internal class DataHandler
    {
        DataTable table;
        SqlDataAdapter adapter;
        string query;
        const string connect = "Server = EYECON-PC\\SQLEXPRESS; Initial Catalog = BCiTS; Integrated Security = SSPI ";
        SqlConnection conn = new SqlConnection(connect);

       

        public DataTable GetStudents()                                                    // retrieve student data from database
        {

            query = @"SELECT * FROM tbl_Student";                                             // set SQL command to retrieve all students in database
        
            adapter = new SqlDataAdapter(query, conn);                                      // execute sql command in DB and store values in adapter
            table = new DataTable();                                                           // instanciate the datatable
            adapter.Fill(table);                                                               // add all data stored in adapter to the table

            return table;                                                                      // return all data stored in table
        }

        public DataTable GetModules()                                                     // retrieve module data from database
        {

            query = @"SELECT * FROM tbl_Modules";                                              // set SQL command to retrieve all modules in database
            adapter = new SqlDataAdapter(query, conn);                                      // execute sql command in DB and store values in adapter
            table = new DataTable();                                                           // instanciate the datatable
            adapter.Fill(table);                                                               // add all data stored in adapter to the table
                                                                            
            return table;                                                                      // return all data stored in table
        }

        public void InsertStudent(Student student)
        {           
            
            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;                                 // set command type as type stored procedure
                cmd.Parameters.AddWithValue("@ID", student.StdNo);                             // add values of student class as parameters for stored procedure
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Surname", student.Surname);
                cmd.Parameters.AddWithValue("@Phone", student.Phone);               
                cmd.Parameters.AddWithValue("@DOB", student.Dob);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Address", student.Address);            
                conn.Open();                                                                    // open connection
                cmd.ExecuteNonQuery();                                                          // execute query 
                conn.Close();                                                                   // terminate connection
                }
            
        }

        public void InsertModule(DataLayer.Module module)                                       // insert a new module
        {        

            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("spAddMod", conn);
                cmd.CommandType= CommandType.StoredProcedure;                                   // set command type as type stored procedure
                cmd.Parameters.AddWithValue("@ModCode",module.ModCode);
                cmd.Parameters.AddWithValue("@Name",module.ModName);
                cmd.Parameters.AddWithValue("@Desc",module.ModDesc);
                cmd.Parameters.AddWithValue("@Link",module.ModLinks);
                conn.Open();                                                                    // open connection
                cmd.ExecuteNonQuery();                                                          // execute query 
                conn.Close();                                                                   // terminate connection

            }
        }

        public void InsertStudentModule(Student student, int ModCode)                           // insert student into new module code
        {

            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("spAddStudentModule", conn);
                cmd.CommandType = CommandType.StoredProcedure;                                  // set command type as type stored procedure
                cmd.Parameters.AddWithValue("@StudNo", student.StdNo);
                cmd.Parameters.AddWithValue("@ModCode", ModCode);
                conn.Open();                                                                    // open connection
                cmd.ExecuteNonQuery();                                                          // execute query
                conn.Close();                                                                   // terminate connection
            }

        }
        public void UpdateStudent(Student student)
        {
            
            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;                                  // set command type as type stored procedure
                cmd.Parameters.AddWithValue("@ID", student.StdNo);                              // add values of student class as parameters for stored procedure
                cmd.Parameters.AddWithValue("@Name", student.Name);                             
                cmd.Parameters.AddWithValue("@Surname", student.Surname);
                cmd.Parameters.AddWithValue("@Phone", student.Phone);
                cmd.Parameters.AddWithValue("@DOB", student.Dob);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                conn.Open();                                                                    // open connection
                cmd.ExecuteNonQuery();                                                          // execute query
                conn.Close();                                                                   // terminate connection           
            }

        }

        public void UpdateModule(DataLayer.Module module)
        {           

            using (SqlConnection conn = new SqlConnection(connect))                              // establish database connection
            {
                SqlCommand cmd = new SqlCommand("spUpdateModule", conn);
                cmd.CommandType = CommandType.StoredProcedure;                                   // set command type as type stored procedure
                cmd.Parameters.AddWithValue("@ModCode", module.ModCode);
                cmd.Parameters.AddWithValue("@Name", module.ModName);
                cmd.Parameters.AddWithValue("@Desc", module.ModDesc);
                cmd.Parameters.AddWithValue("@Link", module.ModLinks);
                conn.Open();                                                                     // open connection
                cmd.ExecuteNonQuery();                                                           // execute query
                conn.Close();                                                                    // terminate connection  

            }

        }

        public void DeleteStudent(int id)
        {
            string query = $"DELETE FROM tbl_Student WHERE StudentNumber = {id}";
            string q2 = $"DELETE FROM tbl_StudentModules WHERE StudentNumber = {id}";

            using (SqlConnection conn = new SqlConnection(connect))                               // establish database connection
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))                              // create an instance of the command class to execute the query
                {
                    SqlCommand command = new SqlCommand(q2,conn);                                 
                    conn.Open();                                                                  // open connection
                    command.ExecuteNonQuery();                                                    // delete record of student in student module table
                    cmd.ExecuteNonQuery();                                                        // execute query
                    conn.Close();                                                                 // terminate connection 
                }
            }
        }

        public void DeleteModule(int code)
        {
            string query = $@"DELETE FROM tbl_Modules WHERE ModuleCode = {code}";                // store the SQL statement to be used in the database
            string q2 = $"DELETE FROM tbl_StudentModules WHERE ModuleCode = {code}";

            using (SqlConnection conn = new SqlConnection(connect))                               // establish database connection
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))                              // create an instance of the command class to execute the query
                {
                    SqlCommand command = new SqlCommand(q2, conn);
                    conn.Open();                                                                  // open connection
                    command.ExecuteNonQuery();                                                    // delete record of module in student module table
                    cmd.ExecuteNonQuery();                                                        // execute query
                    conn.Close();                                                                 // terminate connection 
                }
            }
        }

        public DataTable SearchStudent(int id)
        {
            string query = $@"SELECT * FROM tbl_Student WHERE StudentNumber = {id}";             // store the SQL statement to be used in the database
            adapter = new SqlDataAdapter(query, conn);                                          // execute sql command in DB and store values in adapter 
            table = new DataTable();                                                             // instanciate the datatable
            adapter.Fill(table);                                                                 // add all data stored in adapter to the table

            return table;                                                                        // return all data stored in table                                   
        }

        public DataTable SearchModule(int code)
        {
            string query = $@"SELECT * FROM tbl_Modules WHERE ModuleCode = {code}";             // store the SQL statement to be used in the database
            adapter = new SqlDataAdapter(query, conn);                                       // execute sql command in DB and store values in adapter 
            table = new DataTable();                                                            // instanciate the datatable
            adapter.Fill(table);                                                                // add all data stored in adapter to the table

            return table;                                                                       // return all data stored in table  
        }
    }
}
