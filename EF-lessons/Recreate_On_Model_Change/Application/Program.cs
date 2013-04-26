using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Model;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //This will tell EF to drop and recreate the database whenever the models change...
            Database.SetInitializer(new BloggerContextInitializer());

            using (var db = new BloggerContext())
            {
                //Get the seed values from the database and print them to the screen
                Blog seedBlog = db.Blogs.FirstOrDefault();
                Console.WriteLine("{0} has {1} posts...", seedBlog.Name, seedBlog.Posts.Count);

                //Uncomment this line if the Url property has been added to the Blog model.
                //Console.WriteLine("{0} - '{1}' has {2} posts...", seedBlog.Name, seedBlog.Url, seedBlog.Posts.Count);

                seedBlog.Posts.ForEach(post => Console.WriteLine("     - {0}", post.Title));

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
