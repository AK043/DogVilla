using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using DogVilla.Models;
namespace DogVilla.Controllers
{
    public class HomeController : Controller
    {
      public  SqlConnection sqlcontn = new SqlConnection();
        public SqlCommand sqlcmd = new SqlCommand();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Service()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Gallery()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }





        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult VisitorMessage(Message msg_Instance)
        {
            sqlcontn.ConnectionString = "Data Source=DESKTOP-D8TV9DE\\SQLEXPRESS;Initial Catalog=DogVilla;Integrated Security=True";




            sqlcontn.Open();
            sqlcmd.Connection = sqlcontn;

            sqlcmd.CommandText = "insert into ContactRecord(Name,Email,Msg) values('" + msg_Instance.txtName + "','" + msg_Instance.txtEmail + "','" + msg_Instance.txtMsg + "')";
            sqlcmd.ExecuteNonQuery();
            sqlcontn.Close();

            return View("answerFile");


        }





    }
}