using System.Text.Json.Serialization;

namespace Dashboard.Models.Near_Earth_Object
{
	public class Kilometers
	{
		[JsonPropertyName("estimated_diameter_min")]
		public decimal MaxKM { get; set; }

		[JsonPropertyName("estimated_diameter_max")]
		public decimal MinKM { get; set; }
	}
}
