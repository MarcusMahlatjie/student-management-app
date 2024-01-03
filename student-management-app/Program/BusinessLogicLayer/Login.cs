using PRG282_Project.PresentationLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_Project.BusinessLogicLayer
{
    internal class Login
    {
        string file = @"userCredentials.txt";
        
        public void Register(string username, string password)
        {

            if (ValidateCredentials(username, password))                                                // check if login details already exist in the file
            {
                 MessageBox.Show("Login details already exist, please navigate to login form");         // display a message stating that the login details already exist
            }
            else
            {
            try
            {
                using (StreamWriter writer = File.AppendText(file))                                     // use a StreamWriter to append the new login details to the file
                {
                     writer.WriteLine($"{username},{password}");                                        // enter the username split by a comma into a line in the file
                     MessageBox.Show("Registration completed succesfully.");                            // display a message stating that the registration was successful
                }
            }
                catch (Exception e)                                                                     // catch the error
                {

                    Console.WriteLine($"An error occured:\n{e.Message}");                               // display a message statng that an error occured and show the error message
                }
              
            }
        }

        public bool ValidateCredentials(string username, string password)
        {
            bool valid = false;
            if (File.Exists(file))                                                                      // check if file exists
            {
                foreach (var line in File.ReadAllLines(file))                                           // read all content stored in file
                {
                    string[] credentials = line.Split(',');                                             // split all credentials at the comma and store them in an array index

                    if (credentials.Length == 2)                                                        // make sure that the array only accepts two values
                    {
                        if ( (username == credentials[0]) && (password == credentials[1]))              // check if the username and password match any of the records in file 
                        { 
                            valid = true;                                                               // set the validation to return true
                        }
                        else if ((username != credentials[0]) && (password == credentials[1]))          // if statement for the case that username is incorrect but password is correct
                        {
                            MessageBox.Show("Invalid username entered.");                               // display a message stating the username entered is incorrect
                        }
                        else if ((username == credentials[0]) && (password != credentials[1]))          // if statement for the case that username is correct but password is incorrect
                        {
                            MessageBox.Show("Invalid password entered.");                               // display a message stating the password entered is incorrect
                        }
                        else                                                                            // else statement for the case that both parameters are wrong
                        {
                            MessageBox.Show("The login details you have entered do not exist, please register before attempting to login");             // display an error message asking user to register first
                        }
                        
                    }

                }
            }

           return valid;                                                                                // return the result of the validation
           
        }
    }
}
