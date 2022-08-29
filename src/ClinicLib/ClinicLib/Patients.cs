using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Patients class with its constructors
namespace ClinicLib
{
    public class Patients
    {
        public int patientID { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public DateTime dob { get; set; }
        
        public Patients() { }

        public Patients(string first_name, string last_name, string sex, int age, DateTime dob) 
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.sex = sex;
            this.age = age;
            this.dob = dob;
        }

        public Patients(int patientID, string first_name, string last_name, string sex, int age, DateTime dob)
        {
            this.patientID = patientID;
            this.first_name = first_name;
            this.last_name = last_name;
            this.sex = sex;
            this.age = age;
            this.dob = dob;      
        }
    }
}
