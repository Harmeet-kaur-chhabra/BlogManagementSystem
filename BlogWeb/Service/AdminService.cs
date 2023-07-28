using BlogModels;
using Newtonsoft.Json;
using System.Net;

namespace BlogManagementWeb.Service
{
    public class AdminService : IAdminService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7097";

        public AdminService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
            
        }
        public async Task<IEnumerable<Blog>> GetUsersAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Admin/GetAllNoActionTakenBlogs");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<Blog> blog = JsonConvert.DeserializeObject<IEnumerable<Blog>>(content);
            return blog;
        }

        public async Task<bool> ApproveBlog(int id)
        {
            var response = await _httpClient.GetAsync($"api/Admin/ApprovedBlog?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Blog not found.");
            }
            else
            {
                throw new Exception("Error approving blog.");
            }
        }

        public async Task<bool> RejectBlog(int id)
        {
            var response = await _httpClient.GetAsync($"api/Admin/RejectBlog?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Blog not found.");
            }
            else
            {
                throw new Exception("Error rejecting blog.");
            }

        }
    }
}
