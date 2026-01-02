using Dashboard.Models.DTO;
using System.Text.Json.Serialization;

namespace Dashboard.Models.Country
{
	public class Country
	{
		[JsonPropertyName("cca3")]
		public string Id { get; set; }

		[JsonPropertyName("name")]
		public CountryName Name { get; set; }

		[JsonPropertyName("capital")]
		public List<string> Capital { get; set; }

		[JsonPropertyName("region")]
		public string Region { get; set; }

		[JsonPropertyName("area")]
		public decimal Area { get; set; }

		[JsonPropertyName("population")]
		public long Population { get; set; }

		[JsonPropertyName("continents")]
		public List<string> Continents { get; set; }


		public static ChartDataset<string, int> CountriesByRegion(List<Country> list)
		{
			ChartDataset<string, int> dataset = new ChartDataset<string, int>();

			foreach (var country in list)
			{

				if (!dataset.Labels.Contains(country.Region))
				{
					dataset.Labels.Add(country.Region);
					dataset.Data.Add(0);
				}
				
				int index = dataset.Labels.IndexOf(country.Region);
				dataset.Data[index]++;
			}
			return dataset;
		}
	}
}
