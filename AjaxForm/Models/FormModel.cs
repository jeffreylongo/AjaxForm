using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxForm.Models
{
    public class FormModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool? Cell { get; set; }
        public string EMail { get; set; }
        public bool? OptOut { get; set; }
    }
}