using AbstractTransactions;
using PayollDomain;
using PayrollBoundary;


namespace TransactionImplementation
{
    public class ChangeDirectMethodTransaction : ChangePaymentMethodTransaction
    {
        private string bank;
        private int account;

        public ChangeDirectMethodTransaction(ChangeDirectMethodRequest r) : base(r.EmpId)
        {
            bank = r.Bank;
            account = r.Account;
        }

        public ChangeDirectMethodTransaction(int empId, string bank, int account) : base(empId)
        {
            this.bank = bank;
            this.account = account;
        }

        protected override PaymentMethod Method
        {
            get { return PayrollFactory.paymentFactory.MakeDirectMethod(bank, account); }
            //get { return new DirectMethod(bank, account); }
        }
    }
}
