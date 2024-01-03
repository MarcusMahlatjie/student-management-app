using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282_Project.DataLayer
{
    internal class StudentModule                        // used to store the module codes and student numbers
                                                       //  to create many to many relationship in database
    {
        public int StudentNumber { get; set; }  
        public int ModuleCode { get;set; }

        public StudentModule() { }

        public StudentModule(int studentNumber, int moduleCode) 
        {
            this.StudentNumber = studentNumber; 
            this.ModuleCode = moduleCode;         
        }
    }
}
