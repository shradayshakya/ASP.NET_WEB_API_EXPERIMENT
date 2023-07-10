using cs_webapi_experiment.Data;

namespace cs_webapi_experiment.Core.Contracts
{
    public interface IHotelsRepository : IGenericRepository<Hotel>
    {
        Task<Hotel> GetDetails(int id);
    }
}

