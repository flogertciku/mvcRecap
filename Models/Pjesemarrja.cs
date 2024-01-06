#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using mvcRecap.Models;
namespace mvcRecap.Models;
public class Pjesemarrja
{
    [Key]
    public int PjesemarrjaId { get; set; }
    public int? UserId { get; set; }
    public int? WeddingId { get; set; }  
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public User Dasmori {get;set;}
    public Wedding Dasma {get;set;}
}
                
