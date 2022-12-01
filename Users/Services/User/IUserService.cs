using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Services
{
    public interface IUserService
    {
        Task<PagedResponse<User>> GetAllUsers(int pageNumber = 1, int pageSize = 6, CancellationToken token = default);
    }
}
