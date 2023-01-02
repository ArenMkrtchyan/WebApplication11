namespace WebApplication11.Data.Entites
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public DateTime DOB { get; set; }
        public string ImageFileName { get; set; }
        public ICollection<MoovieActor> Moovies { get; set; }
    }
}
