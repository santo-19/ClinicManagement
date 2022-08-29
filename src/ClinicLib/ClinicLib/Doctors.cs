using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Doctors class with its constructors
namespace ClinicLib
{
    public class Doctors
    {
        public int doctorID { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string sex { get; set; }
        public string specialization { get; set; }
        public TimeSpan visiting_from { get; set; }
        public TimeSpan visiting_to { get; set; }

        public Doctors() { }
        public Doctors(int doctorID, string first_name, string last_name, string sex, string specialization, TimeSpan visiting_from, TimeSpan visiting_to)
        {
            this.doctorID = doctorID;
            this.first_name = first_name;
            this.last_name = last_name;
            this.sex = sex;
            this.specialization = specialization;
            this.visiting_from = visiting_from;
            this.visiting_to = visiting_to;
        }
    }
}
