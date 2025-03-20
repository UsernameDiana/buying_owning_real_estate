public class Tax
{
    public int TaxId { get; set; }
    public TaxType Type { get; set; }
    public decimal Rate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MunicipalityId { get; set; }
    public Municipality Municipality { get; set; } = null!;
}