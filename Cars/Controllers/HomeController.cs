using Microsoft.AspNetCore.Mvc;
using Cars.Models;
namespace Cars.Controllers;
public class HomeController : Controller
{
    private readonly List<Brand>? _brands;
    public HomeController()
    {
        _brands = new List<Brand>()
        {
            new Brand{Id = 1, Name = "Ferrari", Place="Maranello, Italy", CreationYear = 1939},
            new Brand{Id = 2, Name = "Nissan", Place = "Japan", CreationYear = 1933},
            new Brand{Id = 3, Name = "Toyota", Place = "Japan", CreationYear = 1937}
        };
    }
    public IActionResult Index()
    {
        return View(_brands);
    }
    public IActionResult Details(int? id)
    {
        if (id == null) return BadRequest();
        else
        {
            Brand? brand = _brands.Find(b => b.Id == id);
            if (brand == null) return NotFound();
            else return View(brand);
        }
    }
}