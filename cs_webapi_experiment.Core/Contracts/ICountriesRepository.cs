using cs_webapi_experiment.Data;

namespace cs_webapi_experiment.Core.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {

        Task<Country> GetDetails(int id);

    }
}

