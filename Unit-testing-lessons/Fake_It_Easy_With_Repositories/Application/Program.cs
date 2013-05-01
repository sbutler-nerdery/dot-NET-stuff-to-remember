using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Data;
using Data.Modles;
using Ninject;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set up ninject stuff...
            Console.WriteLine("Setting up ninject...");
            var kernal = new StandardKernel();
            kernal.Bind<IUnitOfWork>().To(typeof(EntityFrameworkUnitOfWork));
            kernal.Bind(typeof(IRepository<>)).To(typeof(EntityFrameworkRepository<>));
            kernal.Bind(typeof(DbContext)).To(typeof(FakeItEasyContext));
            kernal.Bind<IExampleService>().To<ExampleService>();

            var repository = kernal.Get<IRepository<Blog>>();

            //Does a blog exists?
            var blog = repository.GetAll().FirstOrDefault();

            if (blog == null)
            {
                blog = new Blog{ Name = "Test Blog - " + DateTime.Now.ToString() };
                repository.Insert(blog);
                repository.SubmitChanges();
            }
            else
            {
                blog.Name = "Test Blog - " + DateTime.Now.ToString();
                repository.SubmitChanges();                
            }

            Console.WriteLine("Getting service instance...");
            var service = kernal.Get<IExampleService>();

            Console.WriteLine("Attmepting to add blog post...");
            var response = service.CreateBlogPost(blog.BlogId, "This is a test", "Oh what a test!");

            Console.WriteLine("Error: {0}", response.IsError);
            Console.WriteLine("Message: {0}", response.Message);
            Console.Read();
        }
    }
}
