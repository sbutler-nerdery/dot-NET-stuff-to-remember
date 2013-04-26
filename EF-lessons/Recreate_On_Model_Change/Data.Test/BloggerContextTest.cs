using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test
{
    [TestClass]
    public class BloggerContextTest
    {
        [TestMethod]
        public void CreateDatabase()
        {
            //This will tell EF to drop and recreate the database whenever the models change...
            Database.SetInitializer(new BloggerContextInitializer());

            using (var db = new BloggerContext())
            {
                //Get the seed values from the database and print them to the screen
                Blog seedBlog = db.Blogs.FirstOrDefault();
                Assert.AreNotEqual(seedBlog, null);
                Assert.AreEqual(seedBlog.Name, "My Blog");
                //Assert.AreEqual(seedBlog.Url, "www.myblog.com");

                //Assert that the post titles are not empty... just for the heck of it... 
                seedBlog.Posts.ForEach(post => Assert.AreNotEqual(post.Title, string.Empty));
            }
        }
    }
}
