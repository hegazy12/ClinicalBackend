using System.ComponentModel.DataAnnotations;

namespace ElearingEnglis.services.Lgoin.DTO;

public class LoginDTO
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }

}

public class LoginResult
{
    public bool Succeeded { get; set; }
    public string Token { get; set; }
    public string Message { get; set; }
    public string Errors { get; set; }
}
