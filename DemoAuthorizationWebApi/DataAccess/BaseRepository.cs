using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class BaseRepository
    {
        protected ConnectionStringSettings connection { get; private set; }

        public BaseRepository()
        {
            connection = ConfigurationManager.ConnectionStrings["DA"];
        }
    }
}
