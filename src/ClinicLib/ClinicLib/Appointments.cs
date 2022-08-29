using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Appointments class with its constructors
namespace ClinicLib
{
    public class Appointments
    {
        public int apt_id { get; set; }
        public int doctor_id { get; set; }
        public DateTime visiting_date { get; set; }
        public string timeslot { get; set; }
        public string apt_status { get; set; }
        public int? patient_id { get; set; }

        public Appointments() { }

        public Appointments(int apt_id, int doctor_id, DateTime visiting_date, string timeslot, string apt_status, int? patient_id) 
        {
            this.apt_id = apt_id;
            this.doctor_id = doctor_id;
            this.visiting_date = visiting_date;
            this.timeslot = timeslot;
            this.apt_status = apt_status;
            this.patient_id = patient_id; 
        }

        public Appointments(int apt_id, int doctor_id,DateTime visiting_date, string timeslot, string apt_status)
        {
            this.apt_id = apt_id;
            this.doctor_id = doctor_id;
            this.visiting_date = visiting_date;
            this.timeslot = timeslot;
            this.apt_status = apt_status;
            this.patient_id = null; 
        }
    }
}
