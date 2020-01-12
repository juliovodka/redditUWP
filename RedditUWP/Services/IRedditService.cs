using RedditUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditUWP.Services
{
    public interface IRedditService
    {
        Task<IEnumerable<Post>> GetTopPosts();
    }
}
