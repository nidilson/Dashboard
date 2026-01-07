using System.Text.Json.Serialization;

namespace Dashboard.Models.Pokemon
{
	public class Sprites
	{
		[JsonPropertyName("front_default")]
		public string Front { get; set; }

	}
}
