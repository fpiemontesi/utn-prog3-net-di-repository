using DependencyInjection.Context;
using DependencyInjection.Domain;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.Repositories;

public class DbCountryRepository : ICountryRepository
{
    private readonly CountryDbContext _context;

    public DbCountryRepository(CountryDbContext context)
    {
        _context = context;
    }

    public List<Country> GetAll()
    {
        return _context.Countries.ToList();
    }
}
