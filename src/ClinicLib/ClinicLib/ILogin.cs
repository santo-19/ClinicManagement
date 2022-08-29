using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicLib
{
    public interface ILogin
    {
        public bool UserLogin(string userName, string password);
    }
}
