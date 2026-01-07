using System.Text.Json.Serialization;

namespace Dashboard.Models.Near_Earth_Object
{
	public class RelativeVelocity
	{
		[JsonPropertyName("kilometers_per_second")]
		public string KilometersPerSecond { get; set; }

		[JsonPropertyName("kilometers_per_hour")]
		public string KilometersPerHour { get; set; }

		[JsonPropertyName("miles_per_hour")]
		public string MilesPerHour { get; set; }
	}
}
