using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using Ninject;
using DemoAuthorizationWebApi.Logic;
using System.Reflection;
using Ninject.Modules;
using System.Collections.Generic;
using DemoAuthorization.DependencyResolver;
using DemoAuthorizationWebApi.App_Start;

[assembly: OwinStartup(typeof(DemoAuthorizationWebApi.Startup))]

namespace DemoAuthorizationWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //enable cros orgin requests
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //Ninject.IKernel kernal = new StandardKernel();

            //var modules = new List<INinjectModule>
            //{
            //    new NinjectModulD()
            //};
            //kernal.Load(modules);
            IKernel kernel = NinjectWebCommon.GetKelner;

            var provider = kernel.Get<AuthorizationServerProvider>();
            //var provider = new AuthorizationServerProvider();
            OAuthAuthorizationServerOptions OAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = provider
            };
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
