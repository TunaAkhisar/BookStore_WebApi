using AutoMapper;
using static WebApi.CreateBookCommand;

namespace WebApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<Book, BookDetailViewModel>()
        .ForMember(dest => dest.Genre, opt => opt
        .MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        CreateMap<Book,BooksViewModel>()
        .ForMember(dest => dest.Genre, opt => opt
        .MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        CreateMap<CreateBookViewModel,Book>();
        CreateMap<UpdateBookViewModel,Book>();


        CreateMap<Genre,GenresViewModel>();
        CreateMap<Genre,GenreDetailViewModel>();
        CreateMap<CreateGenreViewModel,Genre>();
        CreateMap<UpdateGenreViewModel,Genre>();

        CreateMap<CreateUserViewModel,User>();

        CreateMap<Author,AuthorsViewModel>();
        CreateMap<Author,AuthorDetailViewModel>();
        CreateMap<CreateAuthorViewModel,Author>();
        CreateMap<UpdateAuthorViewModel,Author>();

        


    }

}