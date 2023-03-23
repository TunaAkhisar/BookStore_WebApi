using AutoMapper;

namespace WebApi;

public class GetAuthorsQuery
{
    private readonly IBookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAuthorsQuery(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<AuthorsViewModel> GetAuthorsQueryHandle()
    {
        var authorList = _dbContext.Authors.OrderBy(
            x => x.Id
        ).ToList();

        List<AuthorsViewModel> viewModels = _mapper.Map<List<AuthorsViewModel>>(authorList);

        return viewModels;
    }
}


public class AuthorsViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
}