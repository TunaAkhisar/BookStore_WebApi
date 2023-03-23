using AutoMapper;

namespace WebApi;

public class CreateAuthorCommand
{
    public CreateAuthorViewModel Model {get;set;}
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void CreateAuthorCommandHandle(){
        var author = _context.Authors.SingleOrDefault(
            x => x.Name == Model.Name
        );

        if(author is not null){
            throw new InvalidOperationException("Author is already added.");
        }

        author = _mapper.Map<Author>(Model);

        _context.Authors.Add(author);
        _context.SaveChanges();
    }
}

public class CreateAuthorViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
}