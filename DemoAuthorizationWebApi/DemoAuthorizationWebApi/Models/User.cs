using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAuthorizationWebApi.Models
{
    public class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public bool existUser { get; set; }

        public string Name { get; set; }
    }
}