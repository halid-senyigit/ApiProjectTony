using ApiProjectTony.Services.Models;
using System.Threading.Tasks;

namespace ApiProjectTony.Services.Abstracts
{
    public interface IUserApiService
    {
        public Task<UserApiModel> GetUserAsync();
    }
}
