using AutoMapper;
using LibraryWebApp.Dtos;
using LibraryWebApp.Entities;

namespace LibraryWebApp.MyMaps
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<Books, BooksDto>();
            CreateMap<BooksDto, Books>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Personal, PersonalDto>();
            CreateMap<PersonalDto, Personal>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Genres, GenresDto>().ReverseMap();
            CreateMap<Authors, AuthorDto>().ReverseMap();
            CreateMap<BuyBook, BuyBooksDto>().ReverseMap();
        }
    }
}
