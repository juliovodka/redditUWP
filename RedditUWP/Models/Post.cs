using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RedditUWP.Models
{
    public class PostDetail
    {
        public string title { get; set; }
        public string author { get; set; }
        public int num_comments { get; set; }
        public string thumbnail { get; set; }
        public double created_utc { get; set; }
        public bool visited { get; set; }

        public string created
        {
            get
            {
                string value = string.Empty;

                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

                dtDateTime = dtDateTime.AddSeconds(created_utc).ToLocalTime();

                TimeSpan span = DateTime.Now - dtDateTime;

                double total = span.Hours;

                value = $"{span.Hours} hours ago";

                if (total > 24)
                {
                    value = $"{span.Days} days ago";
                }

                if (total < 0)
                {
                    value = $"{span.Minutes} minutes ago";
                }

                return value;
            }
        }

    }

    public class Post
    {
        public PostDetail data { get; set; }
    }

    public class Data
    {
        public int dist { get; set; }
        public List<Post> children { get; set; }
    }

    public class Posts
    {
        public Data data { get; set; }
    }
}
