using WebApplication11.ViewModels;
namespace WebApplication11.Services.Interfaces
{
    public interface IMoovieService
    {
        public int Add(MoovieAddEdit model);
        public Tuple<List<MoovieListView>, int> GetMoovieList(MoovieSearchViewModel model, int pageSize, int pageIndex);
    }
}
