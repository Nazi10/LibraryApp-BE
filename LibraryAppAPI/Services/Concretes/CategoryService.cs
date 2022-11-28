using AutoMapper;
using LibraryApp.DAL.Entitites;
using LibraryApp.Models;
using LibraryApp.Repositories.Interfaces;
using LibraryApp.Services.Interfaces;

namespace LibraryApp.Services.Concretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task Add(AddCategoryDTO categoryDto)
    {
        var author = _mapper.Map<Category>(categoryDto);
        _categoryRepository.Create(author);
        await _categoryRepository.SaveAsync();
    }

    public IEnumerable<AddCategoryDTO> GetAll()
    {
        var categories = _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<AddCategoryDTO>>(categories);
    }

    public CategoryDTO? GetById(Guid id)
    {
        return _mapper.Map<CategoryDTO>(_categoryRepository.GetById(id));
    }

    public void Update(AddCategoryDTO entity)
    {
        _categoryRepository.Update(_mapper.Map<Category>(entity));
        _categoryRepository.Save();
    }
    
    public void Delete(Guid id)
    {
        var category = _categoryRepository.GetById(id);
        _categoryRepository.Delete(category);
        _categoryRepository.Save();
    }
}