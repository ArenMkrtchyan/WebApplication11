using Microsoft.AspNetCore.Mvc;
using WebApplication11.ViewModels;
using WebApplication11.Services.Interfaces;
namespace WebApplication11.Controllers
{
    public class ActorController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment; // file system access
        private readonly IActorService _actorService;

        public ActorController(IWebHostEnvironment webHostEnvironment, IActorService actorService)
        {
            _webHostEnvironment = webHostEnvironment;
            _actorService = actorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Add(ActorAddEdit model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string fileName = Guid.NewGuid() + System.IO.Path.GetExtension(ImageFile.FileName);
                    string path = $"{_webHostEnvironment.WebRootPath}/images/actors/{fileName}";
                    model.ImageFileName = fileName;
                    using var fileStream = new FileStream(path, FileMode.Create);
                    ImageFile.CopyTo(fileStream);


                }
                var actorId = _actorService.Add(model);
                return RedirectToAction("Detail", new { id = actorId });
            }
            return View(model);

        }

        public IActionResult Detail(int id)
        {
            // logic
            return View();
        }


    }
}
