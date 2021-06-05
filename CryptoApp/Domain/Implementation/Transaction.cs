namespace Domain
{
    using System;
    using Domain_Model.Implementation;

    public class Transaction
    {
        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public Currency CurrencyFrom { get; set; }

        public Currency CurrencyTo { get; set; }

        public string Description { get; set; }
    }
}
