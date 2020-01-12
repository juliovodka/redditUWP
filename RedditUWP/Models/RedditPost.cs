using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditUWP.Models
{
    public class RedditPost
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime EntryDate { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
