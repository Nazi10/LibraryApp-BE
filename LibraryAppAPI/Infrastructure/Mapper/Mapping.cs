using AutoMapper;
using LibraryApp.DAL.Entities;
using LibraryApp.DAL.Entitites;
using LibraryApp.Models;

namespace LibraryApp.Infrastructure.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.AuthorName, opt 
                    =>opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.BookCategories, opt 
                    =>opt.MapFrom(src => src.BookCategories
                        .Select(x => x.Category.Name)))
                .ReverseMap();
            CreateMap<Book, AddBookDTO>().ForMember(x => x.CategoriesIds, opt => opt.Ignore()).ReverseMap();
            CreateMap<Category, AddCategoryDTO>().ReverseMap();
            CreateMap<BookCategory, CategoryDTO>().ReverseMap();
            CreateMap<Role, AddRoleDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.RoleName, opt 
                    =>opt.MapFrom(src => src.Role.Name)).ReverseMap();
            CreateMap<User, AuthorDTO>().ForMember(dest => dest.BookNumber, opt => opt.MapFrom(src => src.Books.Count)).ReverseMap();
            CreateMap<User, AddUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
        }
    }
}
