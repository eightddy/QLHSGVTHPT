using DemoProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoProject.DAO
{
    public class UserDAO
    {
        MyDbContext db;
        public UserDAO()
        {
            db = new MyDbContext();
        }
        public bool Login(string username, string password)
        {
            Object[] sqlPara =
            {
                new SqlParameter("@username",username),
                new SqlParameter("@password",password)
            };
            var res = db.Database.SqlQuery<bool>("PRO_User_Login @username, @password", sqlPara).SingleOrDefault();
            return res;
        }
        public tblUser getUserByUsername(string username)
        {
            return db.tblUsers.Where(item => item.Username==username).SingleOrDefault();
        }
    }
}