using ApiProjectTony.Models.ViewModels.ApiResponseModels;
using ApiProjectTony.Models.ViewModels.DTOs;
using System.Threading.Tasks;

namespace ApiProjectTony.Services.Abstracts
{
    public interface IXonaService
    {
        public Task<UserTokenRM> GetUserAsync(UserLoginDTO credentials);
    }
}
