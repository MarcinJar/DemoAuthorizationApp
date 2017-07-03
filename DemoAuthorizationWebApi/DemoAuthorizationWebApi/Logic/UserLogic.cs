using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoAuthorizationWebApi.Models;
using DemoAuthorizationWebApi.Repository;

namespace DemoAuthorizationWebApi.Logic
{
    public class UserLogic : IUserLogic
    {
        UserRepository uRepo = new UserRepository();

        public User CheckUser(string login, string password)
        {
            return uRepo.CheckUser(login, password);
        }
    }
}