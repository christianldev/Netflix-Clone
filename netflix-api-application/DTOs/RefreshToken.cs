using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix_api_application.DTOs
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresDate { get; set; }

        public bool IsExpired => DateTime.UtcNow >= ExpiryDate;

        public DateTime CreatedDate { get; set; }

        public string CreatedByIp { get; set; }

        public DateTime? RevokedDate { get; set; }

        public string RevokedByIp { get; set; }

        public string ReplacedByToken { get; set; }

        public bool IsActive => RevokedDate == null && !IsExpired;

    }
}
