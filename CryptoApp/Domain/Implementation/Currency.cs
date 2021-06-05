namespace Domain_Model.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Currency
    {
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
