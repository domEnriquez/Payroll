using AbstractTransactions;
using PayollDomain;
using PayrollBoundary;


namespace TransactionImplementation
{
    public class AddSalariedEmployee : AddEmployeeTransaction
    {
        private readonly double salary;

        public AddSalariedEmployee(AddSalariedEmployeeRequest r) : base(r.EmpId, r.Name, r.Address)
        {
            salary = r.Salary;
        }

        public AddSalariedEmployee(int id, string name, string address, double salary) : base(id, name, address)
        {
            this.salary = salary;
        }

        protected override PaymentClassification MakeClassification()
        {
            return PayrollFactory.paymentFactory.MakeSalariedClassification(salary);
            //return new SalariedClassification(salary);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return PayrollFactory.paymentFactory.MakeMonthlySchedule();
            //return new MonthlySchedule();
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
