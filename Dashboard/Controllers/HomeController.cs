using System.Diagnostics;
using Dashboard.Models;
using Dashboard.Models.Country;
using Dashboard.Models.DTO;
using Dashboard.Models.Near_Earth_Object;
using Dashboard.Models.Pokemon;
using Dashboard.Servicios;
using Dashboard.Servicios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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
        /// <summary>
        /// Controler para vista principal (dashboard)
        /// </summary>
        /// <returns>Vista del Dashboard</returns>
		public IActionResult Index()
        {
            ViewBag.Title = "Dashboard";
            ViewBag.MenuIndexSelected = 1;
            return View();
        }
        
        /// <summary>
        /// Controlador para la vista de la página Tables
        /// </summary>
        /// <returns>Vista de la página Tables</returns>
        public IActionResult Tables()
        {
			ViewBag.Title = "Tables";
			ViewBag.MenuIndexSelected = 2;
			return View();
        }

        public IActionResult Cards()
        {
			ViewBag.Title = "Cards";
			ViewBag.MenuIndexSelected = 3;
			return View();
		}
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// API que obtiene los datos de los países
        /// </summary>
        /// <returns>objeto con distintos datos procesados de los países</returns>
        [HttpGet]
        public async Task<IActionResult> Countries()
        {
            List<Country> countries;

			try
            {
                countries = await _apiService.GetAll<Country>(new Uri("https://restcountries.com/v3.1/all?fields=cca3,area,capital,continents,name,population,region"));
                
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            ChartDataset<string, int> barChartDataset = Country.CountriesByRegion(countries);
            ChartDataset<string, decimal> pieChartDataset = Country.CountriesByArea(countries);
            ChartDataset<string, long> lineChartDataset = Country.PopulationByRegion(countries);
            ChartDataset<string, double> horBarChartDataset = Country.PopulationPerAreaByRegion(countries);

            return Ok(new { bar = barChartDataset, pie = pieChartDataset, line = lineChartDataset, horBar = horBarChartDataset});
        }

        /// <summary>
        /// API que obtiene la lista de pokemon 1ra generación
        /// </summary>
        /// <returns>Lista con los pokemon 1ra generación</returns>
		[HttpGet]
		public async Task<IActionResult> Pokemons()
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

        /// <summary>
        /// API que obtiene las estadísticas de un pokemon
        /// </summary>
        /// <param name="id">ID del pokemon que se desea obtener las estadísticas</param>
        /// <returns>Objeto Pokemon con los datos y estadísticas del pokemon</returns>
		[HttpGet("Home/PokemonStats/{id}")]
        public async Task<IActionResult> PokemonStats(int id)
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

		/// <summary>
		/// API que obtiene las estadísticas de un pokemon
		/// </summary>
		/// <param name="id">ID del pokemon que se desea obtener las estadísticas</param>
		/// <returns>Objeto Pokemon con los datos y estadísticas del pokemon</returns>
		[HttpGet("Home/Pokemon/{id}")]
		public async Task<IActionResult> Pokemon(int id)
		{
			Pokemon pokemon;

			try
			{
				pokemon = await _apiService.Get<Pokemon>(new Uri($"https://pokeapi.co/api/v2/pokemon/{id}/"));

			}
			catch (Exception e)
			{
				return BadRequest(new { message = e.Message });
			}

			return Ok(pokemon);
		}

		/// <summary>
		/// API que obtiene los datos de los objetos cercanos a la tierra
		/// </summary>
		/// <param name="date">Fecha de la cual se desea obtener los datos</param>
		/// <returns></returns>

		[HttpGet("Home/NearEarthObjects/{date}")]
        public async Task<IActionResult> NearEarthObjects(string date)
        {
            string apiKey = Environment.GetEnvironmentVariable("NASA_API_Key");
            NEOResult result;
            try
            {
                result = await _apiService.Get<NEOResult>(new Uri($"https://api.nasa.gov/neo/rest/v1/feed?start_date={date}&end_date={date}&api_key={apiKey}"));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"Error: {e.Message}" });
            }

			List<NEODTO> response = new List<NEODTO>();

            result.data.First().Value.ForEach(neo =>
            {
                response.Add(new NEODTO
                {
                    Id = neo.Id,
                    Name = neo.Name,
                    JPL = neo.NasaJplUrl,
                    Hazardous = neo.IsPotenciallyHazardous,
                    Velocity = neo.CloseApproachData.First().RelativeVelocity.KilometersPerHour,
                    MaxDiameter = neo.EstimatedDiameter.KM.MaxKM,
                    MinDiameter = neo.EstimatedDiameter.KM.MinKM
                });
            });

            return Ok(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
