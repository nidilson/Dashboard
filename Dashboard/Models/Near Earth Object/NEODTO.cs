using System.Text.Json.Serialization;

namespace Dashboard.Models.Near_Earth_Object
{
	public class NEODTO
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("name")]
		public string Name { get; set; }
		[JsonPropertyName("nasa_jpl_url")]
		public string JPL { get; set; }
		[JsonPropertyName("is_potencially_hazardous")]
		public bool Hazardous { get; set; }
		[JsonPropertyName("velocity")]
		public string Velocity { get; set; }
		[JsonPropertyName("max_diam")]
		public decimal MaxDiameter { get; set; }
		[JsonPropertyName("min_diam")]
		public decimal MinDiameter { get; set; }
	}
}
