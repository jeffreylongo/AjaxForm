using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AjaxForm.Models;

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

        public IHttpActionResult Get()
        {
            return Ok(listOfForms);
        }
    }
}
