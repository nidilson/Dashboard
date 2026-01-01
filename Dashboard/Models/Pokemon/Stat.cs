using System.Text.Json.Serialization;

namespace Dashboard.Models.Pokemon
{
	public class Stat
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("url")]
		public string Url { get; set; }
	}
}
