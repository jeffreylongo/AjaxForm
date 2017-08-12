using AjaxForm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AjaxForm.DataContext
{
    public class SessionContext :DbContext
    {
        public DbSet<UserSessionDataModel> Forms { get; set; }
    }
}