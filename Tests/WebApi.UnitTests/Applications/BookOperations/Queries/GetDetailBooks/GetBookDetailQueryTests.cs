using AutoMapper;
using FluentAssertions;
using Xunit;


namespace WebApi;

public class GetBookDetailQueryTests : IClassFixture<CommonTestFixture>
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetBookDetailQueryTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void When_Non_Valid_Id_Is_Given_Book_Should_Be_Return(){
        GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);

        FluentActions.Invoking(
            () => query.GetGenreDetailQueryHandle()
        ).Should()
        .Throw<InvalidOperationException>()
        .And.Message
        .Should().Be("ID's not correct!");
    }

}