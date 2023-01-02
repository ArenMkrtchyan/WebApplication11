using WebApplication11.ViewModels;
namespace WebApplication11.Services.Interfaces
{
    public interface IMoovieInfoService
    {
        public List<DropDownModel> GetCountries();
        public List<DropDownModel> GetCategories();
        public List<DropDownModel> GetActors();
    }
}
