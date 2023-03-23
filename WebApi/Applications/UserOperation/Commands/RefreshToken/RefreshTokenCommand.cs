using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace WebApi;

public class RefreshTokenCommand
{
    public string RefreshToken {get;set;}
    private readonly IBookStoreDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public RefreshTokenCommand(IBookStoreDbContext dbContext,IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public Token RefreshTokenHandle()
    {
        var user = _dbContext.Users.FirstOrDefault(
            x => x.RefreshToken == RefreshToken && 
            x.RefreshTokenExpireDate > DateTime.Now
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
            throw new InvalidOperationException("Valid Degil");
        }
    }


}


