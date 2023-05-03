using Projekt.Communication;
using Projekt.Exception;
using Projekt.IManager;
using Projekt.Model;
using System.Configuration;
using System.Text;

namespace Projekt.Manager;

public class ResultManager : IResultManager
{
    readonly GoogleCommunication _apiManager = new GoogleCommunication();
    readonly string _kafkaUrl = ConfigurationManager.AppSettings["KafkaUrl"];
    public List<SearchResult> searchResults = new List<SearchResult>();

    /// <summary>
    /// Keresést hajt végre a keresési paraméterek alapján, az adatbázisban és Google API-ban is
    /// </summary>
    /// <returns></returns>
    public async Task<List<SearchResult>> Search(SearchModel parameters)
    {
        searchResults = new List<SearchResult>();
        searchResults.AddRange(GoogleSearch(parameters));
        return searchResults;
    }



    /// <summary>
    /// Keresést hajt végre a keresési paraméterek alapján, a Google API-ban
    /// </summary>
    /// <returns></returns>
    public List<SearchResult> GoogleSearch(SearchModel parameters)
    {
        var results = new List<SearchResult>();

        StringBuilder googleParams = new StringBuilder(70);
        if (parameters.Title != "")
        {
            googleParams.Append("+intitle:");
            googleParams.Append(parameters.Title);
        }
        if (parameters.ISBN != "")
        {
            googleParams.Append("+isbn:");
            googleParams.Append(parameters.ISBN);
        }
        if (parameters.Author != "")
        {
            googleParams.Append("+inauthor:");
            googleParams.Append(parameters.Author);
        }

        GoogleApiSearchResult googleResult = _apiManager.GoogleResultByParameters(googleParams.ToString());


        if (googleResult.totalItems == null || googleResult.totalItems == 0)
        {
            return results;
        }
        foreach (var item in googleResult.items)
        {
            byte[] photo = _apiManager.GoogleImageByID(item.id);

            results.Add(new SearchResult(item, photo));
        }

        return results;
    }

    /// <summary>
    /// A paraméterben kapott ID alapján egy sorról keres több információt
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public SearchResult SearchRowDetailsByID(string id)
    {
        SearchResult result = new SearchResult();
        try
        {
            GoogleApiSearchResult googleResult = _apiManager.GoogleResultByID(id);

            if (googleResult != null) result = new SearchResult(googleResult);
        }
        catch (ArgumentException ex)
        {
            throw new SearchException(ex.Message);
        }
        return result;
    }


    /// <summary>
    /// Elküldi az összegyűjtött adatokat Kafka topic-ra
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public Task SendResult(SearchResult result)
    {
        KafkaCommunication _kafkaCommunication = new KafkaCommunication(_kafkaUrl, "product-topic");
        return _kafkaCommunication.KafkaProducer(result);
    }
}
