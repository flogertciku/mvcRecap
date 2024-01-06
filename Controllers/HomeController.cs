using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvcRecap.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;


namespace mvcRecap.Controllers;
// Name this anything you want with the word "Attribute" at the end
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        // Check to see if we got back null
        if(userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Auth", "Home", null);
        }
    }
}



public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    [SessionCheck]
    public IActionResult Index()
    {
        ViewBag.userId =HttpContext.Session.GetInt32("UserId");
        ViewBag.dasmat= _context.Weddings.Include(e=>e.teFtuarit).OrderBy(e=>e.Date).ToList();
        return View();
    }
    [HttpGet("Auth")]
    public IActionResult Auth()
    {
        return View();
    }
    [HttpPost("Register")]
    public IActionResult Register(User useriNgaForma)
    {

        if (ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            // Updating our newUser's password to a hashed version         
            useriNgaForma.Password = Hasher.HashPassword(useriNgaForma, useriNgaForma.Password);
            _context.Add(useriNgaForma);
            _context.SaveChanges();

            return RedirectToAction("Auth");
        }
        return View("Auth");

    }

    [HttpPost("Login")]
    public IActionResult Login(Login useriNgaForma)
    {
        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Username == useriNgaForma.LoginUsername);
            if (userInDb == null)
            {
                // Add an error to ModelState and return to View!            
                ModelState.AddModelError("LoginUsername", "Invalid Username");
                return View("Auth");
            }
            PasswordHasher<Login> hasher = new PasswordHasher<Login>();
            // Updating our newUser's password to a hashed version         
            var result = hasher.VerifyHashedPassword(useriNgaForma, userInDb.Password, useriNgaForma.LoginPassword);
            if (result == 0)
            {
                ModelState.AddModelError("LoginPassword", "Invalid Password");
                return View("Auth");

            }
            else
            {

                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Index");
            }


        }
        return View("Auth");

    }

    [HttpGet("LogOut")]
    public IActionResult LogOut()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Auth");
    }
     [HttpGet("CreateWedding")]
    public IActionResult CreateWedding()
    {
        
        return View();
    }

    [HttpPost("AddWedding")]
    public IActionResult AddWedding(Wedding dasmaNgaForma){

        if (ModelState.IsValid)
        {
            dasmaNgaForma.UserId = HttpContext.Session.GetInt32("UserId");
            _context.Add(dasmaNgaForma);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("CreateWedding");

    }
    [HttpGet("ShkoDasem/{dasmaId}")]
    public IActionResult ShkoDasem(int dasmaId){

        Pjesemarrja pjesemarrjaERe = new Pjesemarrja();
        pjesemarrjaERe.WeddingId= dasmaId;
        pjesemarrjaERe.UserId=HttpContext.Session.GetInt32("UserId");
        _context.Add(pjesemarrjaERe);
            _context.SaveChanges();

        return RedirectToAction("Index");
    }
    [HttpGet("MosShkoDasem/{dasmaId}")]
    public IActionResult MosShkoDasem(int dasmaId){

        Pjesemarrja pjesemarrjaERe = _context.Pjesemarrjet.FirstOrDefault(e=>e.WeddingId== dasmaId && e.UserId==HttpContext.Session.GetInt32("UserId"));
        _context.Remove(pjesemarrjaERe);
            _context.SaveChanges();

        return RedirectToAction("Index");
    }
    [HttpGet("DeleteDasem/{dasmaId}")]
    public IActionResult DeleteDasem(int dasmaId){

        Wedding dasma = _context.Weddings.Include(e=>e.teFtuarit).FirstOrDefault(e=>e.WeddingId ==dasmaId);
        if (dasma.UserId== HttpContext.Session.GetInt32("UserId"))
        {
               _context.Remove(dasma);
        _context.SaveChanges();
        }
     

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
