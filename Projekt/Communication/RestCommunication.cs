using Projekt.Exception;
using RestSharp;
using System.Net;
namespace Projekt.Communication;

public static class RestCommunication
{

    /// <summary>
    /// Rest API kacsolatot létesít
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="methodName">HTTP metódus</param>
    /// <param name="parameters">Paraméter kulcs-érték párok</param>
    /// <returns></returns>
    /// <exception cref="SearchException"></exception>
    public static RestResponse RestApiCommunication(Uri uri, Method methodName, Dictionary<string, string> parameters = null)
    {
        RestResponse requestResult;
        var _client = new RestClient();

        var request = new RestRequest(uri) { Method = methodName };

        if (parameters != null)
            parameters.ToList().ForEach(param => request.AddParameter(param.Key, param.Value));


        requestResult = _client.Execute(request);

        if (requestResult.StatusCode != HttpStatusCode.OK)
        {
            throw new SearchException($"Hiba az API kommunikációban. Státuszkód: {requestResult.StatusCode}; hiba: {requestResult.ErrorMessage}");
        }

        return requestResult;
    }
}
