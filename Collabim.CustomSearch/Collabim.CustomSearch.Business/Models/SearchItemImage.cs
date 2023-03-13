using Newtonsoft.Json;

namespace Collabim.CustomSearch.Business.Models
{
   [JsonObject(MemberSerialization.OptIn)]
	public class SearchItemImage
	{
		[JsonProperty("src")]
		public string Src { get; set; }

		[JsonProperty("width")]
		public int Width { get; set; }

		[JsonProperty("height")]
		public int Height { get; set; }
	}
}