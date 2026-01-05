using System.Diagnostics;
using Dashboard.Models;
using Dashboard.Models.Country;
using Dashboard.Models.DTO;
using Dashboard.Models.Pokemon;
using Dashboard.Servicios;
using Dashboard.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAPIService _apiService;
		public HomeController(IAPIService apiService)
		{
            _apiService = apiService;
		}
		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CountryData()
        {
            List<Country> countries;
			PokemonResult pokemons;

			try
            {
                countries = await _apiService.GetAll<Country>(new Uri("https://restcountries.com/v3.1/all?fields=cca3,area,capital,continents,name,population,region"));
                pokemons = await _apiService.Get<PokemonResult>(new Uri("https://pokeapi.co/api/v2/pokemon?offset=0&limit=151"));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            ChartDataset<string, int> barChartDataset = Country.CountriesByRegion(countries);
            ChartDataset<string, decimal> pieChartDataset = Country.CountriesByArea(countries);
            ChartDataset<string, long> lineChartDataset = Country.PopulationByRegion(countries);
            ChartDataset<string, double> horBarChartDataset = Country.PopulationPerAreaByRegion(countries);

            return Ok(new { bar = barChartDataset, pie = pieChartDataset, line = lineChartDataset, horBar = horBarChartDataset, pok = pokemons.Result});
        }
		[HttpGet]
		public async Task<IActionResult> PokemonData()
		{
			PokemonResult pokemons;

			try
			{
				pokemons = await _apiService.Get<PokemonResult>(new Uri("https://pokeapi.co/api/v2/pokemon?offset=0&limit=151"));
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}

			return Ok(new { pok = pokemons.Result });
		}

		[HttpGet("Home/PokemonStats/{id}")]
        public async Task<IActionResult> pokemonStats(int id)
        {
            Pokemon pokemon;

			try
            {
				pokemon = await _apiService.Get<Pokemon>(new Uri($"https://pokeapi.co/api/v2/pokemon/{id}/"));

			}catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

            return Ok(new {name = pokemon.Name, labels = pokemon.Stats.Select(s => s.Stat.Name).ToList(), data = pokemon.Stats.Select(s => s.BaseStat).ToList(), sprite = pokemon.Sprites.Front});
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
