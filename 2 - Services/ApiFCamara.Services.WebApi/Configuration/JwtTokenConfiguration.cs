using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFCamara.Services.WebApi.Configuration
{
    public class JwtTokenConfiguration
    {
            public string Issuer { get; set; }
            public string Audience { get; set; } 
            public string Key { get; set; }
            public int TokenExperiationInMinutes { get; set; }
    }
}
