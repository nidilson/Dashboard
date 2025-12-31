using Dashboard.Models;

namespace Dashboard.Servicios.Interfaces
{
	public interface ICountriesService
	{
		public Task<List<Country>> GetAll();
	}
}
