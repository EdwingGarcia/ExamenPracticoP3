using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TAreasAPP.Models;

namespace TAreasAPP.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://10.0.2.2:7068";

        public ApiService() {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_url)

            };
        }

        public async Task<List<Tarea>> GetAllTarea()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Tarea>>("api/Tarea");
            return response;
        }

        // POST api/<ClienteController>
        public async Task<Tarea> CreateTarea(Tarea tarea)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Tarea", tarea);
            Console.WriteLine(response.Content.ReadAsStringAsync());
            if (response != null) { return await response.Content.ReadFromJsonAsync<Tarea>(); }
            return null;

        }
        public async Task<List<Tarea>> BuscarTareaNombreEstado(string Nombre, string Estado)
        {
    
                var response = await _httpClient.GetFromJsonAsync<List<Tarea>>($"api/Animal/GetAnimalesPorCedula/{Nombre}/{Estado}");
                return response;

        }

    }
}
