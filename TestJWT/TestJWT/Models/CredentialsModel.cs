using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestJWT.Models
{
    public class CredentialsModel
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
    }
}
