using AutoMapper;

namespace WebApi;

public class CreateTokenCommand
{
    public CreateTokenViewModel Model {get;set;}
    private readonly IBookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public CreateTokenCommand(IBookStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _configuration = configuration;
    }

    public Token CreateTokenHandle()
    {
        var user = _dbContext.Users.FirstOrDefault(
            x => x.Email == Model.EMail && x.Password == Model.Password
        );

        if(user is not null){
            // Token yarat
            TokenHandler tokenHandler = new TokenHandler(_configuration);
            Token token = tokenHandler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.ExpireDate.AddMinutes(5);

            _dbContext.SaveChanges();
            return token;

        }else{
            throw new InvalidOperationException("Email or password is wrong!");
        }
    }


}


public class CreateTokenViewModel
{
    public string EMail { get; set; }
    public string Password { get; set; }
}


