using LibraryApp.Models;

namespace LibraryApp.Services.Interfaces;

public interface IUserService
{
    public Task Add(AddUserDTO userDto); 
    
    public IEnumerable<UserDTO> GetAll();
    
    public AddUserDTO? GetById(Guid id);
    public UserDTO? GetByEmail(string email);
    
    public IEnumerable<AuthorDTO> GetAuthors();

    public void UpdateUser(UpdateUserDTO user);

    public void Delete(Guid id);
}