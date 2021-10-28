using ApiProjectTony.Models.ViewModels.ApiResponseModels;
using ApiProjectTony.Models.ViewModels.DTOs;
using ApiProjectTony.Services.Abstracts;
using ApiProjectTony.Services.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiProjectTony.Services.Concretes
{
    public class XonaService : IXonaService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;

        private readonly HttpClient client;
        public XonaService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;

            client = this.clientFactory.CreateClient();

            // baseAddress can be changed in appsettings.json
            client.BaseAddress = new Uri(this.configuration.GetValue<string>("XonaServiceURL"));

        }

        public async Task<UserTokenRM> GetUserAsync(UserLoginDTO credentials)
        {

            UserTokenRM res = new UserTokenRM();

            string a = JsonConvert.SerializeObject(credentials);
            HttpContent httpContent = new StringContent(a, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(client.BaseAddress + "api:fOkc7x18/auth/login", httpContent);

            if (response.IsSuccessStatusCode)
            {
                string httpResponse = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<UserTokenRM>(httpResponse);
            }

            return res;
        }

    }
}
