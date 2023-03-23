using AutoMapper;

namespace WebApi;

public class UpdateGenreCommand
{
    public int GenreId { get; set; }
    public UpdateGenreViewModel Model {get;set;}
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public UpdateGenreCommand(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void UpdateGenreCommandHandle(){
        var genres = _context.Genres.SingleOrDefault(
            x => x.Id == GenreId
        );

        if(genres is null){
            throw new InvalidOperationException("ID could not found!");
        }

        if(_context.Genres.Any(
            x => x.Name.ToLower() == Model.Name.ToLower() && 
            x.Id != GenreId
        )){
            throw new InvalidOperationException("Genre name or ID is already existing.");
        }

        _mapper.Map<Genre>(Model);
        
        _context.SaveChanges();
    }
}

public class UpdateGenreViewModel{
    public string Name { get; set; }
    public bool isActive { get; set; } = true;
}