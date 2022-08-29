using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//User - Defined Exceptions
namespace ClinicLib
{
    public class Project_Exceptions : ApplicationException
    {
        public Project_Exceptions(string message) : base(message)
        {

        }
    }
   
    public class LoginException : ApplicationException
    {
        public LoginException(string message) : base(message)
        {

        }
    }

    
    public class NameException : ApplicationException
    {
        public NameException(string message) : base(message)
        {

        }

    }

    public class AgeException : ApplicationException
    {
        public AgeException(string message) : base(message)
        {

        }

    }

    public class DateInIndianFormatException : ApplicationException
    {
        public DateInIndianFormatException(string message) : base(message)
        {

        }

    }

    public class InvalidPatientIDException : ApplicationException
    {
        public InvalidPatientIDException(string message) : base(message)
        {

        }

    }
    public class InvalidSpecializationException : ApplicationException
    {
        public InvalidSpecializationException(string message) : base(message)
        {

        }

    }

    public class InvalidAppointmentIDException : ApplicationException
    {
        public InvalidAppointmentIDException(string message) : base(message)
        {

        }

    }

    public class InvalidCancellationException : ApplicationException
    {
        public InvalidCancellationException(string message) : base(message)
        {

        }

    }

    public class DateLimitExceededException : ApplicationException
    {
        public DateLimitExceededException(string message) : base(message)
        {

        }

    }

    public class InvalidDoctorIDException : ApplicationException
    {
        public InvalidDoctorIDException(string message) : base(message)
        {

        }

    }
}
