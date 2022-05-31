using BlazorAppDemo.DTOs;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace BlazorAppDemo.Services
{
    public class PokeAPIService
    {
        private readonly IHttpClientFactory _httpClientFactory; 
        public PokeAPIService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory; 
        }

        public async Task<PokeAPIDTO> FetchData()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,"https://pokeapi.co/api/v2/pokemon-species/")
            {
                Headers =
                {
                    { HeaderNames.Accept, "*/*" },
                    { HeaderNames.UserAgent, "ArtturoBld-BlazorApp" }
                }
            };

            var httpClient = _httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                return await JsonSerializer.DeserializeAsync<PokeAPIDTO>(contentStream);
            }
            else
            {
                return null;
            }
        }
    }
}
