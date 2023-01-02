using WebApplication11.Services.Interfaces;
using WebApplication11.ViewModels;
using WebApplication11.Data;
using WebApplication11.Data.Entites;
namespace WebApplication11.Services
{
    public class ActorService : IActorService
    {
        private readonly MoovieDbContext _moovieDbContext;
        public ActorService(MoovieDbContext moovieDbContext)
        {
            _moovieDbContext = moovieDbContext;
        }

        public int Add(ActorAddEdit model)
        {
            var entity = new Actor
            {
                DOB = model.DOB,
                Biography =model.Biography,
                FirstName = model.FirstName,
                ImageFileName = model.ImageFileName,
                LastName = model.LastName,
               
            };
            _moovieDbContext.Actors.Add(entity);
            _moovieDbContext.SaveChanges();
            return entity.Id;
        }
    }
}
