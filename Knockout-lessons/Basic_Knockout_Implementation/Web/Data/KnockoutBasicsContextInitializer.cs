using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Data
{
    public class KnockoutBasicsContextInitializer : DropCreateDatabaseIfModelChanges<KnockoutBasicsContext>
    {
        protected override void Seed(KnockoutBasicsContext context)
        {
            var microsoftBlog = new Blog {Name = "Stuff about Microsoft"};
            var redditBlog = new Blog { Name = "My Reddit Findings" };

            microsoftBlog.Posts = new List<Post>
                {
                    new Post{Title = "They Help me Pay my bills",Content = "But sometimes I still get upset at them :)"},
                    new Post{Title = "If I were Bill Gates", Content = "How would I spend my time?"}
                };
            redditBlog.Posts = new List<Post>
                {
                    new Post { Title = "Confessions", Content = "First confession, I never read anything off this site."}
                };

            context.Blogs.Add(microsoftBlog);
            context.Blogs.Add(redditBlog);
            context.SaveChanges();
        }
    }
}