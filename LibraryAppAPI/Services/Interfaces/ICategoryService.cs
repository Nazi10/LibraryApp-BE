using LibraryApp.Models;

namespace LibraryApp.Services.Interfaces;

public interface ICategoryService
{
    public Task Add(AddCategoryDTO categoryDto);

    public IEnumerable<AddCategoryDTO> GetAll();
    
    public CategoryDTO? GetById(Guid id);
    
    public void Update(AddCategoryDTO entity);
    
    public void Delete(Guid id);
}