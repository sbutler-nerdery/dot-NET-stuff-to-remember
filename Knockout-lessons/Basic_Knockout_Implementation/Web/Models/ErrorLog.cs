using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ErrorLog
    {
        public int ErrorLogId { get; set; }
        public string Message { get; set; }
        public string CallStack { get; set; }
    }
}