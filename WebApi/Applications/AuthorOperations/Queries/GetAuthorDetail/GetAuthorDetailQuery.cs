using AutoMapper;

namespace WebApi;


public class GetAuthorDetailQuery
{
    public int AuthorId { get; set; }
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetAuthorDetailQuery(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public AuthorDetailViewModel GetAuthorDetailQueryHandle(){
        var author = _context.Authors.SingleOrDefault(
            x => x.Id == AuthorId
        );

        if(author is null){
            throw new InvalidOperationException("Id is not correct");
        }

        AuthorDetailViewModel authorDetailViewModel = _mapper.Map<AuthorDetailViewModel> (author);

        return authorDetailViewModel;
    }

}

public class AuthorDetailViewModel
{
    public string Name { get; set;}
    public string Surname { get; set; }
    public string Birthday { get; set; }
}


