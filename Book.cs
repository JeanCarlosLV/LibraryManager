using LibraryManager.Models;
using System.Text.Json.Serialization;

namespace LibraryManager;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public double Price { get; set; }

    public int InStock { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Genre BookGenre { get; set; }
}
