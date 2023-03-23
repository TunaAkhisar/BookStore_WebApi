namespace WebApi;

public static class Books
{
    public static void AddBooks(this BookStoreDbContext context)
    {
        context.Books.AddRange(
             new Book
             {
                 Id = 1,
                 Title = "Lean Startup",
                 GenreId = 10,
                 PageCount = 200,
                 PublishDate = new DateTime(2001, 09, 11)
             },
             new Book
             {
                 Id = 2,
                 Title = "Iron Man",
                 GenreId = 20,
                 PageCount = 150,
                 PublishDate = new DateTime(1999, 12, 31)
             },
              new Book
              {
                  Id = 3,
                  Title = "Dune",
                  GenreId = 30,
                  PageCount = 500,
                  PublishDate = new DateTime(2002, 03, 11)
              }
        );


    }
}