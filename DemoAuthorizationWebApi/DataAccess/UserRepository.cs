using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoAuthorization.Model;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Configuration;
using DataAccess;

namespace DemoAuthorizationWebApi.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public User CheckUser(string login, string password)
        {
            User user = new User();

            using (SqlConnection dbConn = new SqlConnection(connection.ConnectionString))
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

        public IEnumerable<RowUser> GetAllUsers()
        {
            IEnumerable<RowUser> usersList = null;

            using (SqlConnection dbConn = new SqlConnection(connection.ConnectionString))
            {
                dbConn.Open();
                usersList = dbConn.Query<RowUser>("dbo.getAllUsers", commandType: CommandType.StoredProcedure).ToList();
            }

            return usersList;
        }
    }
}