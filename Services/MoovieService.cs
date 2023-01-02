using WebApplication11.Services.Interfaces;
using WebApplication11.ViewModels;
using WebApplication11.Data;
using WebApplication11.Data.Entites;
using System.Linq;

namespace WebApplication11.Services
{
    public class MoovieService:IMoovieService
    {
        private readonly MoovieDbContext _moovieDbContext;
        public MoovieService(MoovieDbContext moovieDbContext)
        {
            _moovieDbContext = moovieDbContext;
        }
        public int Add (MoovieAddEdit model)
        {
            //var mooviecategories = model.CategoryIds.Select(c => new MoovieCategory
            //{
            //    CategoryId = c,
               
            //}).ToList();
            Moovie moovie = new Moovie()
            {
                Date =model.Date,
                Description= model.Description,
                CountryId = model.CountryId,
                Name=model.Name,
                PosterImageFileName= model.PosterImageFileName
            };

            _moovieDbContext.Moovies.Add(moovie);
            //moovie.Categories = new List<MoovieCategory>();
            //mooviecategories.ForEach(mc => moovie.Categories.Add(mc));
            _moovieDbContext.SaveChanges();

            var mooviecategories = model.CategoryIds.Select(c => new MoovieCategory
            {
                CategoryId = c,
                MoovieId = moovie.Id
            });
            _moovieDbContext.MoovieCategories.AddRange(mooviecategories);
            var moovieactors = model.ActorIds.Select(a => new MoovieActor
            {
                ActorId = a,
                MoovieId = moovie.Id
            });
            _moovieDbContext.MoovieActors.AddRange(moovieactors);

            //foreach(var item in model.CategoryIds)
            //{

            //    var mooviecategory = new MoovieCategory
            //    {
            //        CategoryId= item,
            //        MoovieId= moovie.Id
            //    };
            //    _moovieDbContext.MoovieCategories.Add(mooviecategory);
            //}
            _moovieDbContext.SaveChanges();
            return moovie.Id;

        }

        public Tuple<List<MoovieListView> ,int> GetMoovieList(MoovieSearchViewModel model, int pageSize, int pageIndex)
        {
            
            var checkDate = DateTime.Now;

            var query = _moovieDbContext.Moovies
                .Where(m => (model.MoovieName == null || m.Name.ToLower().Contains(model.MoovieName.ToLower()))
                && (model.CategoryIds == null || !model.CategoryIds.Any()
                || m.Categories.Any(mc => model.CategoryIds.Contains(mc.CategoryId)))
                && (!model.OnlyUpcomming || m.Date > checkDate)
                );

            var list = query
                .Select(m => new MoovieListView
                {
                    Id = m.Id,
                    Date = m.Date,
                    ImageFile = m.PosterImageFileName,
                    Name = m.Name,
                    ActorCount = m.Actors.Count(),
                    Categories = String.Join(",", m.Categories.Select(c => c.Category.Name))
                })
                .OrderByDescending(p => p.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var count = query.Count();
            return Tuple.Create(list,count);
        }
    }
}
