namespace LibraryManager.Communication.Requests;

using LibraryManager.Models;
using System.Text.Json.Serialization;
public class RequestUpdateBookJson
{
    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public double Price { get; set; }

    public int InStock { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Genre BookGenre { get; set; }
}
