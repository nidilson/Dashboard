using Dashboard.Models;
using Dashboard.Servicios.Interfaces;
using System.Text.Json;

namespace Dashboard.Servicios
{
	public class APIService : IAPIService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public APIService(IHttpClientFactory clientFactory) { 
			_httpClientFactory = clientFactory;
		}
		/// <summary>
		/// Funcion genérica que obtiene datos de una API, verbo GET
		/// </summary>
		/// <typeparam name="T">Tipo de datos que se desea obtener de la API</typeparam>
		/// <param name="uri">URI donde se encuentra el recurso</param>
		/// <returns>Lista de tipo T con los datos obtenidos de la API</returns>
		public async Task<List<T>> GetAll<T>(Uri uri)
		{
			try
			{
				var cliente = _httpClientFactory.CreateClient();
				var respuesta = await cliente.GetAsync(uri);
				respuesta.EnsureSuccessStatusCode();

				var contentStream = await respuesta.Content.ReadAsStreamAsync();

				Console.WriteLine(contentStream);

				return await JsonSerializer.DeserializeAsync<List<T>>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
				
			}
			catch (HttpRequestException ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Funcion genérica que obtiene datos de una API, verbo GET
		/// </summary>
		/// <typeparam name="T">Tipo de datos que se desea obtener de la API</typeparam>
		/// <param name="uri">URI donde se encuentra el recurso</param>
		/// <returns>Objeto de tipo T con los datos obtenidos de la API</returns>
		public async Task<T> Get<T>(Uri uri)
		{
			try
			{
				var cliente = _httpClientFactory.CreateClient();
				
				var respuesta = await cliente.GetAsync(uri);
				respuesta.EnsureSuccessStatusCode();

				var contentStream = await respuesta.Content.ReadAsStreamAsync();

				return await JsonSerializer.DeserializeAsync<T>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
				
			}
			catch (HttpRequestException ex)
			{
				throw ex;
			}
		}
	}
}
