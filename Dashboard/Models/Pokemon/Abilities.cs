using System.Text.Json.Serialization;

namespace Dashboard.Models.Pokemon
{
	public class Abilities
	{
		[JsonPropertyName("ability")]
		public Ability Ability { get; set; }

	}
}
