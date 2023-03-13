namespace Collabim.CustomSearch.Business.Models
{
	public class SearchItem
	{
		public string CacheId { get; set; }

		public string DisplayLink { get; set; }

		public string FileFormat { get; set; }

		public string FormattedUrl { get; set; }

		public string HtmlFormattedUrl { get; set; }

		public string HtmlSnippet { get; set; }

		public string HtmlTitle { get; set; }

		public string Kind { get; set; }

		public string Link { get; set; }

		public string Mime { get; set; }

		public IDictionary<string, object> Pagemap { get; set; }

		public string Snippet { get; set; }

		public string Title { get; set; }

		public string ETag { get; set; }

		public string ImageSrc { get; set; }

		public int ImageWidth { get; set; }

		public int ImageHeight { get; set; }
	}
}