using AutoMapper;
using Xunit;
using FluentAssertions;

namespace WebApi;

public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateBookCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationExeption_SholdBeReturn()
    {
        // arrage / hazırlık
        var book = new Book()
        {
            Title = "henAlreadyExistBookTitleIsGiven_InvalidOperationExeption_SholdBeReturn",
            PageCount = 100,
            PublishDate = new DateTime(1990, 09, 10),
            GenreId = 1
        };

        _context.Books.Add(book);
        _context.SaveChanges();

        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        command.Model = new CreateBookViewModel()
        {
            Title = book.Title
        };


        // act / çalıştırma
        // assert / dogrulama

        FluentActions
        .Invoking(() => command.AddHandle())
        .Should()
        .Throw<InvalidOperationException>()
        .And
        .Message
        .Should()
        .Be("Wrong");

    }


    [Fact]
    public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
    {
        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        CreateBookViewModel model = new CreateBookViewModel();

        command.Model = model;

        FluentActions.Invoking(
              () => command.AddHandle()
        ).Invoke();

        var book = _context.Books.SingleOrDefault(
              book => book.Title == model.Title
        );

        book.Should().NotBeNull();
        book.Title.Should().Be(model.Title);
        book.PageCount.Should().Be(model.PageCount);
        book.PublishDate.Should().Be(model.PublishDate);
        book.GenreId.Should().Be(model.GenreId);
    }


}
