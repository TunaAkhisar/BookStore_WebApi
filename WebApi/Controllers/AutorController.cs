using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace WebApi;

// [Authorize]
[ApiController]
[Route("[controller]s")]

public class AuthorController : ControllerBase
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public AuthorController(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        GetAuthorsQuery getAuthorsQuery = new GetAuthorsQuery(_context,_mapper);
        return Ok(getAuthorsQuery.GetAuthorsQueryHandle());
    }

    [HttpGet("{id}")]
    public IActionResult GetAuthorsById(int id){
        GetAuthorDetailQuery getAuthorDetailQuery = new GetAuthorDetailQuery(_context,_mapper);

        GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
        validator.ValidateAndThrow(getAuthorDetailQuery);

        getAuthorDetailQuery.AuthorId = id;

        return Ok(getAuthorDetailQuery.GetAuthorDetailQueryHandle());
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] CreateAuthorViewModel newAuthor)
    {
        CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
        command.Model = newAuthor;

        CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
        validator.ValidateAndThrow(command);

        command.CreateAuthorCommandHandle();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id,[FromBody] UpdateAuthorViewModel updateAuthor){
        UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);

        command.AuthorId = id;
        command.Model = updateAuthor;

        UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
        validator.ValidateAndThrow(command);

        command.UpdateAuthorCommandHandle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id){
        DeleteAuthorCommand command = new DeleteAuthorCommand(_context);

        command.AuthorId = id;

        DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
        validator.ValidateAndThrow(command);

        command.DeleteAuthorCommandHandle();

        return Ok();
    }

}