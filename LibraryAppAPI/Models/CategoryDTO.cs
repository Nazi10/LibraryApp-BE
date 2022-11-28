using System.Text.Json.Serialization;

namespace LibraryApp.Models;

public class CategoryDTO
{
    public Guid CategoryId { get; set; }
}

public class AddCategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        [JsonIgnore]
        public string? CreatedBy { get; set; }
    }
