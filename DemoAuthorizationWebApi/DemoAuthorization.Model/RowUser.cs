using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAuthorization.Model
{
    public class RowUser
    {
        public int DBKey { get; set; }

        public string Login { get; set; }

        //public string Password { get; set; }

        public int DBKeyRole { get; set; }

        public string Name { get; set; }
    }
}
