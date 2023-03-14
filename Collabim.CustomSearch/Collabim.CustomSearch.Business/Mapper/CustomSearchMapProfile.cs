using AutoMapper;
using Collabim.CustomSearch.Business.Models;
using Google.Apis.Customsearch.v1.Data;

namespace Collabim.CustomSearch.Business.Mapper
{
	public class CustomSearchMapProfile : Profile
	{
		public CustomSearchMapProfile()
		{
			CreateMap<SearchItem, Result>();
		}
	}
}