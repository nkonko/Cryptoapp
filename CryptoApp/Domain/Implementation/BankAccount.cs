namespace Domain
{
    using System.Collections.Generic;
    using System.Text;
    public class BankAccount : IAccount
    {
        public int AccountNumb { get; set; }

        public int CBU { get; set; }

        public string Alias { get; set; }

        public decimal Balance { get; set; }

        public Client Client { get; set; }

        public List<Transaction> Transaction { get; set; }

        public void Deposit()
        {
            throw new System.NotImplementedException();
        }

        public void Transfer()
        {
            throw new System.NotImplementedException();
        }
    }
}
