using AutoMapper;

namespace WebApi;

public class UpdateBookCommand
{
    private readonly IBookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int BookId {get;set;}
    public UpdateBookViewModel Model {get;set;}
    public UpdateBookCommand(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void UpdateHandle(){

        var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

        if (book is null)
        {
            throw new InvalidOperationException("Bulunamadi");
        }

        _mapper.Map(Model,book);

        _dbContext.SaveChanges();
    }

}

	public class UpdateBookViewModel
	{
		public string Title { get; set; }
		public int AuthorId { get; set; }
		public int GenreId { get; set; }
		public int PageCount { get; set; }
		public DateTime PublishDate { get; set; }
	}