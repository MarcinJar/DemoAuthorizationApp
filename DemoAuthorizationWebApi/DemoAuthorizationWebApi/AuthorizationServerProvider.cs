using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using DemoAuthorizationWebApi.Models;
using DemoAuthorizationWebApi.Logic;

namespace DemoAuthorizationWebApi
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            UserLogic userLogic = new UserLogic();
            User user = userLogic.CheckUser(context.UserName, context.Password);

            if (user.existUser == true)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
                identity.AddClaim(new Claim("username", user.Login));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                context.Validated(identity);
            } 
            else
            {
                context.SetError("invalid_grand", "Provided username and password is incorrect");
                return;
            }
        }
    }
}