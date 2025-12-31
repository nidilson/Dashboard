using System.Text.Json.Serialization;

namespace Dashboard.Models
{
	public class CountryName
	{
		[JsonPropertyName("official")]
		public string Official { get; set; }
	}
}
