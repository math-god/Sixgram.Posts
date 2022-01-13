using Microsoft.AspNetCore.Mvc;

namespace Post.Controllers;

public class PostController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}