using System;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new ApplicationDbContext())
        {
            context.Database.EnsureCreated();

            var taxService = new TaxService(context);

            Console.WriteLine("Enter municipality name:");
            string? municipalityName = Console.ReadLine();

            Console.WriteLine("Enter date (yyyy-mm-dd):");
            string? dateString = Console.ReadLine();

            if (municipalityName == null || dateString == null)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            if (!DateTime.TryParse(dateString, out DateTime date))
            {
                Console.WriteLine("Invalid date format.");
                return;
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
