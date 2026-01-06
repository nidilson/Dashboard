using System.Text.Json.Serialization;

namespace Dashboard.Models.Near_Earth_Object
{
	public class NEO
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("nasa_jpl_url")]
		public string NasaJplUrl { get; set; }

		[JsonPropertyName("is_potentially_hazardous_asteroid")]
		public bool IsPotenciallyHazardous { get; set; }

		[JsonPropertyName("close_approach_data")]
		public List<ApproachData> CloseApproachData { get; set; }

		[JsonPropertyName("estimated_diameter")]
		public Diameter EstimatedDiameter { get; set; }
	}
}
