using Dashboard.Models.Country;
using Dashboard.Models.Pokemon;
using Dashboard.Servicios;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using System.Drawing;

namespace DashboardTesting
{
	public class APITesting
	{
		public Mock<IHttpClientFactory> factory;
		public APIService service;
		private readonly ITestOutputHelper _output;
		public APITesting(ITestOutputHelper output) {
			_output = output;
			factory = new Mock<IHttpClientFactory>();
			// HttpClient "fake" para el test
			var httpClient = new HttpClient();

			factory
				.Setup(f => f.CreateClient(It.IsAny<string>()))
				.Returns(httpClient);
			service = new APIService(factory.Object);
		}
		[Fact]
		public async Task GetAllCountriesTest()
		{
			//Arrange
			List<Country> list = new List<Country>();

			//Act
			list = await service.GetAll<Country>(new Uri("https://restcountries.com/v3.1/all?fields=cca3,area,capital,continents,name,population,region"));

			string output = "";
			list.ForEach(i =>  output += $"{i.Name.Official} - {i.Area.ToString()}\n");

			_output.WriteLine(output);
			
			//Assert
			Assert.True(list.Count > 0);
		}

		[Fact]
		public async Task GetAllPokemonTest()
		{
			//Arrange
			PokemonResult result = new PokemonResult();
			string output = "";

			//Act
			result = await service.Get<PokemonResult>(new Uri("https://pokeapi.co/api/v2/pokemon?offset=0&limit=151"));			
			result.Result.ForEach(i => output += $"{i.Name} - {i.Url}\n");
			_output.WriteLine(output);

			//Assert
			Assert.True(result.Result.Count > 0);
		}
		[Fact]
		public async Task GetPokemonTest()
		{
			//Arrange
			PokemonResult result = new PokemonResult();
			Pokemon pokemonPrueba = new Pokemon();
			string output = "";
			//Act
			result = await service.Get<PokemonResult>(new Uri("https://pokeapi.co/api/v2/pokemon?offset=0&limit=151"));			
			
			pokemonPrueba = await service.Get<Pokemon>(new Uri(result.Result[6].Url));
			string statsPokemon = "";
			pokemonPrueba.Stats.ForEach(stat => statsPokemon += $"{stat.Stat.Name} - {stat.BaseStat}\n");
			output = $"{pokemonPrueba.Id} | {pokemonPrueba.Name} | {pokemonPrueba.Url} | {pokemonPrueba.Height} \n {statsPokemon}";


			_output.WriteLine(output);

			//Assert
			Assert.True(pokemonPrueba != null);
		}

	}
}
