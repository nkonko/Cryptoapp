namespace Domain_Model.Implementation
{
    using System.ComponentModel.DataAnnotations;
    using Domain.Enum;

    public class Currency
    {
        [Key]
        public int Id { get; set; }

        public decimal Price { get; set; }

        public Type Type { get; set; }
    }
}
