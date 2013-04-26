using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        /// <summary>
        /// Get or set the blog associated with this Post.
        /// NOTE: This enables the Lazy Loading feature of Entity Framework. 
        /// Lazy Loading means that the contents of these properties will be automatically loaded from the 
        /// database when you try to access them
        /// </summary>
        public virtual Blog Blog { get; set; }
    }
}
