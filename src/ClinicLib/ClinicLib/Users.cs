using System;
using System.Data.SqlClient;

//Uses class with its constructors
namespace ClinicLib
{
    public class Users
    {
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }

        public Users() { }
        public Users(string userName, string firstName, string lastName, string password)
        {
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
        }

    }
}