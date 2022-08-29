using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicLib
{
    public interface ICancelSchedule
    {
        public List<Appointments> displayAppointmentsOfPatient(int patientID, DateTime CancelDate);

        public int cancelAppointment(int apt_id, int patientID);

        public bool ValidatePatientID(int patientID);

        public bool ValidateIndianFormatDate(string date1);
    }
}
