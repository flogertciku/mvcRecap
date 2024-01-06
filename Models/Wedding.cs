#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using mvcRecap.Models;
namespace mvcRecap.Models;
public class Wedding
{
    [Key]
    public int WeddingId { get; set; }
    public int? UserId {get;set;}
    public string WedderOne { get; set; }
    public string WedderTwo { get; set; }  
    public DateTime Date { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Pjesemarrja>? teFtuarit {get;set;}
    public User? Creator {get;set;}
}
                
