using ApiProjectTony.Models.ViewModels.ApiResponseModels;
using ApiProjectTony.Models.ViewModels.DTOs;
using ApiProjectTony.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjectTony.Services.Abstracts
{
    public interface IXonaService
    {
        public Task<UserTokenRM> GetUserAsync(UserLoginDTO credentials);

        public Task<List<ContentApiModel>> GetContentAsync();
    }
}
