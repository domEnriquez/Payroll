using AbstractTransactions;
using PayollDomain;
using PayrollBoundary;


namespace TransactionImplementation
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private double hourlyRate;
        private double salary;

        public ChangeCommissionedTransaction(ChangeCommissionedRequest r) : base(r.EmpId)
        {
            hourlyRate = r.HourlyRate;
            salary = r.Salary;
        }

        public ChangeCommissionedTransaction(int id, double hourlyRate, double salary) : base(id)
        {
            this.hourlyRate = hourlyRate;
            this.salary = salary;
        }

        protected override PaymentClassification Classification
        {
            get { return PayrollFactory.paymentFactory.MakeCommissionedClassification(hourlyRate, salary); }
            //get { return new  CommissionedClassification(hourlyRate, salary); }
        }

        protected override PaymentSchedule Schedule
        {
            get { return PayrollFactory.paymentFactory.MakeBiWeeklySchedule(); }
            //get { return new BiWeeklySchedule(); }
        }
    }
}
