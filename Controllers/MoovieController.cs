using Microsoft.AspNetCore.Mvc;
using WebApplication11.ViewModels;
using WebApplication11.Services.Interfaces;
namespace WebApplication11.Controllers
{
    public class MoovieController : Controller
    {
        private readonly IMoovieService _moovieService;
        private readonly IMoovieInfoService _moovieInfoService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MoovieController(IMoovieService moovieService, IMoovieInfoService moovieInfoService, IWebHostEnvironment webHostEnvironment)
        {
            _moovieService = moovieService;
            _moovieInfoService = moovieInfoService;
            _webHostEnvironment = webHostEnvironment;
        }


        // moovies list 
        public IActionResult Index(MoovieSearchViewModel model, int pageSize = 3, int pageIndex=1)
        {
            
            ViewBag.Categories = _moovieInfoService.GetCategories();
            var data = _moovieService.GetMoovieList(model, pageSize, pageIndex);
            ViewBag.SearchInfo = model;
            ViewBag.PageCount = (int)Math.Ceiling((double)data.Item2 / pageSize);
            ViewBag.CurrentPage = pageIndex;
            return View(data.Item1);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Countries= _moovieInfoService.GetCountries();
            var categories = _moovieInfoService.GetCategories();
            ViewBag.Actors = _moovieInfoService.GetActors();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Add(MoovieAddEdit model, IFormFile PosterImage)
        {
            if(PosterImage !=null)
            {
                string fileName = Guid.NewGuid() + System.IO.Path.GetExtension(PosterImage.FileName);
                string path = $"{_webHostEnvironment.WebRootPath}/images/moovies/{fileName}";
                model.PosterImageFileName = fileName;
                using var fileStream = new FileStream(path, FileMode.Create);
                PosterImage.CopyTo(fileStream);
            }
            int moovieId = _moovieService.Add(model);
            return RedirectToAction("Index");
        }
    }
}
