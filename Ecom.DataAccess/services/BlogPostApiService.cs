using Ecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecom.DataAccess.services
{
    public class BlogPostApiService : IBlogPosyApiService
    {
        private static readonly HttpClient _client;

        static BlogPostApiService()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
            };
        }
        public async Task<List<BlogPost>> GetBlogPosts()
        {
            var url = string.Format("/posts");
            var result = new List<BlogPost>();
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<BlogPost>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
