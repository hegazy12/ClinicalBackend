using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ElearingEnglis.DataCon.Module;

public class Patient : BaseModule
{
    [Required]   
    public string FristName {get ; set;} = String.Empty;
    
    [Required] 
    public string LastName { get; set;} = String.Empty;
    
    [Required] 
    public string Phone {get; set;}= String.Empty;
}
