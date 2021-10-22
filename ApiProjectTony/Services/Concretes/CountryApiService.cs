using ApiProjectTony.Services.Abstracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiProjectTony.Services.Concretes
{
    public class CountryApiService : ICountryApiService
    {

        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;

        private readonly HttpClient client;
        public CountryApiService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;

            client = this.clientFactory.CreateClient();

            client.BaseAddress = new Uri(this.configuration.GetValue<string>("CountryApiServiceURL"));

        }


        public async Task<dynamic> getCountryNamesAsync(string region)
        {
            var response = await client.GetAsync(string.Format("?region={0}", region));
            string content = await response.Content.ReadAsStringAsync();
            
            return content;

        }
    }
}
