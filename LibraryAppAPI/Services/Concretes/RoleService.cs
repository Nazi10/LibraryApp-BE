using AutoMapper;
using LibraryApp.DAL.Entities;
using LibraryApp.Models;
using LibraryApp.Repositories.Interfaces;
using LibraryApp.Services.Interfaces;

namespace LibraryApp.Services.Concretes;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public RoleService(IRoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task Add(AddRoleDTO roleDto)
    {
        var role = _mapper.Map<Role>(roleDto);
        _roleRepository.Create(role);
        await _roleRepository.SaveAsync();
    }

    public IEnumerable<RoleDTO> GetAll()
    {
        IEnumerable<Role> roles = _roleRepository.GetAll();
        return _mapper.Map<IEnumerable<RoleDTO>>(roles);
    }

    public RoleDTO? GetById(Guid id)
    {
        var role = _roleRepository.GetById(id);
        return _mapper.Map<RoleDTO>(role);
    }

    public void Update(AddRoleDTO roleDto)
    {
        var role = _mapper.Map<Role>(roleDto);
        _roleRepository.Update(role);
        _roleRepository.Save();
    }

    public void Delete(Guid id)
    {
        var role = _roleRepository.GetById(id);
        _roleRepository.Delete(role);
        _roleRepository.Save();
    }
}