using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WCFHttpClient
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        private HttpClient _client;

        public Service1(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetData(int value)
        {
            var content = string.Empty;   
            var response = await _client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{value}");
            content = await response.Content.ReadAsStringAsync();

            var pokemon = JsonConvert.DeserializeObject<Pokemon>(content);
                   
            return pokemon.Types[0].Type.Name;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
