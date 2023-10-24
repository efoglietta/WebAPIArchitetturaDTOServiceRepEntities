using ArchitetturaDTOEntities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
//using Newtonsoft;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Text;

namespace ArchitetturaDTOEntities.Controller
{
    //nuget Microsoft.AspNet.WebApi.Client
    [Route("api/[controller]")]
    [ApiController]
    public class CallerWebAPIController : ControllerBase
    {
        HttpClient _client;
        IConfiguration _config;
        public CallerWebAPIController(IConfiguration config)
        {
            _config=config;
            _client=new HttpClient()
            {
                BaseAddress=new Uri(_config.GetValue<string>("BaseAddressWebApiDipendentiDocker:Url"))
            };
        }
        [HttpGet]
        public async Task<ActionResult<List<Dipendente>>> ChiamaWebAPI()
        {
            using (_client)
            {               
                List<Dipendente> dipendenti = null;
                
                using (HttpResponseMessage response = await _client.GetAsync("")) //path=base address
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //var content = await response.Content.ReadAsStringAsync();
                        //if (!string.IsNullOrWhiteSpace(content) && content!="null")
                        //{
                        //    dipendenti = JsonConvert.DeserializeObject<List<Dipendente>>(content);
                        //}

                        dipendenti = await response.Content.ReadAsAsync<List<Dipendente>>();

                    }
                    return dipendenti;
                }
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Dipendente>>> InserisciWebAPI()
        {
            Dipendente d = new Dipendente { Id=10, Cognome="Orsolini", Nome="Andrea", Genere='F', CF="EFGGR23r2e2e", Email="mario@libero.it", Eta=19 };
            using (HttpClient client = new HttpClient())
            {
                string path = "http://localhost:5223/api/Dipendenti";
                //JSON nuget
                //  var stringContent = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
                //System.Text.Json namespace
                var stringContent = new StringContent(JsonSerializer.Serialize(d), Encoding.UTF8, "application/json");

                try
                {
                    using (HttpResponseMessage response = await client.PostAsync(path, stringContent))
                    {
                        //permette di intrappolare l'eccezione(response asincrona)
                        response.EnsureSuccessStatusCode();
                        //la web api restituisce lista aggiornata, quindi la deserializzo e restituisco
                        return await response.Content.ReadAsAsync<List<Dipendente>>();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPut]
        public async Task<ActionResult<List<Dipendente>>> AggiornaWebAPI()
        {
            Dipendente d = new Dipendente { Id=1, Cognome="Orsolini", Nome="Arturo", Genere='F', CF="EFGGR23r2e2e", Email="mario@libero.it", Eta=19 };
            using (HttpClient client = new HttpClient())
            {
                string path = "http://localhost:5223/api/Dipendenti/1";
                //  var stringContent = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
                var stringContent = new StringContent(JsonSerializer.Serialize(d), Encoding.UTF8, "application/json");
                try
                {
                    using (HttpResponseMessage response = await client.PutAsync(path, stringContent))
                    {
                        //permette di intrappolare l'eccezione(response asincrona)
                        response.EnsureSuccessStatusCode();
                        //la web api restituisce lista aggiornata, quindi la deserializzo e restituisco
                        return await response.Content.ReadAsAsync<List<Dipendente>>();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
