﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RedditUWP.Models;
using RedditUWP.Services;
using System.Collections.ObjectModel;
using System.Linq;
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
        private bool isLoading = true;
        private RelayCommand<Post> _dismissCommand;
        #endregion

        public RelayCommand<Post> DismissCommand
        {
            get
            {
                return _dismissCommand ?? (_dismissCommand = new RelayCommand<Post>(
                    (Post item) =>
                    {
                        if (PostSelected != null && PostSelected.data.id == item.data.id)
                        {
                            PostSelected = null;
                        }

                        this.Posts.Remove(item);
                    }));
            }
        }

        public ObservableCollection<Post> Posts
        {
            get { return posts; }
            set
            {
                Set(nameof(Posts), ref posts, value);

                IsLoading = false;
            }
        }

        public Post PostSelected
        {
            get { return postSelected; }
            set
            {
                if (value != null)
                {
                    value.data.Read = true;
                }
                
                Set(nameof(PostSelected), ref postSelected, value);
            }
        }

        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;

                Set(nameof(IsLoading), ref isLoading, value);
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

            IsLoading = true;

            Title = "Reddit Top Posts";

            _ = LoadData();

          

        }

        public async Task LoadData()
        {
            Posts = new ObservableCollection<Post>(await redditService.GetTopPosts());

            
        }

    }
}