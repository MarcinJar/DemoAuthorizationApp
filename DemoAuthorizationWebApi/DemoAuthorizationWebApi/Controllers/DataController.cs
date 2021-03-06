﻿using DemoAuthorization.Model;
using DemoAuthorizationWebApi.Logic;
using DemoAuthorizationWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace DemoAuthorizationWebApi.Controllers
{
    public class DataController : ApiController
    {
        private IUserLogic userLogic;
        private ILogger log;

        public DataController(IUserLogic userLogic, ILogger log)
        {
            this.userLogic = userLogic;
            this.log = log;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/forall")]
        public IHttpActionResult Get()
        {
            return Ok("Now server time is: " + DateTime.Now.ToString());
        }

        [Authorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity.Name);
        }

        [Authorize(Roles="Admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList()));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/data/getallusers")]
        public IEnumerable<RowUser> GetAllUsers()
        {
            IEnumerable<RowUser> rUsers = this.userLogic.GetAllUsers();
            this.log.Info("get list of users from datatbase");

            return rUsers;
        }
    }
}
