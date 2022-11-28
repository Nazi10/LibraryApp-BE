namespace LibraryApp.DAL.Entitites;

public class BaseEntity
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? CreatedBy { get; set; }
}
