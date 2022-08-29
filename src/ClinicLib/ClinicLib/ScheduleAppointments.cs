using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Numerics;
using System.Security.Cryptography;
using System.Globalization;

namespace ClinicLib
{
    public class ScheduleAppointments : IScheduleAppointments
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        private static SqlConnection getcon()
        {
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog=Clinic;Integrated Security=true");
            con.Open();
            return con;
        }

        // This Method is to Book a slot for the Patient 
        public int bookAppointment(int apt_id, int patientID)
        {
            con = getcon();
            cmd = new SqlCommand("update appointments set apt_status='Booked',patient_id=@patient_id where apt_id=@apt_id", con);
            cmd.Parameters.AddWithValue("@apt_id", apt_id);
            cmd.Parameters.AddWithValue("@patient_id", patientID);
            int success_msg = cmd.ExecuteNonQuery();
            if (success_msg == 1)
            {
                return success_msg;
            }
            throw new InvalidAppointmentIDException("Appointment ID not valid, please enter valid ID");
        }

        //This Method Displays the Doctor Based on Specialization 
        public List<Doctors> displayDoctorsBasedOnSpecialization(string specialization)
        {
            List<Doctors> Doctors = new List<Doctors>();
            con = getcon();
            cmd = new SqlCommand("select * from doctors where specialization = @specialization", con);
            cmd.Parameters.AddWithValue("@specialization", specialization);
            SqlDataReader sd = cmd.ExecuteReader();
            Doctors d = new Doctors();
            while (sd.Read())
            {
                d.doctorID = sd.GetInt32(0);
                d.first_name = sd.GetString(1);
                d.last_name = sd.GetString(2);
                d.sex = sd.GetString(3);
                d.specialization = sd.GetString(4);
                d.visiting_from = sd.GetTimeSpan(5);
                d.visiting_to = sd.GetTimeSpan(6);
                Doctors.Add(d);
            }
            return Doctors;
        }

        public List<Appointments> getAllSlotsForDoctor(int doctorID, DateTime date)
        {
            List<Appointments> Appointments = new List<Appointments>();

            con = getcon();
            cmd = new SqlCommand("select * from appointments where doctor_id=@doctor_id and apt_status='Available' and visiting_date=@date");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@doctor_id", doctorID);
            cmd.Parameters.AddWithValue("@date", date);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Appointments.Add(new Appointments(dr.GetInt32(0), dr.GetInt32(1), dr.GetDateTime(2),
                    dr.GetString(3), dr.GetString(4)));
            }

            return Appointments;
        }

        //This Method Checks Whether the date is in Indian Format or not 
        public bool ValidateIndianFormatDate(string date1)
        {
            DateTime date;
            if (!DateTime.TryParseExact(date1, "dd'/'MM'/'yyyy",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out date))
            {
                throw new DateInIndianFormatException("Pls enter date in dd/mm/yyyy format");
            }
            return true;
        }

        //This Method Checks Whether the Entered Date is between the given Dates 
        public bool ValidateDateLimit(string datelimit)
        {
            List<string> dl = new List<string>();
            dl.Add("26/08/2022");
            dl.Add("27/08/2022");
            dl.Add("28/08/2022");
            dl.Add("29/08/2022");
            dl.Add("30/08/2022");
            dl.Add("31/08/2022");
            foreach (string s in dl)
            {
                if (datelimit.Equals(s))
                {
                    return true;
                }
            }
            throw new DateLimitExceededException("Please Enter the date between 26/08/2022 to 31/08/2022.");
        }
        //This Method is used to Validate the Appointment Schedule With Correct Specialization 
        public bool ValidateScheduleAppointment(int patientID, string specialization)
        {
            con = getcon();
            cmd = new SqlCommand("select * from patients where patient_id =@patient_id", con);
            cmd.Parameters.AddWithValue("@patient_id", patientID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows)
            {
                throw new InvalidPatientIDException("Patient ID doesn't exist please recheck");
            }

            List<string> specs = new List<string>();
            specs.Add("Ortho");
            specs.Add("Pediatrics");
            specs.Add("General");
            specs.Add("Internal Medicine");
            specs.Add("Opthalmology");


            if (!specs.Contains(specialization))
            {
                throw new InvalidSpecializationException("Specialization does not exist");
            }
            return true;
        }

        //This Method Checks Whether the given Doctor ID is Correct or Not  
        public bool ValidateDoctorID(int doctorID, List<int> docid)
        {
            if (docid.Contains(doctorID))
            {
                return true;
            }
            throw new InvalidDoctorIDException("The Given Doctor ID is not Under the Required Specialization or ID does not Exist.");
        }

        //This Method Checks Whether the given Appointment ID is Correct or not 
        public bool ValidateAppointmentID(List<int> aid, int apt_id)
        {
            bool flag = false;
            foreach (int id in aid)
            {
                if (apt_id == id)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                throw new InvalidAppointmentIDException("Appointment ID Does not Exist.");
            }
            return true;
        }
    }
}
