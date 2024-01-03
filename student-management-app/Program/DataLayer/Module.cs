using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282_Project.DataLayer
{
    internal class Module
    {
        private int modCode;                                                                    // create private variables to store values
        private string modaName, modDesc, modLinks;
        public int ModCode { get => modCode; set => modCode = value; }                          // create public properties to retrieve and set values to variables
        public string ModName { get => modaName; set => modaName = value; }
        public string ModDesc { get => modDesc; set => modDesc = value; }
        public string ModLinks { get => modLinks; set => modLinks = value; }


        public Module() { }
        
        public Module(int modCode, string modName, string modDesc, string modLinks)            // create constructor to get user input
        {
            ModCode = modCode;                                                                 // allocate the right input value to the correct property
            ModName = modName;
            ModDesc = modDesc;
            ModLinks = modLinks;
        }    

    }
}
