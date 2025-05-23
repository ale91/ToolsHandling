﻿using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public partial class WebAPIClient
    {
        public List<Tools> GetAllTools()
        {
            List<Tools> tools = new List<Tools>();

            HttpResponseMessage response = _httpClient.GetAsync("api/Tools/GetAllTools").Result;

            //HttpResponseMessage response = _httpClient.GetAsync($"{Controller.Tools}/GetAllTools").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                tools = JsonConvert.DeserializeObject<List<Tools>>(content);
            }

            return tools;
        }

        public Tools GetToolsById(string idTool)
        {
            Tools tool = null;

            //_httpClient.BaseAddress = new Uri("https://localhost:44344/");
            HttpResponseMessage response = _httpClient.GetAsync($"{Controller.Tools}/GetToolsById/{idTool}").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                tool = JsonConvert.DeserializeObject<Tools>(content);
            }

            return tool;
        }

        public Tools InsertTools(Tools tool)
        {
            //_httpClient.BaseAddress = new Uri("https://localhost:44344/");
            var jsonContent = JsonConvert.SerializeObject(tool);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync($"{Controller.Tools}/InsertTools", content).Result;

            var resultContent = response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Tools>(resultContent.Result); //Restituisce il tool deserializzato
            }
            else
            {
                throw new Exception(resultContent.Result);
            }
            return null;
        }

        public bool UpdateTools(Tools tool)
        {
            bool isUpdated = false;


            var jsonContent = JsonConvert.SerializeObject(tool);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync($"{Controller.Tools}/UpdateTools", content).Result;

            if (response.IsSuccessStatusCode)
            {
                isUpdated = true;
            }

            return isUpdated;
        }

        public bool DeleteTools(string idTool)
        {
            bool isDeleted = false;

            var jsonContent = JsonConvert.SerializeObject(idTool);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync($"{Controller.Tools}/DeleteTools", content).Result;

            if (response.IsSuccessStatusCode)
            {
                isDeleted = true;
            }

            return isDeleted;
        }

        public bool UpdateAllToolsType()
        {
            bool isUpdated = false;

            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://localhost:44344/");
                HttpResponseMessage response = client.PutAsync($"{Controller.Tools}/UpdateAllToolsType", null).Result;

                if (response.IsSuccessStatusCode)
                {
                    isUpdated = true;
                }
            }

            return isUpdated;
        }

        public bool UpdateAllToolTypes()
        {
            bool isUpdated = false;

            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://localhost:44344/");
                HttpResponseMessage response = client.PutAsync($"{Controller.Tools}/UpdateAllToolTypes", null).Result;

                if (response.IsSuccessStatusCode)
                {
                    isUpdated = true;
                }
            }

            return isUpdated;
        }

        public List<Tools> GetToolsByToolType(int toolType, bool isMounted = true)
        {
            List<Tools> tools = new List<Tools>();

            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://localhost:44344/");
                HttpResponseMessage response = client.GetAsync($"{Controller.Tools}/GetToolsByToolType?toolType={toolType}&isMounted={isMounted}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    tools = JsonConvert.DeserializeObject<List<Tools>>(content);
                }
            }

            return tools;
        }

        public List<Tools> GetToolsByMachine(string machineCode)
        {
            List<Tools> tools = new List<Tools>();

            //_httpClient.BaseAddress = new Uri("https://localhost:44344/");
            HttpResponseMessage response = _httpClient.GetAsync($"{Controller.Tools}/GetToolsByMachine/{machineCode}").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                tools = JsonConvert.DeserializeObject<List<Tools>>(content);
            }

            return tools;
        }

        public List<Turrets> GetAllTurrets()
        {
            List<Turrets> turrets = new List<Turrets>();

            HttpResponseMessage response = _httpClient.GetAsync("api/Turrets/GetAllTurrets").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                turrets = JsonConvert.DeserializeObject<List<Turrets>>(content);
            }

            return turrets;
        }

    }
}
