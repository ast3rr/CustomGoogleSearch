using Collabim.CustomSearch.Business.Models;

namespace Collabim.CustomSearch.Business.Interfaces
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchItem>> SearchAsync(string searchText);
    }
}