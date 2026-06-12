using ElearingEnglis.services.Lgoin.DTO;
using Microsoft.AspNetCore.Identity;
using ElearingEnglis.services.JWT;
namespace ElearingEnglis.services.Lgoin;
public class Login : ILogin
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IJWTModule _jwtModule;
    private readonly DataCon.DBCon _dbcontext;
    public Login(UserManager<IdentityUser> userManager , IJWTModule jwtModule,DataCon.DBCon dBCon)
    {
        _userManager = userManager;
        _jwtModule = jwtModule;
        _dbcontext = dBCon;
    }
    public string makeToken(ILogin user)
    {
        throw new NotImplementedException();
    }

    public bool verifyToken(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<LoginResult> LoginUser(LoginDTO login)
    {
    
            var user = await _userManager.FindByNameAsync(login.Email);

            if (user == null)
            {
                return new LoginResult { Succeeded = false, Message = "username is not found" };
            }
            
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, login.Password);

            if (!isPasswordValid)
            {
                return new LoginResult { Succeeded = false, Message = "password is incorrect" };
            }
            
            var token = _jwtModule.GenerateToken(Guid.Parse(user.Id),user.UserName, user.Email,_dbcontext);

            return new LoginResult 
            { 
                Succeeded = true, 
                Message = "Login successful",
                Token = token
            };

    }
}
