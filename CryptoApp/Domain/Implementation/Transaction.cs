namespace Domain
{
  using System;
  using System.ComponentModel.DataAnnotations;

  public class Transaction
  {
    [Key]
    public int Id { get; set; }

    public DateTime Date { get; set; }

    //public decimal Invested { get; set; }

    //public decimal Amount { get; set; }

    //public string CurrencyFrom { get; set; }

    //public string CurrencyTo { get; set; }

    public string Description { get; set; }
  }
}
