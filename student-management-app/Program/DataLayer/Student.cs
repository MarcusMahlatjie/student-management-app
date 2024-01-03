using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282_Project.DataLayer
{
    internal class Student
    {

        private int phone, stdNo;                                                           // create private variables to store values
        private string dob;
        char gender;
        string  address;
        private string name;
        private string surname;
        

        public int StdNo { get => stdNo; set => stdNo = value; }                           // create public properties to retrieve and set values to variables
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Dob { get => dob; set => dob = value; }
        
        public char Gender { get => gender; set => gender = value; }
        public int Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }

        public Student()
        {
        }

        public Student(int stdNo, string name, string surname, string dob, char gender, int phone, string address)          // create constructor to get user input
        {
            this.StdNo = stdNo;                                                                             // allocate the right input value to the correct property
            this.Name = name;
            this.Surname = surname;           
            this.Dob = dob;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;          
        }     
       
    }
}
