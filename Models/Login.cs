#pragma warning disable CS8618
// using statements and namespace go here
using System.ComponentModel.DataAnnotations;
namespace mvcRecap.Models;
public class Login
{
    // No other fields!
    [Required]    
    public string LoginUsername { get; set; }    
    [Required]    
    public string LoginPassword { get; set; } 
}
