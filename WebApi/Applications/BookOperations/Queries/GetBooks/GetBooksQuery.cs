using AutoMapper;

namespace WebApi;

public class GetBooksQuery
{
    private readonly IBookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetBooksQuery(IBookStoreDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<BooksViewModel> GetHandle(){
        var bookList = _dbContext.Books.OrderBy(
            x => x.Id
        ).ToList<Book>();

        List<BooksViewModel> booksViewModels = _mapper.Map<List<BooksViewModel>>(bookList);

        return booksViewModels;
    }

}

	public class BooksViewModel
	{
		public string Title { get; set; }
		public int PageCount { get; set; }
		public string PublishDate { get; set; }
		public string Genre { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }
	}
