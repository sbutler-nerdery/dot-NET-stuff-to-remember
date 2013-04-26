using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Data
{
    public class BloggerContextInitializer : DropCreateDatabaseIfModelChanges<BloggerContext>
    {
        protected override void Seed(BloggerContext context)
        {
            Blog mySampleBlog = new Blog
                {
                    Name = "My Blog"
                    ,Url = "www.myblog.com"
                };

            List<Post> samplePosts = new List<Post>
                {
                    new Post{Blog = mySampleBlog, Title = "I like .NET", Content = "You would too if you used it."},
                    new Post{Blog = mySampleBlog, Title = "Java is ok", Content = "I like Java for Android development."}
                };

            mySampleBlog.Posts = samplePosts;

            context.Blogs.Add(mySampleBlog);
            context.SaveChanges();
        }
    }
}
