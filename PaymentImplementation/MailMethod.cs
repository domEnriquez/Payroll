using PayollDomain;
using System;

namespace PaymentImplementation
{
    public class MailMethod : PaymentMethod
    {
        public string Address { get; set; }

        public MailMethod(string address)
        {
            Address = address;
        }

        public override void Pay(PayCheck paycheck)
        {
            throw new NotImplementedException();
        }
    }
}
