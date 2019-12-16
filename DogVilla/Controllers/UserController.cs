using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DogVilla.Models;

namespace DogVilla.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public SqlConnection sqlcontn = new SqlConnection();
        public SqlCommand sqlcmd = new SqlCommand();
        public SqlDataReader sqlDR;

        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin Usr)
        {
            sqlcontn.ConnectionString = "Data Source=DESKTOP-D8TV9DE\\SQLEXPRESS;Initial Catalog=DogVilla;Integrated Security=True";




            sqlcontn.Open();
            sqlcmd.Connection = sqlcontn;
            sqlcmd.CommandText = "select * from LoginRecord where Name='" + Usr.Name + "' and Password='" + Usr.Password + "'";

            sqlDR = sqlcmd.ExecuteReader();

            if (sqlDR.Read())
            {
                sqlcontn.Close();
                return View("UserPanel");
            }
            else
            {
                sqlcontn.Close();
                return View("InvalidDetails");
            }
            


        }
    }
}