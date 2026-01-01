using Dashboard.Models;

namespace Dashboard.Servicios.Interfaces
{
	public interface IAPIService
	{
		public Task<List<T>> GetAll<T>(Uri uri);

		public Task<T> Get<T>(Uri uri);
	}
}
