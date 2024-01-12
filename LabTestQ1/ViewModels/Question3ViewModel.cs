using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using LabTestQ1.Model; // Replace with the actual namespace for your PostRecords model
using LabTestQ1.Services;

namespace LabTestQ1.ViewModels
{
    public class Question3ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PostRecords> _posts;
        private ApiClient _apiClient;
        private string _title;
        private string _body;
        private int _userIdToDelete;
        private int _postIdToDelete;
        public ObservableCollection<PostRecords> Posts
        {
            get => _posts;
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Body
        {
            get => _body;
            set
            {
                if (_body != value)
                {
                    _body = value;
                    OnPropertyChanged();
                }
            }
        }
        public int UserIdToDelete
        {
            get => _userIdToDelete;
            set
            {
                _userIdToDelete = value;
                OnPropertyChanged();
            }
        }

        public int PostIdToDelete
        {
            get => _postIdToDelete;
            set
            {
                _postIdToDelete = value;
                OnPropertyChanged();
            }
        }

        public Command AddPostCommand { get; }
        public Command DeletePostCommand { get; }
        public Question3ViewModel()
        {
            _apiClient = new ApiClient(); // Initialize your API client

            // Load posts when the ViewModel is created
            LoadPosts();
            DeletePostCommand = new Command(async () => await DeletePostAsync());
            AddPostCommand = new Command(async () => await AddPostAsync(1,Title, Body));
        }

        private async void LoadPosts()
        {
            var posts = await _apiClient.GetPostsAsync();
            Posts = new ObservableCollection<PostRecords>(posts);
        }
       
        public async Task<bool> AddPostAsync(int userId, string title, string body)
        {
            // Create a new PostRecords object with the provided user ID, title, and body
            var newPost = new PostRecords
            {
                UserId = userId, 
                Title = title,
                Body = body
            };

            // Make the API call to add the post
            var result = await _apiClient.AddPostAsync(newPost);

            // Check if the API call was successful
            if (!string.IsNullOrEmpty(result))
            {

                // Reload the posts after adding a new one
                LoadPosts();

                return true;
            }

            return false;
        }

        public async Task<bool> DeletePostAsync()
        {
            // Make the API call to delete the post by User ID and Post ID
            var result = await _apiClient.DeletePostAsync(UserIdToDelete, PostIdToDelete);

            // Check if the API call was successful
            if (result)
            {
                // Remove the deleted post from the collection
                var deletedPost = Posts.FirstOrDefault(p => p.UserId == UserIdToDelete && p.Id == PostIdToDelete);
                if (deletedPost != null)
                {
                    Posts.Remove(deletedPost);
                    LoadPosts();
                }

                return true;
            }

            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
