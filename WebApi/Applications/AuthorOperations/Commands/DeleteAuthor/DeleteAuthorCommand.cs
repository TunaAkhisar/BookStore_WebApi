namespace WebApi;

public class DeleteAuthorCommand
{
    public int AuthorId {get;set;}
    private IBookStoreDbContext _context;

    public DeleteAuthorCommand(IBookStoreDbContext context)
    {
        _context = context;
    }

    public void DeleteAuthorCommandHandle(){
        var author = _context.Authors.SingleOrDefault(
            x => x.Id == AuthorId
        );
        var authorBooks = _context.Books.SingleOrDefault(
            x => x.AuthorId == AuthorId
        );

		if (author is null)
			throw new InvalidOperationException("ID isn't found.");
			
		if (authorBooks is not null)
			throw new InvalidOperationException(author.Name + " " +  author.Surname + " has a published book. Please delete book first.");

        _context.Authors.Remove(author);
        _context.SaveChanges();	
    }
}