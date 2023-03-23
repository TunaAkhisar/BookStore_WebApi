using AutoMapper;

namespace WebApi;

public class CreateGenreCommand{
    public CreateGenreViewModel Model {get;set;}
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateGenreCommand(IBookStoreDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void CreateGenreCommandHandle(){
        var genres = _context.Genres.SingleOrDefault(
            x => x.Name == Model.Name
        );

        if(genres is not null){
            throw new InvalidOperationException("Zaten var hocam");
        }

        genres = _mapper.Map<Genre>(Model);

        _context.Genres.Add(genres);
        _context.SaveChanges();


    }

}

public class CreateGenreViewModel{
    public string Name { get; set; }
    public bool IsActive { get; set; }
}