using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;

namespace Collabim.CustomSearch.Business
{
	public interface ISearchService
	{
		Task<IList<Result>> SearchAsync(string searchText);
	}

	public class SearchService : ISearchService
	{
		private CustomsearchService _service;
		private readonly string _apiKey = "AIzaSyD8dk5H8AOkgUuKmHjdLnWKT0QLWlFR3bM";
		private readonly string _searchEngineId = "51b85367cfdf54768";

		public SearchService()
		{
			_service = new CustomsearchService(new BaseClientService.Initializer { ApiKey = _apiKey });
		}

		public async Task<IList<Result>> SearchAsync(string searchText)
		{
			IList<Result> result = null;

			if (!string.IsNullOrWhiteSpace(searchText))
			{
				CseResource.ListRequest listRequest = _service.Cse.List();
				listRequest.Cx = _searchEngineId;
				listRequest.Q = searchText;

				listRequest.Start = 0;
				var searchedItems = await listRequest.ExecuteAsync();
				return searchedItems.Items;
			}

			return result;
		}
	}
}