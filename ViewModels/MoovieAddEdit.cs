namespace WebApplication11.ViewModels
{
    public class MoovieAddEdit
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        
        public int CountryId { get; set; }
        
        public string PosterImageFileName { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> ActorIds { get; set; }
    }
}
