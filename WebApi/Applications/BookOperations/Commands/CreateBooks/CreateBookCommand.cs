using AutoMapper;

namespace WebApi;

public class CreateBookCommand
{
    public CreateBookViewModel Model {get;set;}
    private readonly IBookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateBookCommand(IBookStoreDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void AddHandle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
        
        // if(book != null)
        if(book is not null){
            throw new InvalidOperationException("Wong");
        }
        

        book = _mapper.Map<Book>(Model);

        _dbContext.Books.Add(book);
        
        _dbContext.SaveChanges();
    } 


}

    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
    }
