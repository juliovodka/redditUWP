using GalaSoft.MvvmLight;
using RedditUWP.Models;
using RedditUWP.Services;
using System.Collections.ObjectModel;

namespace RedditUWP.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        #region Variables
        private readonly IRedditService redditService;
        private ObservableCollection<RedditPost> posts;
        private string title;
        #endregion

        public ObservableCollection<RedditPost> Posts
        {
            get { return posts; }
            set
            {
                Set(nameof(Posts), ref posts, value);
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                Set(nameof(Title), ref title, value);
            }
        }

        public StartViewModel()
        {
            Title = "Hello Joel";
        }
    }
}