using AutoMapper;
using Collabim.CustomSearch.Business.Interfaces;
using Collabim.CustomSearch.Business.Models;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;

namespace Collabim.CustomSearch.Business
{
	public class SearchService : ISearchService
	{
		private CustomsearchService _service;
		private readonly string _apiKey;
		private readonly string _searchEngineId;
		public IMapper Mapper { get; set; }

		public SearchService(string apiKey, string searchEngineId)
		{
			_apiKey = apiKey;
			_searchEngineId = searchEngineId;
			_service = new CustomsearchService(new BaseClientService.Initializer { ApiKey = _apiKey });
		}

		public async Task<IEnumerable<SearchItem>> SearchAsync(string searchText)
		{
			var result = new List<SearchItem>();

			if (!string.IsNullOrWhiteSpace(searchText))
			{
				var listRequest = _service.Cse.List();
				listRequest.Cx = _searchEngineId;
				listRequest.Q = searchText;
				listRequest.Start = 0;

				var searchedItems = await listRequest.ExecuteAsync();

				if (searchedItems != null)
				{
					foreach (var item in searchedItems.Items)
					{
						result.Add(MapSearchItem(item));
					}
				}
			}

			return result;
		}

		private static SearchItem MapSearchItem(Result? item)
		{
			//SearchItem searchItem = new SearchItem();
			//Mapper.Map(item, searchItem);

			SearchItem searchItem = new SearchItem
			{
				Link = item.Link,
				HtmlTitle = item.HtmlTitle,
				DisplayLink = item.DisplayLink,
				HtmlFormattedUrl = item.HtmlFormattedUrl,
				HtmlSnippet = item.HtmlSnippet,
				CacheId = item.CacheId,
				ETag = item.ETag,
				FileFormat = item.FileFormat,
				FormattedUrl = item.FormattedUrl,
				Kind = item.Kind,
				Mime = item.Mime,
				Pagemap = item.Pagemap == null ? new Dictionary<string, object>() : item.Pagemap,
				Snippet = item.Snippet,
				Title = item.Title,
			};

			if (item.Pagemap != null && item.Pagemap.Count > 0 && item.Pagemap.ContainsKey("cse_thumbnail"))
			{
				object imgData;

				if (item.Pagemap.TryGetValue("cse_thumbnail", out imgData) && imgData != null)
				{
					var objArray = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SearchItemImage>>(imgData.ToString());
					searchItem.ImageSrc = objArray[0].Src;
					searchItem.ImageWidth = objArray[0].Width;
					searchItem.ImageHeight = objArray[0].Height;
				}
			}

			return searchItem;
		}
	}
}