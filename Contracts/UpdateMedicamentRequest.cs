using System.ComponentModel.DataAnnotations;
public class UpdateMedicamentRequest
{
    [Required]
    public string Name { get; set; }
    public string? ActiveIngridient { get; set; }
    [Required]
    public DateTime ExpirationDate { get; set; }
    [Required]
    public string Batch { get; set; }
    [Required]
    public string Laboratory { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public int Quantity { get; set; }
}