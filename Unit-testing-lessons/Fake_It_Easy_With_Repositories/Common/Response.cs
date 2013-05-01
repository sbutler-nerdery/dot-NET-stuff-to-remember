using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// A class used to pass information back to the caller of a service.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Get or set the value indicating that an error occurred when calling the service.
        /// </summary>
        public bool IsError { get; set; }
        /// <summary>
        /// Get or set the message to be returned to the service caller.
        /// </summary>
        public string Message { get; set; }
    }
}
