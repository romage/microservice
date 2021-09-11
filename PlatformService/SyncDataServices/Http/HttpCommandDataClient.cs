using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformService.Dtos;


namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration config)
        {
            this._httpClient = httpClient;
            this._config = config;
        }
        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                encoding: Encoding.UTF8,
                "application/json"
            );
            // {
            var response = await _httpClient.PostAsync(_config["CommandService"], httpContent);
            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync Post to command service was OK");
            }
            else
            {
                Console.WriteLine("--> Sync Post to Command  service was not OK");
            }
        }
    }

}