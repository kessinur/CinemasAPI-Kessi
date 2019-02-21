using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Param
{
    public class UserParam
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Amount { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public int Villages_Id { get; set; }
        public int Religions_Id { get; set; }
    }
}
