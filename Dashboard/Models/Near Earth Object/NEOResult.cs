using System.Text.Json.Serialization;

namespace Dashboard.Models.Near_Earth_Object
{
	public class NEOResult
	{
		[JsonPropertyName("near_earth_objects")]
		public Dictionary<string, List<NEO>> data { get; set; }
	}
}
