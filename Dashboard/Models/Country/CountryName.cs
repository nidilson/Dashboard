using System.Text.Json.Serialization;

namespace Dashboard.Models.Country
{
	public class CountryName
	{
		[JsonPropertyName("official")]
		public string Official { get; set; }
	}
}
