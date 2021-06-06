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

        public decimal Invested { get; set; }

        public decimal Amount { get; set; }

        public Currency Currency { get; set; }

        public string Description { get; set; }
    }
}
