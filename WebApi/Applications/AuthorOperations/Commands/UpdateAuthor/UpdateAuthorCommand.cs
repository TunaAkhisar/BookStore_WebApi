using AutoMapper;

namespace WebApi;


public class UpdateAuthorCommand
{
    public int AuthorId {get;set;}
    public UpdateAuthorViewModel Model {get;set;} 
    public readonly IBookStoreDbContext _context;
    public readonly IMapper _mapper;
    public UpdateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void UpdateAuthorCommandHandle()
    {
        var author = _context.Authors.SingleOrDefault(
            x => x.Id == AuthorId
        );

        if(author is null){
            throw new InvalidOperationException("ID is not correct.");
        }

        _mapper.Map<UpdateAuthorViewModel>(author);

        _context.SaveChanges();
    }

}

public class UpdateAuthorViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
}