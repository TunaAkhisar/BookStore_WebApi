using AutoMapper;
using FluentAssertions;
using Xunit;

namespace WebApi;

public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
{
	private readonly BookStoreDbContext _context;

	public DeleteBookCommandTests(CommonTestFixture testFixture)
	{
		_context = testFixture.Context;
	}
	[Fact]
	public void WhenBookIsNotFound_InvalidOperationException_ShouldBeReturn()
	{
		DeleteBookCommand command = new DeleteBookCommand(_context);
		
		command.BookId = 12;
		
		FluentActions.Invoking(() => command.DeleteHandle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book doesn't exist!");
	}
	
	[Fact]
	public void WhenValidInputAreGiven_Book_ShouldBeDeleted()
	{
		DeleteBookCommand command = new DeleteBookCommand(_context);
		
		command.BookId = 1;
		
		FluentActions.Invoking(() => command.DeleteHandle()).Invoke();
	}
}