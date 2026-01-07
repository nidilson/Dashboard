using System.Text.Json.Serialization;

namespace Dashboard.Models.Pokemon
{
	public class Stats
	{
		[JsonPropertyName("base_stat")]
		public double BaseStat { get; set; }

		[JsonPropertyName("stat")]
		public Stat Stat { get; set; }
	}
}
