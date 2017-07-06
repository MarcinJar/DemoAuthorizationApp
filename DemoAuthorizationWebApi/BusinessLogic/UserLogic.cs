using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoAuthorization.Model;
using DemoAuthorizationWebApi.Repository;
using log4net;

namespace DemoAuthorizationWebApi.Logic
{
    public class UserLogic : IUserLogic
    {
        IUserRepository userRepository;
        ILog logger;

        public UserLogic(IUserRepository userRepository, ILog logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public User CheckUser(string login, string password)
        {
            return this.userRepository.CheckUser(login, password);
        }

        public IEnumerable<RowUser> GetAllUsers()
        {
            this.logger.Info("Get all users - test the logic layer");
            return this.userRepository.GetAllUsers();
        }
    }
}