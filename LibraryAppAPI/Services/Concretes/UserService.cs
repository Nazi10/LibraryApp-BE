using AutoMapper;
using LibraryApp.DAL.Entities;
using LibraryApp.Models;
using LibraryApp.Repositories.Interfaces;
using LibraryApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services.Concretes;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task Add(AddUserDTO userDto)
    {
        var existingUser = GetByEmail(userDto.Email);
        if (existingUser != null)
        {
            throw new Exception($"User with email: {userDto.Email} already exists!");
        }
        userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password).ToString();
        _userRepository.Create(_mapper.Map<User>(userDto));
        await _userRepository.SaveAsync();
    }

    public IEnumerable<UserDTO> GetAll()
    {
        IEnumerable<User> users = _userRepository.GetAll()
            .Include(r => r.Role);
        return _mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public AddUserDTO? GetById(Guid id)
    {
        var user = _userRepository.GetById(id);
        return _mapper.Map<AddUserDTO>(user);
    }

    public IEnumerable<AuthorDTO> GetAuthors()
    {
        return _mapper.Map<IEnumerable<AuthorDTO>>(_userRepository.GetAuthors());
    }

    public UserDTO? GetByEmail(string email)
    {
        var user = _userRepository.GetByEmail(email);
        if (user != null)
        {
            var result = _mapper.Map<UserDTO>(user);
            result.Role = user.Role.Name;
            return result;
        }
        return null;
    }

    public void UpdateUser(UpdateUserDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);
        user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        _userRepository.Update(user);
        _userRepository.Save();
    }

    public void Delete(Guid id)
    {
        var user = _userRepository.GetById(id);
        _userRepository.Delete(user);
        _userRepository.Save();
    }
}