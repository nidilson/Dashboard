using System.Text.Json.Serialization;

namespace Dashboard.Models.Near_Earth_Object
{
	public class ApproachData
	{
		[JsonPropertyName("close_approach_date")]
		public string CloseApproachDate { get; set; }

		[JsonPropertyName("close_approach_date_full")]
		public string CloseApproachDateFull { get; set; }

		[JsonPropertyName("epoch_date_close_approach")]
		public long EpochDateCloseApproach { get; set; }

		[JsonPropertyName("relative_velocity")]
		public RelativeVelocity RelativeVelocity { get; set; }

		[JsonPropertyName("orbiting_body")]
		public string OrbitingBody { get; set; }
	}
}
