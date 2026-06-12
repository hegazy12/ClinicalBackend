using ElearingEnglis.services.Lgoin.DTO;
namespace ElearingEnglis.services.Lgoin;

public interface ILogin
{
        public string makeToken(ILogin user);
        public bool verifyToken(string token);
        public Task<LoginResult>  LoginUser(LoginDTO login);
}
