using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicLib
{
    public interface IHome
    {
        public List<Doctors> viewAllDoctors();

        public List<Patients> viewAllPatients();

        public int addPatients(Patients p, out int patientID);

        public bool validatePatients(string first_name, string last_name, string sex, int age, string dob);
    }
}
