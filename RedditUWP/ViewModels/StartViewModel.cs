using GalaSoft.MvvmLight;
using RedditUWP.Models;
using RedditUWP.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RedditUWP.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        #region Variables
        private readonly IRedditService redditService;
        private ObservableCollection<Post> posts;
        private Post postSelected;
        private string title;
        #endregion

        public ObservableCollection<Post> Posts
        {
            get { return posts; }
            set
            {
                Set(nameof(Posts), ref posts, value);
            }
        }

        public Post PostSelected
        {
            get { return postSelected; }
            set
            {
                postSelected = value;

                Set(nameof(PostSelected), ref postSelected, value);
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

        public StartViewModel(IRedditService rs)
        {
            this.redditService = rs;

            Title = "Reddit Tops";

            _ = LoadData();
            
        }

        private async Task LoadData()
        {
            Posts = new ObservableCollection<Post>(await redditService.GetTopPosts());
        }

    }
}