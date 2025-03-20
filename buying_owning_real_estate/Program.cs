using System;

class Program
{
    static void Main(string[] args)
    {
        using var context = new ApplicationDbContext();
        context.Database.EnsureCreated();
        var taxService = new TaxService(context);

        // Check if the database is empty before importing data
        if (!context.Municipalities.Any())
        {
            taxService.ImportMunicipalitiesFromFile("municipalities.json");
        }

        while(true)
        {
            Console.WriteLine("Enter municipality name or type 'exit' to quit:");
            string? municipalityName = Console.ReadLine();

            if (municipalityName?.ToLower() == "exit") break;
            if (municipalityName == null || !context.Municipalities.Any(m => m.Name == municipalityName))
            {
                Console.WriteLine("Municipality not found.");
                continue;
            }

            Console.WriteLine("Enter date (yyyy-mm-dd) or type 'exit' to quit:");
            string? dateString = Console.ReadLine();
            if (dateString?.ToLower() == "exit") break;
            if (string.IsNullOrEmpty(dateString) || !DateTime.TryParse(dateString, out DateTime date))
            {
                Console.WriteLine("Invalid date input.");
                continue;
            }

            try
            {
                decimal taxRate = taxService.GetTaxRate(municipalityName, date);
                Console.WriteLine($"Tax rate for {municipalityName} on {date.ToString("yyyy-MM-dd")} is {taxRate}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}