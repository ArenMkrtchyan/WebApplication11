using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication11.Data.Entites
{
    public class MoovieCategory
    {
        public int Id { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Moovie")]
        public int MoovieId { get; set; }
        public Moovie Moovie { get; set; }
        public Category Category { get; set; }
    }
}
