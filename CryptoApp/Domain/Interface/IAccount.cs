namespace Domain
{
  public interface IAccount
  {
    decimal Balance { get; set; }

    public Enum.Type Type { get; set; }
  }
}
