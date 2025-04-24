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
        public List<Machines> GetAllMachines()
        {
            List<Machines> machines = new List<Machines>();
                        
            HttpResponseMessage response = _httpClient.GetAsync($"{Controller.Machines}/GetAllMachines").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                machines = JsonConvert.DeserializeObject<List<Machines>>(content);
            }

            return machines;
        }

        public Machines GetMachineById(int id)
        {
            Machines machine = null;

            _httpClient.BaseAddress = new Uri("https://localhost:44344/");
            HttpResponseMessage response = _httpClient.GetAsync($"{Controller.Machines}/GetMachineById/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                machine = JsonConvert.DeserializeObject<Machines>(content);
            }

            return machine;
        }

        public bool UpdateMachine(Machines machine)
        {
            bool isUpdated = false;

            _httpClient.BaseAddress = new Uri("https://localhost:44344/");
            var jsonContent = JsonConvert.SerializeObject(machine);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync($"{Controller.Machines}/UpdateMachine", content).Result;

            if (response.IsSuccessStatusCode)
            {
                isUpdated = true;
            }

            return isUpdated;
        }

        public bool DeleteMachine(string machineCode)
        {
            bool isDeleted = false;

            _httpClient.BaseAddress = new Uri("https://localhost:44344/");
            HttpResponseMessage response = _httpClient.DeleteAsync($"{Controller.Machines}/DeleteMachine/{machineCode}").Result;

            if (response.IsSuccessStatusCode)
            {
                isDeleted = true;
            }

            return isDeleted;
        }

        public bool DeleteMachine(Machines machine)
        {
            bool isDeleted = false;

            _httpClient.BaseAddress = new Uri("https://localhost:44344/");
            var jsonContent = JsonConvert.SerializeObject(machine);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync($"{Controller.Machines}/DeleteMachine", content).Result;

            if (response.IsSuccessStatusCode)
            {
                isDeleted = true;
            }

            return isDeleted;
        }

        public bool InsertMachine(Machines machine, int ToolType)
        {
            bool isInserted = false;

            _httpClient.BaseAddress = new Uri("https://localhost:44344/");

            //Aggiungi il ToolType all'oggetto Machines
            machine.ToolType = ToolType;

            //Serializza l'oggetto Machines in JSON
            var jsonContent = JsonConvert.SerializeObject(machine);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Effettua la chiamata POST all'API
            HttpResponseMessage response = _httpClient.PostAsync($"{Controller.Machines}/InsertMachine", content).Result;

            if (response.IsSuccessStatusCode)
            {
                isInserted = true;
            }

            return isInserted;
        }

        public bool UpdateAllMachinesTypes()
        {
            bool isUpdated = false;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44344/");
                HttpResponseMessage response = client.PutAsync($"{Controller.Machines}/UpdateAllMachinesTypes", null).Result;

                if (response.IsSuccessStatusCode)
                {
                    isUpdated = true;
                }
            }

            return isUpdated;
        }
    }
}
