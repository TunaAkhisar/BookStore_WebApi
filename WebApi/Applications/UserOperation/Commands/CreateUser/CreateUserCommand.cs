using AutoMapper;

namespace WebApi;

public class CreateUserCommand
{
    public CreateUserViewModel Model { get; set; }
    private readonly IBookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateUserCommand(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void CreateUserHandle()
    {
        var user = _dbContext.Users.SingleOrDefault(
            x => x.Email == Model.EMail
        );

        // if(user != null)
        if (user is not null)
        {
            throw new InvalidOperationException("Email is already used!");
        }


        user = _mapper.Map<User>(Model);
        
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }


}

public class CreateUserViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string EMail { get; set; }
    public string Password { get; set; }

}
