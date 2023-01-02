namespace WebApplication11.ViewModels
{
    public class MoovieListView
    {
        public int  Id { get; set; }
        public  string Name { get; set; }
        public DateTime Date { get; set; }
        public string Categories { get; set; }
        public int ActorCount { get; set; }
        public string ImageFile { get; set; }
        public bool IsCommingSoon
        {
            get
            {
                return Date > DateTime.Now;
            }
        }
    }
}
