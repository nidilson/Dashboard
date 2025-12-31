using Dashboard.Models;
using Dashboard.Servicios.Interfaces;
using System.Text.Json;

namespace Dashboard.Servicios
{
	public class CountriesService : ICountriesService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public CountriesService(IHttpClientFactory clientFactory) { 
			_httpClientFactory = clientFactory;
		}
		public async Task<List<Country>> GetAll()
		{
			try
			{
				using(var cliente = _httpClientFactory.CreateClient())
				{
					//Cambiar asignación por await cliente.GetAsync("/all?fields=cca3,area,capital,continents,name,population,region")
					var respuesta = await cliente.GetAsync(new Uri("https://restcountries.com/v3.1/all?fields=cca3,area,capital,continents,name,population,region"));
					respuesta.EnsureSuccessStatusCode();

					var contentStream = await respuesta.Content.ReadAsStreamAsync();

					Console.WriteLine(contentStream);

					return await JsonSerializer.DeserializeAsync<List<Country>>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
				}
			}
			catch (HttpRequestException ex)
			{
				throw ex;
			}
		}
	}
}
