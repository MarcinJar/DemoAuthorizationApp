using DemoAuthorizationWebApi.Logic;
using DemoAuthorizationWebApi.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAuthorization.DependencyResolver
{
    public class NinjectModulD : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserLogic>().To<UserLogic>();
            Bind<IUserRepository>().To<UserRepository>();
        }
    }
}
