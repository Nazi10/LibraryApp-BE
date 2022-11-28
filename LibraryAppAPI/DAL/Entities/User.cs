using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryApp.DAL.Entitites;

namespace LibraryApp.DAL.Entities;

public class User : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Bio { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }
    public string Email { get; set; }
    [ForeignKey(("RoleId"))]
    public Role Role { get; set; }
    public ICollection<Book> Books { get; set; }
}