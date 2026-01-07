using System.Text.Json.Serialization;

namespace Dashboard.Models.DTO
{
	public class ChartDataset<L,D>
	{
		[JsonPropertyName("labels")]
		public List<L> Labels { get; set; }

		[JsonPropertyName("data")]
		public List<D> Data { get; set; }

		public ChartDataset()
		{
			Labels = new List<L>();
			Data = new List<D>();
		}
	}
}
