using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.api.application.DTOs.Request.Auth
{
    public class req_login
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
