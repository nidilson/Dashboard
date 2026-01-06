using System.Text.Json.Serialization;

namespace Dashboard.Models.Near_Earth_Object
{
	public class Meters
	{
		[JsonPropertyName("estimated_diameter_min")]
		public decimal MaxM { get; set; }

		[JsonPropertyName("estimated_diameter_max")]
		public decimal MinM { get; set; }
	}
}
