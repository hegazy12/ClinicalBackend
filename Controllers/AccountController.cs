using Microsoft.AspNetCore.Mvc;
using ElearingEnglis.services.Rgistration.DTO;
using ElearingEnglis.services.Lgoin.DTO;
using ElearingEnglis.services.Rgistration;
using ElearingEnglis.services.Lgoin;

namespace ElearingEnglis.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class AccountController : ControllerBase
{
    private readonly IRgistration _registrationService;
    private readonly ILogin _loginService;

    public AccountController(IRgistration registrationService, ILogin loginService)
    {
        _registrationService = registrationService;
        _loginService = loginService;
    }

   [HttpPost]
   public async Task<IActionResult> Register(DTORgistration user)
   {
        var result = await _registrationService.createNewUser(user);
        
        if (!result.Succeeded)
        {
            return Ok(new { Message = "User registration failed", Errors = result.Errors });
        }
       return Ok(new { Message = "User registered successfully", User = user });
   }

   [HttpPost]
    public async Task<IActionResult> Login(LoginDTO login)
    {
          var result = await _loginService.LoginUser(login);
          
          if (!result.Succeeded)
          {
                return Ok(new { login=0, Message = "Login failed", Errors = result.Errors });
          }
         return Ok(new {login=1, Message = "Login successful", Token = result.Token });
    }
}
