using System.ComponentModel.DataAnnotations;
namespace WebApplication11.ViewModels
{
    public class ActorAddEdit
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Biography { get; set; }
        public DateTime DOB { get; set; }
        public string? ImageFileName { get; set; }
    }
}
