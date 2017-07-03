using DemoAuthorizationWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAuthorizationWebApi.Repository
{
    public interface IUserRepository
    {
        User CheckUser(string login, string password);
    }
}
