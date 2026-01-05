using System.Text.Json.Serialization;

namespace Dashboard.Models.Pokemon
{
	public class Pokemon
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("height")]
		public double Height { get; set; }

		[JsonPropertyName("stats")]
		public List<Stats> Stats { get; set; }

		[JsonPropertyName("url")]
		public string Url { get; set; }

		[JsonPropertyName("sprites")]
		public Sprites Sprites { get; set; }

	}
}
