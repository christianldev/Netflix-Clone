using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.api.application.DTOs.Response.Auth
{
    public class res_login : RespuestaDto
    { 
        public string token { get; set; }
        public LoginDto info_cliente { get; set; }
    }
    public class LoginDto
    {
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
