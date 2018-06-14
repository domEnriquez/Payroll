using AbstractTransactions;
using PayollDomain;
using PayrollBoundary;


namespace TransactionImplementation
{
    public class ChangeHoldMethodTransaction : ChangePaymentMethodTransaction
    {
        public ChangeHoldMethodTransaction(ChangeHoldMethodRequest r) : base(r.EmpId)
        {

        }

        public ChangeHoldMethodTransaction(int empId) : base(empId)
        {
        }

        protected override PaymentMethod Method
        {
            get { return PayrollFactory.paymentFactory.HoldMethod(); }
        }
    }
}
