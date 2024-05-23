using DependencyInjection.Domain;

namespace DependencyInjection.Repositories;

public interface ICountryRepository
{
    List<Country> GetAll();
}
