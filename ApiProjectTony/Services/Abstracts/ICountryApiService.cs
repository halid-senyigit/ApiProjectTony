using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjectTony.Services.Abstracts
{
    public interface ICountryApiService
    {
        public Task<dynamic> getCountryNamesAsync(string region);
    }
}
