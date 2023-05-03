using Projekt.Model;
using Projekt.Manager;
using Projekt.IManager;
namespace Projekt.Controller;

public class ResultController
{
    private readonly IResultManager _resultManager = new ResultManager();

    /// <summary>
    /// A paraméterben kapott ID alapján egy sorról keres több információt
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public SearchResult SearchRowDetailsByID(string id) => _resultManager.SearchRowDetailsByID(id);


    /// <summary>
    /// Könyv adatokra keres
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<List<SearchResult>> Search(SearchModel parameters) 
        => await _resultManager.Search(parameters);



    /// <summary>
    /// Elküldi az összegyűjtött adatokat
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public Task SendResult(SearchResult result) => _resultManager.SendResult(result);
}

