using LibraryApp.Models;

namespace LibraryApp.Services.Interfaces;

public interface IRoleService
{
    public Task Add(AddRoleDTO role); 
    
    public IEnumerable<RoleDTO> GetAll();
    
    public RoleDTO? GetById(Guid id);
    
    public void Update(AddRoleDTO role);
    
    public void Delete(Guid id);
}