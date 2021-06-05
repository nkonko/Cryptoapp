namespace Domain_Model.Implementation
{
    using System.ComponentModel.DataAnnotations;

    public class Currency
    {
        [Key]
        public int Id { get; set; }

        public decimal Price { get; set; }

        public Type Type { get; set; }
    }

    public enum Type
    {
        BTC,
        USD,
        ARS
    }
}
