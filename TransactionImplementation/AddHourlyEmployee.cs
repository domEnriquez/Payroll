using AbstractTransactions;
using PayollDomain;
using PayrollBoundary;

namespace TransactionImplementation
{
    public class AddHourlyEmployee : AddEmployeeTransaction
    {
        private readonly double hourlyRate;

        public AddHourlyEmployee(AddHourlyEmployeeRequest r) : base(r.EmpId, r.Name, r.Address)
        {
            hourlyRate = r.HourlyRate;
        }

        public AddHourlyEmployee(int empid, string name, string address, double hourlyRate) : base(empid, name, address)
        {
            this.hourlyRate = hourlyRate;
        }

        protected override PaymentClassification MakeClassification()
        {
            return PayrollFactory.paymentFactory.MakeHourlyClassification(hourlyRate);
            //return new HourlyClassification(hourlyRate);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return PayrollFactory.paymentFactory.MakeWeeklySchedule();
            //return new WeeklySchedule();
        }

        protected override Affiliation MakeAffiliation()
        {
            return PayrollFactory.paymentFactory.MakeNoAffiliation();
        }
        protected override PaymentMethod MakeMethod()
        {
            return PayrollFactory.paymentFactory.MakeHoldMethod();
        }
    }
}
