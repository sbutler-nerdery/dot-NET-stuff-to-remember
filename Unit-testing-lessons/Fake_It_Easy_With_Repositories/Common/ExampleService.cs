using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Modles;
using Ninject;

namespace Common
{
    /// <summary>
    /// This is a sample service that would assert perform business logic before passing things onto an application
    /// </summary>
    public class ExampleService : IExampleService
    {
        private readonly IRepository<Blog> _Repository;

        [Inject]
        public ExampleService(IRepository<Blog> repository)
        {
            _Repository = repository;
        }

        public Response CreateBlogPost(int blogId, string title, string content)
        {
            var response = new Response{ IsError = false, Message = string.Format("Post successfully added to blog id {0}!", blogId)};

            var blogToUpdate = _Repository.GetAll(blog => blog.Posts)
                .FirstOrDefault(blog => blog.BlogId == blogId);

            //Return an error if the blog is null
            if (blogToUpdate == null)
            {
                response.IsError = true;
                response.Message = string.Format("Blog id {0} not found.", blogId);
                return response;
            }

            try
            {
                blogToUpdate.Posts.Add(new Post{Title = title, Content = content});
                _Repository.SubmitChanges();
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = string.Format("An error occured while trying update blog id {0}", blogId);
            }

            return response;
        }
    }
}
