using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Modles;

namespace Common
{
    public interface IExampleService
    {
        Response CreateBlogPost(int blogId, string title, string content);
    }
}
