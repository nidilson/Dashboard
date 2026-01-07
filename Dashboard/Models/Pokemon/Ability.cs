using System.Text.Json.Serialization;

namespace Dashboard.Models.Pokemon
{
	public class Ability
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }
	}
}
