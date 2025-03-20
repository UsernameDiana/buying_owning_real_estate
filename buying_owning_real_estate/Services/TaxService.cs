using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

public class TaxService
{
    private readonly ApplicationDbContext _context;

    public TaxService(ApplicationDbContext context)
    {
        _context = context;
    }

    public decimal GetTaxRate(string municipalityName, DateTime date)
    {
        var tax = _context.Municipalities
            .Where(m => m.Name == municipalityName)
            .SelectMany(m => m.Taxes)
            .Where(t => t.StartDate <= date && t.EndDate >= date)
            .OrderBy(t => t.Type)
            .FirstOrDefault();

        // TODO: Handle 0 tax rate return "Not Found" exception
        return tax?.Rate ?? 0;
    }

    public void ImportMunicipalitiesFromFile(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);
        var municipalities = JsonSerializer.Deserialize<List<Municipality>>(jsonData, new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        }) ?? new List<Municipality>();

        _context.Municipalities.AddRange(municipalities);
        _context.SaveChanges();
    }
}