using AbstractTransactions;
using PayrollBoundary;
using PayollDomain;

namespace TransactionImplementation
{
    public class AddCommissionedEmployee : AddEmployeeTransaction
    {
        private double hourlyRate;
        private double salary;

        public AddCommissionedEmployee(AddCommissionedEmployeeRequest r) : base(r.EmpId, r.Name, r.Address)
        {
            hourlyRate = r.HourlyRate;
            salary = r.Salary;
        }

        public AddCommissionedEmployee(int empid, string name, string address, double hourlyRate, double salary) : base(empid, name, address)
        {
            this.hourlyRate = hourlyRate;
            this.salary = salary;
        }

        protected override Affiliation MakeAffiliation()
        {
            return PayrollFactory.paymentFactory.MakeNoAffiliation();
        }
        protected override PaymentMethod MakeMethod()
        {
            return PayrollFactory.paymentFactory.MakeHoldMethod();
        }

        protected override PaymentClassification MakeClassification()
        {
            return PayrollFactory.paymentFactory.MakeCommissionedClassification(hourlyRate, salary);
            //return new CommissionedClassification(hourlyRate, salary);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return PayrollFactory.paymentFactory.MakeBiWeeklySchedule();
            //return new BiWeeklySchedule();
        }
    }
}
