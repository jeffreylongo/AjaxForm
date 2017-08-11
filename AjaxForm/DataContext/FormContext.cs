using AjaxForm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace AjaxForm.DataContext
{
    public class FormContext :DbContext
    {
        public DbSet<FormModel> Forms { get; set; }
    }
}