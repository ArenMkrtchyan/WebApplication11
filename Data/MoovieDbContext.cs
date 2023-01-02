using Microsoft.EntityFrameworkCore;
using WebApplication11.Data.Entites;
namespace WebApplication11.Data
{
    public class MoovieDbContext:DbContext
    {
        public MoovieDbContext(DbContextOptions<MoovieDbContext> opt):base(opt)
        {

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Moovie> Moovies { get; set; }
        public DbSet<MoovieActor> MoovieActors { get; set; }
        public DbSet<MoovieCategory> MoovieCategories { get; set; }
    }
}
