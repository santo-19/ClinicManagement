using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ClinicLib
{
    public class Home : IHome
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlCommand cmd1;  
        List<Doctors> doc_list = new List<Doctors>();
        List<Patients> pat_list = new List<Patients>();

        private static SqlConnection getcon()
        {
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog=Clinic;Integrated Security=true");
            con.Open();
            return con;
        }
        public List<Doctors> viewAllDoctors()
        {
            con = getcon();
            cmd = new SqlCommand("select * from doctors");
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Doctors d = new Doctors();
                d.doctorID = dr.GetInt32(0);
                d.first_name = dr.GetString(1);
                d.last_name = dr.GetString(2);
                d.sex = dr.GetString(3);
                d.specialization = dr.GetString(4);
                d.visiting_from = dr.GetTimeSpan(5);
                d.visiting_to = dr.GetTimeSpan(6);
                doc_list.Add(d);  
            }
            return doc_list;
        }

        public List<Patients> viewAllPatients()
        {
            con = getcon();
            cmd = new SqlCommand("select * from patients", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            Patients p = new Patients();
            while (sdr.Read())
            {
                p.patientID = sdr.GetInt32(0);
                p.first_name = sdr.GetString(1);
                p.last_name = sdr.GetString(2);
                p.sex = sdr.GetString(3);
                p.age = sdr.GetInt32(4);
                p.dob = sdr.GetDateTime(5);
                pat_list.Add(p);
            }
            return pat_list;
        }

        public bool validatePatients(string first_name, string last_name, string sex, int age, string dob)
        {
            string reg = "[^A-Za-z0-9]";
            Regex re = new Regex(reg);
            if (re.IsMatch(first_name) || re.IsMatch(last_name))
            {
                throw new NameException("Please Enter Valid First Name Or Last Name");
            }
            if (age < 0 || age > 120)
            {
                throw new AgeException("Please enter valid age between 0-120");
            }
            DateTime date;
            if (!DateTime.TryParseExact(dob, "dd'/'MM'/'yyyy", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out date))
            {
                throw new DateInIndianFormatException("Please enter date in dd/mm/yyyy format");
            }
            return true;
        }
        public int addPatients(Patients p, out int patientID)
        {
            con = getcon();
            cmd = new SqlCommand("insert into patients (firstname, lastname, sex, age, dob) values (@firstname, @lastname, @sex, @age, @dob)");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@firstname", p.first_name);
            cmd.Parameters.AddWithValue("@lastname", p.last_name);
            cmd.Parameters.AddWithValue("@sex", p.sex);
            cmd.Parameters.AddWithValue("@age", p.age);
            cmd.Parameters.AddWithValue("@dob", p.dob);
            int success_msg = cmd.ExecuteNonQuery();
            cmd1 = new SqlCommand("select patient_id from patients where firstname=@firstname and lastname=@lastname and sex=@sex and age=@age and dob=@dob", con);
            cmd1.Parameters.AddWithValue("@firstname", p.first_name);
            cmd1.Parameters.AddWithValue("@lastname", p.last_name);
            cmd1.Parameters.AddWithValue("@sex", p.sex);
            cmd1.Parameters.AddWithValue("@age", p.age);
            cmd1.Parameters.AddWithValue("@dob", p.dob);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            patientID = dr.GetInt32(0);
            return success_msg;
        }
    }
}
