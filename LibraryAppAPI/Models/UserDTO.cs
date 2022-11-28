using System.Text.Json.Serialization;
using LibraryApp.DAL.Entities;

namespace LibraryApp.Models;

public class UserDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string RoleName { get; set; }
    [JsonIgnore]
    public string Password { get; set; }

}

public class AddUserDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }

    public string Email { get; set; }
    [JsonIgnore]
    public string? CreatedBy { get; set; }
}

public class AuthorDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }
    public int BookNumber { get; set; }
}

public class UpdateUserDTO{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }

    public string Email { get; set; }

}
