namespace Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Domain_Model.Implementation;

    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal AmountToSend { get; set; }

        public decimal AmountToRetrive { get; set; }

        public Enum.Type CurrencyType { get; set; }

        public Currency CurrencyTo { get; set; }

        public string Description { get; set; }
    }
}
