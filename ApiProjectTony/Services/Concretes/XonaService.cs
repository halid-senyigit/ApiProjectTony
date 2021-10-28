using ApiProjectTony.Extensions;
using ApiProjectTony.Models.ViewModels.ApiResponseModels;
using ApiProjectTony.Models.ViewModels.DTOs;
using ApiProjectTony.Services.Abstracts;
using ApiProjectTony.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiProjectTony.Services.Concretes
{
    public class XonaService : IXonaService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly HttpContext httpContext;
        private readonly HttpClient client;
        private readonly string token;
        public XonaService(
            IHttpClientFactory clientFactory, 
            IConfiguration configuration,
            IHttpContextAccessor httpContext
            )
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.httpContext = httpContext.HttpContext;
            this.token = this.httpContext.Session.GetJson<string>("token");

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


        public async Task<List<ContentApiModel>> GetContentAsync()
        {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage httpResponse = await client.GetAsync(client.BaseAddress + "api:-Kh4zXMz/content");
            List<ContentApiModel> res = new List<ContentApiModel>();
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    res = JsonConvert.DeserializeObject<List<ContentApiModel>>(await httpResponse.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                    httpContext.Session.Remove("token");
                    // remove token from session
                }
            }
            else
            {
                // if status is 401 remove token from session (actually these codes should be written into business layer) 
                if(httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    httpContext.Session.Remove("token");
                }
                throw new Exception("http error");
            }

            return res;
        }


    }
}
