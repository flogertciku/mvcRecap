#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
using mvcRecap.Models;
namespace mvcRecap.Models;
public class User
{        
    [Key]        
    public int UserId { get; set; }
    
    [Required]        
    public string FirstName { get; set; }
    
    [Required]        
    public string LastName { get; set; }         
    [Required]
    [MinLength(5,ErrorMessage ="Username duhet te jete me i gjate se 8 karaktere")]
    [UniqueUsername]
    public string Username { get; set; }        
    
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; }          
    
    public DateTime CreatedAt {get;set;} = DateTime.Now;        
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    
    // This does not need to be moved to the bottom
    // But it helps make it clear what is being mapped and what is not
    [NotMapped]
    // There is also a built-in attribute for comparing two fields we can use!
    [Compare("Password")]
    public string PasswordConfirm { get; set; }

    public List<Wedding>? dasmatEKrijuara {get;set;}
    public List<Pjesemarrja>? dasmatKuMerrPjese {get;set;}
}
