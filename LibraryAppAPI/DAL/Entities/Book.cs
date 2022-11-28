using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryApp.DAL.Entitites;

namespace LibraryApp.DAL.Entities;

public class Book : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public string Photo { get; set; }
    public  Guid AuthorId { get; set; }
    [ForeignKey(("AuthorId"))]
    public User Author { get; set; }
    public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
}