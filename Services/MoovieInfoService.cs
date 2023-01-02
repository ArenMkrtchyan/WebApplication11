using WebApplication11.Services.Interfaces;
using WebApplication11.ViewModels;
using WebApplication11.Data;
namespace WebApplication11.Services
{
    public class MoovieInfoService : IMoovieInfoService
    {
        private readonly MoovieDbContext _moovieDbContext;
        public MoovieInfoService(MoovieDbContext moovieDbContext)
        {
            _moovieDbContext = moovieDbContext;
        }

        public List<DropDownModel> GetActors()
        {
            var actors = _moovieDbContext.Actors.OrderBy(a=>a.LastName)
                .Select(a => new DropDownModel
                {
                    Value = a.Id,
                    Text = a.FirstName + " " + a.LastName
                }).ToList();
            return actors;
        }

        public List<DropDownModel> GetCategories()
        {
            var list = _moovieDbContext.Categories
                .Select(c => new DropDownModel
                {
                    Value = c.Id,
                    Text = c.Name
                }).ToList();

            return list;
        }

        public List<DropDownModel> GetCountries()
        {
            var list = _moovieDbContext.Countries
                .Select(c => new DropDownModel
                {
                    Text =c.Name,
                    Value = c.Id
                }).ToList();

            return list;
        }
    }
}
