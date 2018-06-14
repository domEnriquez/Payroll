

using PayollDomain;
using PayrollDatabase;
using TransactionApplication;

namespace AbstractTransactions
{
    public abstract class AddEmployeeTransaction : Transaction
    {
        private readonly int empid;
        private readonly string name;
        private readonly string address;

        public AddEmployeeTransaction(int empid, string name, string address)
        {
            this.empid = empid;
            this.name = name;
            this.address = address;
        }

        protected abstract PaymentClassification MakeClassification();
        protected abstract PaymentSchedule MakeSchedule();
        protected abstract PaymentMethod MakeMethod();
        protected abstract Affiliation MakeAffiliation();

        public void Execute()
        {
            PaymentClassification pc = MakeClassification();
            PaymentSchedule ps = MakeSchedule();
            PaymentMethod pm = MakeMethod();

            Employee e = new Employee(empid, name, address);
            e.Classification = pc;
            e.Schedule = ps;
            e.Method = pm;
            e.Affiliation = MakeAffiliation();

            PayrollDb.AddEmployee(empid, e);
        }
    }
}
