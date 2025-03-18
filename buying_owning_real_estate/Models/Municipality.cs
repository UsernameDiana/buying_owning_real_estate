public class Municipality
{
    public int MunicipalityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Tax> Taxes { get; set; } = new List<Tax>();
}