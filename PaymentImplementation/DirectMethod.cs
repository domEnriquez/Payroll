using PayollDomain;
using System;

namespace PaymentImplementation
{
    public class DirectMethod : PaymentMethod
    {
        public string Bank { get; set; }
        public int Account { get; set; }

        public DirectMethod(string bank, int account)
        {
            Bank = bank;
            Account = account;
        }

        public override void Pay(PayCheck paycheck)
        {
            throw new NotImplementedException();
        }
    }
}
