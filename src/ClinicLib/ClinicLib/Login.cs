using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicLib
{
    public class Login : ILogin
    {
        string user_name;
        string password;
        public static SqlConnection con;
        public static SqlCommand cmd;

        private static SqlConnection getcon()
        {
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog=Clinic;Integrated Security=true");
            con.Open();
            return con;
        }
        public bool UserLogin(string userName, string password)
        {
            con = getcon();
            cmd = new SqlCommand("select * from users where username = @username and password = @password");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("username", userName);
            cmd.Parameters.AddWithValue("password", password);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                throw new LoginException("Login Failed! Please Enter Valid Login Details...");
            }
        }

       
    }
}
