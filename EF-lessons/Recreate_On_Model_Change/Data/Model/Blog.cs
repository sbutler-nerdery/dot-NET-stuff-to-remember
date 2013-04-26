using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        /// <summary>
        /// Get or set the posts associated with this Blog.
        /// NOTE: This enables the Lazy Loading feature of Entity Framework. 
        /// Lazy Loading means that the contents of these properties will be automatically loaded from the 
        /// database when you try to access them
        /// </summary>
        public virtual List<Post> Posts { get; set; }
    }


}
