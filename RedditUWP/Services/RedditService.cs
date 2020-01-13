using RedditUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace RedditUWP.Services
{
    public class RedditService : IRedditService
    {
        public async Task<IEnumerable<Post>> GetTopPosts()
        {
            var client = new HttpClient();
            
            var stream = await client.GetStreamAsync("https://www.reddit.com/top.json?limit=50&sort=new");

            var serializer = new DataContractJsonSerializer(typeof(Posts));

            var posts = (Posts)serializer.ReadObject(stream);

            return posts.data.children;
        }
    }
}
