using AbstractTransactions;
using PayollDomain;
using PayrollBoundary;

namespace TransactionImplementation
{
    public class ChangeMailMethodTransaction : ChangePaymentMethodTransaction
    {
        private string address;

        public ChangeMailMethodTransaction(int empId, string address) : base(empId)
        {
            this.address = address;
        }

        protected override PaymentMethod Method
        {
            get { return PayrollFactory.paymentFactory.MailMethod(address); }
        }

    }
}
