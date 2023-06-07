using Data.Models;

namespace Data.Services
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        private readonly SchoolDbContext ctx;
        public DataAccessLayerService(SchoolDbContext ctx)
        {
            this.ctx = ctx;
        }
    }
}
