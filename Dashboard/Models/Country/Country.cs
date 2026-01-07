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

		public static ChartDataset<string, decimal> CountriesByArea(List<Country> list)
		{
			ChartDataset<string, decimal> dataset = new ChartDataset<string, decimal>();
			List<Country> orderedList = list.OrderByDescending(c => c.Area).ToList();

			for (int i = 0; i < orderedList.Count; i++)
			{
				if (i > 9)
				{
					decimal restOfCountriesArea = orderedList.Slice(i, orderedList.Count - i).Aggregate(0m, (a, c) => a + c.Area);
					dataset.Labels.Add("Demás Países");
					dataset.Data.Add(restOfCountriesArea);
					break;
				}
				dataset.Labels.Add(orderedList[i].Name.Official);
				dataset.Data.Add(orderedList[i].Area);
			}

			return dataset;
		}

		public static ChartDataset<string, long> PopulationByRegion(List<Country> list)
		{
			ChartDataset<string, long> dataset = new ChartDataset<string, long>();
			foreach (var country in list)
			{
				if (!dataset.Labels.Contains(country.Region))
				{
					dataset.Labels.Add(country.Region);
				}
			}

			for(int i = 0; i < dataset.Labels.Count; i++)
			{
				dataset.Data.Add((long) list.Aggregate(0L, (a, c) =>
				{
					if (!c.Region.Equals(dataset.Labels[i]))
					{
						return a + 0;
					}
					return a + c.Population;
				}));
			}
			return dataset;
		}

		public static ChartDataset<string, double> PopulationPerAreaByRegion(List<Country> list)
		{
			ChartDataset<string, double> dataset = new ChartDataset<string, double>();

			foreach (var country in list)
			{
				if (!dataset.Labels.Contains(country.Region))
				{
					dataset.Labels.Add(country.Region);
				}
			}

			for(int i = 0; i < dataset.Labels.Count; i++)
			{
				double populationAccumulate = list.Where(c => c.Region.Equals(dataset.Labels[i])).Aggregate(0d, (acc, country) => acc + country.Population);
				double areaAccumulate = list.Where(c => c.Region.Equals(dataset.Labels[i])).Aggregate(0d, (acc, country) => acc + (double) country.Area);
				dataset.Data.Add(populationAccumulate / areaAccumulate);
			}

			return dataset;
		}
	}
}
