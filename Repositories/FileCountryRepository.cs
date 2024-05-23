using DependencyInjection.Domain;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace DependencyInjection.Repositories;

public class FileCountryRepository : ICountryRepository
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileCountryRepository(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public List<Country> GetAll()
    {
        var basePath = _webHostEnvironment.ContentRootPath;

        var filePath = Path.Combine(basePath, "countries.json");

        var countriesAsString = System.IO.File.ReadAllText(filePath);

        var countries = JsonConvert.DeserializeObject<List<Country>>(countriesAsString);

        return countries;
    }
}
