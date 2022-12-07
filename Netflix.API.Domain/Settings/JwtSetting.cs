﻿#nullable disable
namespace Netflix.API.Domain.Settings
{
    public class JwtSetting
    {

        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int DurationInMinutes { get; set; }

    }
}
