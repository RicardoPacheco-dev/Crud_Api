//Model For Medicaments on DB

using System.ComponentModel.DataAnnotations;

namespace CRUD_API.Models
{
    public class Medicament
    {
        [Key]
        public Guid Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string ActiveIngridient { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Batch { get; set; }
        public string Laboratory { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}