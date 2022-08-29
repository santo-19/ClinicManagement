using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

//Interface for Scheduling the Appointments and related to it
namespace ClinicLib
{
    public interface IScheduleAppointments
    {
        public List<Doctors> displayDoctorsBasedOnSpecialization(string specialization);

        public List<Appointments> getAllSlotsForDoctor(int doctorID, DateTime day);

        public int bookAppointment(int apt_id, int patientID);

        public bool ValidateScheduleAppointment(int patientID, string specialization);

        public bool ValidateIndianFormatDate(string date1);

        public bool ValidateDateLimit(string datelimit);

        public bool ValidateDoctorID(int doctorID, List<int> docid);

        public bool ValidateAppointmentID(List<int> aid, int apt_id);
    }
}
