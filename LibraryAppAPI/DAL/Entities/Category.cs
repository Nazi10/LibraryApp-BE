using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryApp.DAL.Entities;

namespace LibraryApp.DAL.Entitites;

public class Category : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Priority { get; set; }
   
    public ICollection<BookCategory> BookCategories { get; set; }
}