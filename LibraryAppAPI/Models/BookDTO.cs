using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryApp.Models;

public class BookDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Photo { get; set; }
    public DateTime CreatedAt { get; set; }
    [JsonIgnore] public string? CreatedBy { get; set; }
    public string AuthorName { get; set; }
    public ICollection<string> BookCategories { get; set; }
}

public class AddBookDTO
{
    public Guid Id { get; set; }
    public Guid? AuthorId { get; set; }
    public List<Guid> CategoriesIds { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [NotMapped] public IFormFile? PhotoFile { get; set; }
    [JsonIgnore] public string? CreatedBy { get; set; }
}