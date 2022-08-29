using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;

namespace ClinicLib
{
    public class CancelSchedule : ICancelSchedule
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        private static SqlConnection getcon()
        {
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog=Clinic;Integrated Security=true");
            con.Open();
            return con;
        }
        public int cancelAppointment(int apt_id, int patientID)
        {
            con = getcon();
            cmd = new SqlCommand("update appointments set apt_status='Available',patient_id=null where apt_id=@apt_id and patient_id=@patient_id", con);
            cmd.Parameters.AddWithValue("@apt_id", apt_id);
            cmd.Parameters.AddWithValue("@patient_id", patientID);
            int success_msg = cmd.ExecuteNonQuery();
            if (success_msg == 1)
            {
                return success_msg;
            }
            throw new InvalidAppointmentIDException("Appointment Number Not Valid ");
        }

        public List<Appointments> displayAppointmentsOfPatient(int patientID, DateTime CancelDate)
        {
            List<Appointments> Appointments = new List<Appointments>();
            con = getcon();
            cmd = new SqlCommand("select * from appointments where patient_id=@patient_id and visiting_date=@CancelDate", con);
            cmd.Parameters.AddWithValue("@patient_id", patientID);
            cmd.Parameters.AddWithValue("@CancelDate", CancelDate);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Appointments.Add(new Appointments(dr.GetInt32(0), dr.GetInt32(1), dr.GetDateTime(2),
                    dr.GetString(3), dr.GetString(4), dr.GetInt32(5)));
            }

            return Appointments;
        }

        public bool ValidateIndianFormatDate(string date1)
        {
            DateTime date;
            if (!DateTime.TryParseExact(date1, "dd'/'MM'/'yyyy",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out date))
            {
                throw new DateInIndianFormatException("Please enter valid date dd/mm/yyyy format");
            }
            return true;
        }

        public bool ValidatePatientID(int patientID)
        {
            con = getcon();
            cmd = new SqlCommand("select * from patients where patient_id =@patient_id", con);
            cmd.Parameters.AddWithValue("@patient_id", patientID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            throw new InvalidPatientIDException("Please enter valid Patient ID");
        }
    }
}
