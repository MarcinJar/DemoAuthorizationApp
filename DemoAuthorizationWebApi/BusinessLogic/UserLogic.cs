using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoAuthorization.Model;
using DemoAuthorizationWebApi.Repository;

namespace DemoAuthorizationWebApi.Logic
{
    public class UserLogic : IUserLogic
    {
        IUserRepository userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User CheckUser(string login, string password)
        {
            return this.userRepository.CheckUser(login, password);
        }

        public IEnumerable<RowUser> GetAllUsers()
        {
            return this.userRepository.GetAllUsers();
        }
    }
}