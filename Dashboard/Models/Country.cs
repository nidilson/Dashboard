using System.Text.Json.Serialization;

namespace Dashboard.Models
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

	}
}
