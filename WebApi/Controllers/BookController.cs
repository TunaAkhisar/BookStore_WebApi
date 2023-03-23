using AutoMapper;
using FluentValidation.Results;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApi;

// [Authorize]
[ApiController]
[Route("[controller]s")]

public class BookController : ControllerBase
{

    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public BookController(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }



    [HttpGet]
    public IActionResult GetBooks()
    {
        GetBooksQuery getBooksQuery = new GetBooksQuery(_context, _mapper);

        var result = getBooksQuery.GetHandle();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        BookDetailViewModel result;
        try
        {
            GetBookDetailQuery getBookDetailQuery = new GetBookDetailQuery(_context, _mapper);
            getBookDetailQuery.BookId = id;
            result = getBookDetailQuery.GetDetailHandle();
        }
        catch (System.Exception exp)
        {
            return BadRequest(exp.Message);
        }

        return Ok(result);

    }

    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookCommand newBook)
    {
        CreateBookCommand createBookCommand = new CreateBookCommand(_context, _mapper);

        createBookCommand.Model = newBook.Model;

        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        ValidationResult result = validator.Validate(createBookCommand);
        validator.ValidateAndThrow(createBookCommand);
        createBookCommand.AddHandle();

        return Ok();

    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookViewModel updateBook)
    {
        UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context, _mapper);

        updateBookCommand.BookId = id;
        updateBookCommand.Model = updateBook;

        UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
        validator.ValidateAndThrow(updateBookCommand);

        updateBookCommand.UpdateHandle();

        return Ok();

    }


    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
        deleteBookCommand.BookId = id;

        DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
        validator.ValidateAndThrow(deleteBookCommand);

        deleteBookCommand.DeleteHandle();

        return Ok();

    }




}