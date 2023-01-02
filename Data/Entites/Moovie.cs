using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication11.Data.Entites
{
    public class Moovie
    {
        public int Id { get; set; }  
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string PosterImageFileName { get; set; }
        public ICollection<MoovieActor> Actors { get; set; }
        public ICollection<MoovieCategory> Categories { get; set; }
    }
}
