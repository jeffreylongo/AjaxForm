﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AjaxForm.Models;
using AjaxForm.DataContext;
using System.Web;



namespace AjaxForm.Controllers
{
    public class FormController : ApiController
    {
        public static List<FormModel> listOfForms = new List<FormModel>
        {
            //setting up some data to send to DOM using the FormModel
            new FormModel{ Id = 1,
                FirstName = "Jeff",
                LastName = "Longo",
                Phone = "4077587623",
                Cell = true,
                EMail = "jeffreylongo@yahoo.com",
                OptOut = true },
        };

        [HttpGet]
        public IHttpActionResult Get()
        {
            // Session per user
            var timeUserFirstCameToSite = HttpContext.Current.Session["userTime"];
            if (timeUserFirstCameToSite == null)
            {
                HttpContext.Current.Session.Add("userTime", DateTime.Now);
            }
            ViewBag.FromSession = HttpContext.Current.Session["userTime"];

            return Ok(listOfForms);
        }

        [HttpPost]
        public IHttpActionResult AddForm([FromBody]FormModel form)
        {
            var db = new FormContext();
            db.Forms.Add(form);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok(form);
        }
    }
}
