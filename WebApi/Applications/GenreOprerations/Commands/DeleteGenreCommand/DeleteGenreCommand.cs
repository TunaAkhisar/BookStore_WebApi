namespace WebApi;

public class DeleteGenreCommand
{
    public int GenreId { get; set; }
    private readonly IBookStoreDbContext _context;
    public DeleteGenreCommand(IBookStoreDbContext context)
    {
        _context = context;
    }

    public void DeleteGenreCommandHandle(){
        var genre = _context.Genres.SingleOrDefault(
            x => x.Id == GenreId
        );

        if(genre is null){
            throw new InvalidOperationException("ID could not find!");
        }

        _context.Genres.Remove(genre);

        _context.SaveChanges();
    }


}