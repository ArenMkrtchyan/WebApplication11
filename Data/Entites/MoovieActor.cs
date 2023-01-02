using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication11.Data.Entites
{
    public class MoovieActor
    {
        public int Id { get; set; }
        [ForeignKey("Moovie")]
        public int MoovieId { get; set; }
        [ForeignKey("Actor")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        public Moovie Moovie { get; set; }
    }
}
