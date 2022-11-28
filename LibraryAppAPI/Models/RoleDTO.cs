namespace LibraryApp.Models;

public class RoleDTO
{
    public Guid Id { get; set; }
    public string Name { get; set;}
}

public class AddRoleDTO
{
    public string Name { get; set;}
}