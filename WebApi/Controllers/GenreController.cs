using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

// [Authorize]
[ApiController]
[Route("[controller]s")]

public class GenreController : ControllerBase
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GenreController(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult GetGenres()
    {
        GetGenresQuery query = new GetGenresQuery(_context,_mapper);
        var obj = query.GetGenreQueryHandle();
        return Ok(obj);
    }

    [HttpGet("id")]
    public ActionResult GetGenresDetail(int id)
    {
        GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
        query.GenreId = id;

        GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
        validator.ValidateAndThrow(query);

        var obj = query.GetGenreDetailQueryHandle();
        return Ok(obj);
    }

    [HttpPost]
    public IActionResult AddGenre([FromBody] CreateGenreViewModel newGenre)
    {
        CreateGenreCommand command = new CreateGenreCommand(_context,_mapper);
        command.Model = newGenre;

        CreateGenreCommandValidator validations = new CreateGenreCommandValidator();
        validations.ValidateAndThrow(command);

        command.CreateGenreCommandHandle();
        return Ok();
    }

    [HttpPut("id")]
    public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreViewModel updateGenre)
    {
        UpdateGenreCommand command = new UpdateGenreCommand(_context,_mapper);
        command.GenreId = id;

        UpdateGenreCommandValidator validations = new UpdateGenreCommandValidator();
        validations.ValidateAndThrow(command);

        command.UpdateGenreCommandHandle();
        return Ok();
    }

    [HttpDelete("id")]
    public IActionResult DeleteGenre(int id,[FromBody] DeleteGenreCommand deleteGenre)
    {
        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        command.GenreId = id;

        DeleteGenreCommandValidator validations = new DeleteGenreCommandValidator();
        validations.ValidateAndThrow(command);

        command.DeleteGenreCommandHandle();

        return Ok();
    }






}

