using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using Users.Models;

namespace Users.Services
{
    public class UserService : IUserService
    {
        public async Task<PagedResponse<User>> GetAllUsers(int pageNumber = 1, int pageSize = 6, CancellationToken token = default)
        {
            var resource = string.Format("https://reqres.in/api/users?page={0}&per_page={1}", pageNumber, pageSize);
            var request = new RestRequest(resource);
            var client = new RestClient();
            var data = new PagedResponse<User>();
            try
            {
                var response = await client.GetAsync(request, token);
                data = Newtonsoft.Json.JsonConvert.DeserializeObject<PagedResponse<User>>(response.Content);
            }
            catch (Exception ex)
            {
            }
            return data;
        }
    }
}
