using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public partial class WebAPIClient
    {
        public List<PartNumbers> GetAllPartNumbers()
        {
            List<PartNumbers> partNumbers = new List<PartNumbers>();

            HttpResponseMessage response = _httpClient.GetAsync("api/PartNumbers/GetAllPartNumbers").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                partNumbers = JsonConvert.DeserializeObject<List<PartNumbers>>(content);
            }

            return partNumbers;
        }

        public PartNumbers GetPartNumberById(string id)
        {
            PartNumbers partNumber = null;

            HttpResponseMessage response = _httpClient.GetAsync($"api/PartNumbers/GetPartNumberById/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                partNumber = JsonConvert.DeserializeObject<PartNumbers>(content);
            }

            return partNumber;
        }

        public PartNumbers InsertPartNumber(PartNumbers partNumber)
        {
            var jsonContent = JsonConvert.SerializeObject(partNumber);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync("api/PartNumbers/InsertPartNumber", content).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultContent = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<PartNumbers>(resultContent);
            }

            throw new HttpRequestException(response.Content.ReadAsStringAsync().Result);
        }

        public bool UpdatePartNumber(PartNumbers partNumber)
        {
            var jsonContent = JsonConvert.SerializeObject(partNumber);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PutAsync("api/PartNumbers/UpdatePartNumber", content).Result;

            return response.IsSuccessStatusCode;
        }

        public bool DeletePartNumber(int id)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync($"api/PartNumbers/DeletePartNumber/{id}").Result;

            return response.IsSuccessStatusCode;
        }
    }
}
