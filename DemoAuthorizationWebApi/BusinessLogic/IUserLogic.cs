using DemoAuthorization.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAuthorizationWebApi.Logic
{
    public interface IUserLogic
    {
        User CheckUser(string login, string password);

        IEnumerable<RowUser> GetAllUsers();
    }
}
