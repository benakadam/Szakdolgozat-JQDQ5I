namespace Projekt.Model;


/// <summary>
/// Kafka kapcsolattal küldendő adatokat reprezentál
/// </summary>
public class ResultMessage : SearchResult
{
    public string StationID { get; set; }
    public List<string> ImagePaths { get; set; }
    public string Weight { get; set; }

    public ResultMessage(SearchResult result, string recorderID, List<string> imagePaths, string weight)
        : base(result.ID, result.Title, result.Authors, result.PublicationYear, result.Publisher, result.Height,
            result.Width, result.ISBN10, result.ISBN13, result.PageCount)
    {
        StationID = recorderID;
        ImagePaths = imagePaths;
        Weight = weight;
    }
}
