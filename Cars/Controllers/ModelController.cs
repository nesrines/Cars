using Microsoft.AspNetCore.Mvc;
using Cars.Models;
namespace Cars.Controllers;
public class ModelController : Controller
{
    private readonly List<Model>? _models;
    public ModelController()
    {
        _models = new List<Model>()
        {
            new Model {Id = 1, BrandId = 1, Name = "F40", Price = 1_500_000},
            new Model {Id = 2, BrandId = 1, Name = "F50", Price = 4_000_000},
            new Model {Id = 3, BrandId = 1, Name = "Enzo", Price = 3_200_000},
            new Model {Id = 4, BrandId = 1, Name = "LaFerrari", Price = 3_100_000},
            new Model {Id = 5, BrandId = 1, Name = "Roma SA", Price = 200_000},
            new Model {Id = 6, BrandId = 1, Name = "488", Price = 283_000},
            new Model {Id = 7, BrandId = 2, Name = "GT-R", Price = 121_000},
            new Model {Id = 8, BrandId = 2, Name = "R32", Price = 20_000},
            new Model {Id = 9, BrandId = 2, Name = "S13", Price = 20_000},
            new Model {Id = 10, BrandId = 2, Name = "Skyline 25GT", Price = 37_000},
            new Model {Id = 11, BrandId = 2, Name = "180SX", Price = 26_000},
            new Model {Id = 12, BrandId = 3, Name = "Supra MK4", Price = 100_000},
            new Model {Id = 13, BrandId = 3, Name = "Supra RZ", Price = 57_000},
            new Model {Id = 14, BrandId = 3, Name = "Sprinter Trueno 1988", Price = 11_000}
        };
    }
    public IActionResult Index(int? id)
    {
        if (id == null) return View(_models);
        else
        {
            List<Model>? BrandModels = _models.FindAll(m => m.BrandId == id);
            if (BrandModels == null) return NotFound();
            else return View(BrandModels);
        }
    }
    public IActionResult Details(int? id)
    {
        if (id == null) return BadRequest();
        else
        {
            Model model = _models.Find(m => m.Id == id);
            if (model == null) return NotFound();
            else return View(model);
        }
    }
}