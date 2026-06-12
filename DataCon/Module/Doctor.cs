using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ElearingEnglis.DataCon.Module;

public class Doctor :BaseModule
{
    [Key]
    public Guid Id {get; set;}
    public string fristName {get; set;}
    public string lastName {get; set;}
    public string specialization {get; set;}
    public IdentityUser user {get; set;}

}
