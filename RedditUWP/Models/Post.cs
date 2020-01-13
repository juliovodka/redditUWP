using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace RedditUWP.Models
{
    public class PostDetail : ObservableObject
    {
        private bool read = false;
        private bool dismmiss = false;

        public string id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int num_comments { get; set; }
        public string thumbnail { get; set; }
        public double created_utc { get; set; }
      
        public bool Read
        {
            get { return read; }
            set
            {
                Set(nameof(Read), ref read, value);
            }
        }

        public bool Dismiss
        {
            get { return dismmiss; }
            set
            {
                Set(nameof(Dismiss), ref dismmiss, value);
            }
        }

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

        private RelayCommand _dismissCommand;


        public RelayCommand DismissCommand
        {
            get
            {
                return _dismissCommand ?? (_dismissCommand = new RelayCommand(
                    () =>
                    {
                        this.Dismiss = true;
                    }));
            }
        }

    }

    public class Post : ObservableObject
    {
        public PostDetail data { get; set; }
    }

    public class Data : ObservableObject
    {
        public int dist { get; set; }
        public List<Post> children { get; set; }
    }

    public class Posts : ObservableObject
    {
        public Data data { get; set; }
    }
}
