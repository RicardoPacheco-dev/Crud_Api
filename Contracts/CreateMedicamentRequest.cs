using System.ComponentModel.DataAnnotations;
public class CreateMedicamentRequest
{
    [Required]
    [StringLength(20)]
    public string Barcode { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string ActiveIngridient { get; set; }
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