namespace Domain
{
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;

  public class Client
  {
    [Key]
    public int? NumClient { get; set; }

    public string Dni { get; set; }

    public string Name { get; set; }

    public List<Transaction> Transactions { get; set; }

  }
}
