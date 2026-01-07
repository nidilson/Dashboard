using System.Text.Json.Serialization;

namespace Dashboard.Models.Near_Earth_Object
{
	public class Diameter
	{
		[JsonPropertyName("kilometers")]
		public Kilometers KM { get; set; }
		[JsonPropertyName("meters")]
		public Meters M { get; set; }
	}
}
