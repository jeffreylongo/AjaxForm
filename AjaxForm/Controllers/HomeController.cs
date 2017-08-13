using AjaxForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxForm.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            // add session time per user
            var sessionTime = Session["userTime"];
            var sessionUserKey = Session["userKey"];
            if (sessionTime == null)
            {
                Session.Add("userTime", DateTime.Now);
            }
            if (sessionUserKey == null)
            {
                Session.Add("userKey", Guid.NewGuid());
            }
            ViewBag.SessionTime = Session["userTime"];
            ViewBag.SessionKey = Session["userKey"];

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}