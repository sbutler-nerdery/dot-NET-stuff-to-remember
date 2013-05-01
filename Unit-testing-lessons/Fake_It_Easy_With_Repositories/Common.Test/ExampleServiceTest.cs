using System;
using System.Collections.Generic;
using System.Linq;
using Data.Modles;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Test
{
    [TestClass]
    public class ExampleServiceTest
    {
        private ExampleService _service;
        private IRepository<Blog> _repository;

        [TestInitialize]
        public void SpinUp()
        {
            _repository = A.Fake<IRepository<Blog>>();
            _service = new ExampleService(_repository);
        }

        [TestMethod]
        public void CreateBlogPost_Blog_Error_Occurred()
        {
            const int blogId = 1;
            var fakeBlogs = new List<Blog>
                {
                    new Blog {BlogId = 1, Name = "Test Blog", Posts = new List<Post>()}
                };
            A.CallTo(() => _repository.GetAll()).Returns(fakeBlogs.AsQueryable());
            A.CallTo(() => _repository.SubmitChanges()).Throws(new Exception("Something terrible happened!"));

            var response = _service.CreateBlogPost(blogId, "Title", "something profound");
            Assert.AreEqual(response.IsError, true);
            Assert.AreEqual(response.Message, string.Format("An error occured while trying update blog id {0}", blogId));
        }

        [TestMethod]
        public void CreateBlogPost_Blog_Not_Found()
        {
            const int blogId = 1;
            var fakeBlogs = new List<Blog>();
            A.CallTo(() => _repository.GetAll()).Returns(fakeBlogs.AsQueryable());

            var response = _service.CreateBlogPost(blogId, "Title", "something profound");
            Assert.AreEqual(response.IsError, true);
            Assert.AreEqual(response.Message, string.Format("Blog id {0} not found.", blogId));
        }
    }
}
