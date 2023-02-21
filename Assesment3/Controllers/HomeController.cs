using Assesment3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Assesment3.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assesment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger,
            ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Library()
        {
            var cats = await _categoryService.GetCategoriesByParentCategoryId(0);
            var items = cats.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            items.Insert(0, new SelectListItem("Select books category", "0"));
            return View(items);
        }

        [HttpGet]
        public async Task<JsonResult> CategoriesByParentId(int id)
        {
            if (id < 1)
            {
                return Json(new List<SelectListItem>());
            }
            var cats = await _categoryService.GetCategoriesByParentCategoryId(id);
            var items = cats.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return Json(items);
        }
        public IActionResult Index()
        {
            return View();
        }

     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}