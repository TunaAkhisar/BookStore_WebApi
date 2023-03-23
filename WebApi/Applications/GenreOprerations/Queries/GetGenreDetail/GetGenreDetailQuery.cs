using AutoMapper;

namespace WebApi;

public class GetGenreDetailQuery
{
    public GenreDetailViewModel Model {get;set;}
    public int GenreId {get;set;}
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper ;
    public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GenreDetailViewModel GetGenreDetailQueryHandle(){

        var genres = _context.Genres.SingleOrDefault(
            x => x.isActive && x.Id == GenreId
        );

        if(genres == null){
            throw new InvalidOperationException("Hatali");
        }

        GenreDetailViewModel returnObj = _mapper.Map<GenreDetailViewModel>(genres);

        return returnObj;

    }
}

public class GenreDetailViewModel{
    public int Id { get; set; }
    public string Name { get; set; }
}