namespace Projekt.Model;

/// <summary>
/// ResultControl oldalon megjelenített találatokat reprezentálja
/// </summary>
public class SearchResult
{
    public SearchResult() { } 

    public SearchResult(string id, string title, List<string> author,  string publicationYear, string publisher, string height,
        string width, string iSBN10, string iSBN13, string pageCount)
    {
        ID = id;
        Title = title;
        Authors = author;
        Publisher = publisher;
        PublicationYear = publicationYear;
        Height = height;
        Width = width;
        ISBN10 = iSBN10;
        ISBN13 = iSBN13;
        PageCount = pageCount;
    }

    
    public SearchResult(GoogleApiSearchResult.Item item, byte[] photo = null) {

        ID = item.id;
        Title = item.volumeInfo.title;
        Authors = item.volumeInfo.authors;
        Publisher = item.volumeInfo.publisher;
        PublicationYear = item.volumeInfo.publishedDate?.ToString();
        Height = item.volumeInfo.dimensions?.height;
        Width = item.volumeInfo.dimensions?.width;
        ISBN10 = item.volumeInfo.industryIdentifiers?.FirstOrDefault(i => i.type == "ISBN_10")?.identifier;
        ISBN13 = item.volumeInfo.industryIdentifiers?.FirstOrDefault(i => i.type == "ISBN_13")?.identifier;
        PageCount = item.volumeInfo.pageCount.ToString();
        Photo = photo;
    }     
    
    public SearchResult(GoogleApiSearchResult result, byte[] photo = null) {

        ID = result.id;
        Title = result.volumeInfo.title;
        Authors = result.volumeInfo.authors;
        Publisher = result.volumeInfo.publisher;
        PublicationYear = result.volumeInfo.publishedDate?.ToString();
        Height = result.volumeInfo.dimensions?.height;
        Width = result.volumeInfo.dimensions?.width;
        ISBN10 = result.volumeInfo.industryIdentifiers?.FirstOrDefault(i => i.type == "ISBN_10")?.identifier;
        ISBN13 = result.volumeInfo.industryIdentifiers?.FirstOrDefault(i => i.type == "ISBN_13")?.identifier;
        PageCount = result.volumeInfo.pageCount.ToString();
        Photo = photo;
    }    



    public string ID { get; set; }
    public string Title { get; set; }
    public List<string> Authors { get; set; }
    public string Publisher { get; set; }
    public string PublicationYear { get; set; }
    public string Height { get; set; }
    public string Width { get; set; }
    public string ISBN10 { get; set; }
    public string ISBN13 { get; set; }
    public string PageCount { get; set; }
    public bool Database { get; set; } = false;
    public byte[] Photo { get; set; }
    public string PhotoID { get; set; }
}
