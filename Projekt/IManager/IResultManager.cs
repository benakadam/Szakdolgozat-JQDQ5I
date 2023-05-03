using Projekt.Model;
namespace Projekt.IManager;

public interface IResultManager
{
    public SearchResult SearchRowDetailsByID(string id);
    public Task<List<SearchResult>> Search(SearchModel parameters);
    public Task SendResult(SearchResult result);

}
