using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        var municipality = _context.Municipalities
            .Include(m => m.Taxes)
            .FirstOrDefault(m => m.Name == municipalityName);

        if (municipality == null)
            throw new Exception("Municipality not found");

        var tax = municipality.Taxes
            .Where(t => t.StartDate <= date && t.EndDate >= date)
            .OrderBy(t => t.Type)
            .FirstOrDefault();

        return tax?.Rate ?? 0;
    }

    public void ImportMunicipalitiesFromFile(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);
        var municipalities = JsonConvert.DeserializeObject<List<Municipality>>(jsonData)
                             ?? new List<Municipality>();

        _context.Municipalities.AddRange(municipalities);
        _context.SaveChanges();
    }
}