using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LabTestQ1.Model;
namespace LabTestQ1.Services
{
    public class ApiClient
    {
        private HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com"); // Replace with your API base URL
        }

        public async Task<List<PostRecords>> GetPostsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/posts");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<PostRecords>>(content);
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., logging)
            }

            return null;
        }

        public async Task<string> AddPostAsync(PostRecords records)
        {
            try
            {
                var postData = new Dictionary<string, string>
        {
            { "userId", records.UserId.ToString() },
            { "title", records.Title },
            { "body", records.Body },
        };

                var content = new FormUrlEncodedContent(postData);

                var response = await _httpClient.PostAsync("/posts", content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., logging)
            }

            return null;
        }
        public async Task<bool> DeletePostAsync(int userId, int postId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/posts/{postId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., logging)
            }

            return false;
        }
    
}
}
