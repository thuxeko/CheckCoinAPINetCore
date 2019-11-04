using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace checkcoiAPI.Services
{
    public class BaseService
    {
        private HttpClient _httpClient;
        public async Task<T> GetVLAsync<T>(Uri requestUrl)
        {
            _httpClient = new HttpClient();
            var res = await _httpClient.GetAsync(requestUrl).Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(res);
        }
    }
}
