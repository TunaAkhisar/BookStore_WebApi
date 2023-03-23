using AutoMapper;

namespace WebApi;

public class GetBookDetailQuery
{
    private readonly IBookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int BookId {get;set;}
    public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public BookDetailViewModel GetDetailHandle(){
        var book = _dbContext.Books.Where(
            x => x.Id == BookId
        ).SingleOrDefault();

        if(book is null){
            throw new InvalidOperationException("ID's not correct!");
        }

        // BookDetailViewModel bookDetailViewModel = new BookDetailViewModel();
        BookDetailViewModel bookDetailViewModel = _mapper.Map<BookDetailViewModel>(book);

        
        return bookDetailViewModel;
    }


}

	public class BookDetailViewModel
	{
		public string Title { get; set; }
		public string Genre { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }
		public int PageCount { get; set; }
		public string PublishDate { get; set; }
	}