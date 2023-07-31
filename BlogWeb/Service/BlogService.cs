using BlogModels;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace BlogWeb.Service
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7097";
        public BlogService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
            
        }
        public async Task<IEnumerable<Blog>> GetblogsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Blog/");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<Blog> blog = JsonConvert.DeserializeObject<IEnumerable<Blog>>(content);
            return blog;
        }
        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Blog/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            Blog blogPost = JsonConvert.DeserializeObject<Blog>(content);
            return blogPost;
        }
        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            string json = JsonConvert.SerializeObject(blog);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/api/Blog/Create/", content);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            Blog createdBlogPost = JsonConvert.DeserializeObject<Blog>(responseContent);
            return createdBlogPost;

        }
        public async Task<Blog> UpdateBlogAsync(int id, Blog blog)
        {
            string json = JsonConvert.SerializeObject(blog);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync($"/api/Blog/{id}", content);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            Blog updatedBlog = JsonConvert.DeserializeObject<Blog>(responseContent);
            return updatedBlog;
        }

        public async Task DeleteBlogAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/Blog/{id}");
            response.EnsureSuccessStatusCode();
        }


    }
}
