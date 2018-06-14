using PayollDomain;
using PayrollDatabase;
using System;
using TransactionApplication;

namespace AbstractTransactions
{
    public abstract class ChangeEmployeeTransaction : Transaction
    {
        private readonly int empId;
        public ChangeEmployeeTransaction(int empId)
        {
            this.empId = empId;
        }

        public void Execute()
        {
            Employee e = PayrollDb.GetEmployee(empId);

            if (e != null)
                Change(e);
            else
                throw new InvalidOperationException("No such employee.");
        }

        protected abstract void Change(Employee e);
    }
}
