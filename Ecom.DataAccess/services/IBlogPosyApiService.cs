using Ecom.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.services
{
    public interface IBlogPosyApiService
   {
       Task<List<BlogPost>> GetBlogPosts();       
    }
}
