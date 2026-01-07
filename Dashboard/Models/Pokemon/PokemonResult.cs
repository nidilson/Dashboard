using System.Text.Json.Serialization;

namespace Dashboard.Models.Pokemon
{
	public class PokemonResult
	{
		[JsonPropertyName("results")]
		public List<Pokemon> Result { get; set; }
	}
}
