using System.Diagnostics;
using Dashboard.Models;
using Dashboard.Models.Country;
using Dashboard.Models.DTO;
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
            List<Country> countries = await _apiService.GetAll<Country>(new Uri("https://restcountries.com/v3.1/all?fields=cca3,area,capital,continents,name,population,region"));
            ChartDataset<string, int> barChartDataset = Country.CountriesByRegion(countries);
            return Ok(new { bar= barChartDataset });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
