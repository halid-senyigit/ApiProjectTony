using ApiProjectTony.Models.ViewModels;
using ApiProjectTony.Services.Abstracts;
using ApiProjectTony.Services.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiProjectTony.Services.Concretes
{
    public class UserApiService : IUserApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;

        private readonly HttpClient client;
        public UserApiService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;

            client = this.clientFactory.CreateClient();

            // baseAddress can be changed in appsettings.json
            client.BaseAddress = new Uri(this.configuration.GetValue<string>("UserApiServiceURL"));

        }

        public async Task<UserApiModel> GetUserAsync()
        {
            HttpResponseMessage httpResponse = await client.GetAsync("");
            UserApiModel res = new UserApiModel();
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    res = JsonConvert.DeserializeObject<UserApiModel>(await httpResponse.Content.ReadAsStringAsync());
                } catch (Exception ex)
                {
                    // we can use a ServiceModel to return generic Data, Status and Message
                }
            }
            else
            {
                throw new Exception("http error");
            }

            return res;
        }
    }
}
