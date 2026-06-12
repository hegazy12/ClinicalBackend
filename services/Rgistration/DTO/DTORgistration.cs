
using System.ComponentModel.DataAnnotations;
namespace ElearingEnglis.services.Rgistration.DTO;

public class DTORgistration
{
    [Required]
    [MinLength(4)]
    public string Username { get; set; }
    
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
    
    [Required]  
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
}
