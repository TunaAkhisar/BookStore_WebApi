using AutoMapper;

namespace WebApi;

public class GetGenresQuery
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper ;
    public GetGenresQuery(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GenresViewModel> GetGenreQueryHandle(){

        var genres = _context.Genres.Where(
            x => x.isActive 
        ).OrderBy(x => x.Id).ToList();

        List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);

        return returnObj;

    }
}

public class GenresViewModel{
    public int GenreId { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
}