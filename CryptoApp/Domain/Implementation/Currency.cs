namespace Domain_Model.Implementation
{
    using System.ComponentModel.DataAnnotations;
    using Domain.Enum;

    public class Currency
    {
        [Key]
        public int Id { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal SalePrice { get; set; }

        public Type Type { get; set; }
    }
}
