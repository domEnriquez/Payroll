using AbstractTransactions;
using PayollDomain;
using PayrollBoundary;


namespace TransactionImplementation
{
    public class ChangeHourlyTransaction : ChangeClassificationTransaction
    {
        private readonly double hourlyRate;

        public ChangeHourlyTransaction(ChangeHourlyRequest r) : base(r.EmpId)
        {
            hourlyRate = r.HourlyRate;
        }

        public ChangeHourlyTransaction(int id, double hourlyRate) : base(id)
        {
            this.hourlyRate = hourlyRate;
        }
        protected override PaymentClassification Classification
        {
            get { return PayrollFactory.paymentFactory.MakeHourlyClassification(hourlyRate); }
        }
        protected override PaymentSchedule Schedule
        {
            get { return PayrollFactory.paymentFactory.MakeWeeklySchedule(); }
        }
    }
}
