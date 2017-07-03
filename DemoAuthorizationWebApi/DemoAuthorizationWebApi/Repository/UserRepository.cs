﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoAuthorizationWebApi.Models;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Configuration;

namespace DemoAuthorizationWebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        public User CheckUser(string login, string password)
        {
            User user = new User();

            using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DA"].ConnectionString))
            {
                try
                {
                    DynamicParameters dyParam = new DynamicParameters();
                    dyParam.Add("pLoginName", login);
                    dyParam.Add("pPassword", password);
                    dyParam.Add("responseMessage", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    dyParam.Add("role", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
                    dyParam.Add("name", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                    dbConn.Open();
                    dbConn.Query("dbo.userLogin", dyParam, commandType: CommandType.StoredProcedure);
                    int respMessage = dyParam.Get<int>("responseMessage");
                    string role = dyParam.Get<string>("role");
                    string name = dyParam.Get<string>("name");

                    user.Login = login;
                    user.Password = password;
                    user.Role = role;
                    user.existUser = respMessage == 1;
                    user.Name = name;
                }
                catch (Exception ex)
                {

                }
            }

            return user;
        }
    }
}