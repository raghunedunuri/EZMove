using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Contracts
{
    public class Login
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public Guid   Token { get; set; }
        public int    UserID { get; set; }
        public string LoginID { get; set; }
        public string UserType { get; set; } //Driver or Employee or Admin
        public string PicUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

    }
}
