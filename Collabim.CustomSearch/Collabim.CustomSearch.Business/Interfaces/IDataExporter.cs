namespace Collabim.CustomSearch.Business.Interfaces
{
   public interface IDataExporter
	{
		string Export<T>(IEnumerable<T> data) where T : class, new();
	}
}
