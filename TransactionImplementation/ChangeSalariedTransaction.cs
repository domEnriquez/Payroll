using AbstractTransactions;
using PayollDomain;
using PayrollBoundary;

namespace TransactionImplementation
{
    public class ChangeSalariedTransaction : ChangeClassificationTransaction
    {
        private readonly double salary;

        public ChangeSalariedTransaction(int id, double salary) : base(id)
        {
            this.salary = salary;
        }
        protected override PaymentClassification Classification
        {
            get { return PayrollFactory.paymentFactory.MakeSalariedClassification(salary); }
        }
        protected override PaymentSchedule Schedule
        {
            get { return PayrollFactory.paymentFactory.MakeMonthlySchedule(); }
        }
    }
}
