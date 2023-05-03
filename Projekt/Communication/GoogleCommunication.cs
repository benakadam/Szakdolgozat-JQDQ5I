using Newtonsoft.Json;
using Projekt.Model;
using System.Configuration;
namespace Projekt.Communication;

public class GoogleCommunication
{
    private readonly string baseUrl;
    private readonly string imageBaseUrl;


    public GoogleCommunication()
    {
        baseUrl = ConfigurationManager.AppSettings["Google.Api.BaseUrl"];
        imageBaseUrl = ConfigurationManager.AppSettings["Google.Api.ImageBaseUrl"];
    }

    /// <summary>
    /// Keres a Google Books API-ban paraméter alapján
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public GoogleApiSearchResult GoogleResultByParameters(string parameter)
    {
        var uri = new Uri(baseUrl + "volumes/?q=" + parameter);


        var response = RestCommunication.RestApiCommunication(uri, RestSharp.Method.Get);

        var results = JsonConvert.DeserializeObject<GoogleApiSearchResult>(response.Content);

        return results;
    }


    /// <summary>
    /// Keres a Google Books API-ban könyv ID alapján
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public GoogleApiSearchResult GoogleResultByID(string id)
    {
        var uri = new Uri(baseUrl + "volumes/" + id);

        var response = RestCommunication.RestApiCommunication(uri, RestSharp.Method.Get);

        var results = JsonConvert.DeserializeObject<GoogleApiSearchResult>(response.Content);

        return results;
    }


    /// <summary>
    /// Képet keres a Google Books API-ban könyv ID alapján
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public byte[] GoogleImageByID(string id)
    {
        var uri = new Uri(imageBaseUrl + $"books/content?id={id}&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api");

        var response = RestCommunication.RestApiCommunication(uri, RestSharp.Method.Get);

        return response.RawBytes;
    }
}
