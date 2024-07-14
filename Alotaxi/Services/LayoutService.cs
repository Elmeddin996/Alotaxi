using Alotaxi.DAL;
using Alotaxi.Models;

namespace Alotaxi.Services
{
    public class LayoutService
    {
        private readonly AlotaxiDbContext _contex;

        public LayoutService(AlotaxiDbContext contex)
        {
            _contex = contex;
        }

        public List<Settings> GetSettings()
        {
            return _contex.Settings.ToList();
        }
    }
}
