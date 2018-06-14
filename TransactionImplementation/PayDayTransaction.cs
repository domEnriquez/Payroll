using PayollDomain;
using PayrollDatabase;
using System;
using System.Collections.Generic;
using TransactionApplication;

namespace TransactionImplementation
{
    public class PayDayTransaction : Transaction
    {
        private readonly DateTime payDate;
        private Dictionary<int,PayCheck> paychecks;

        public PayDayTransaction(DateTime payDate)
        {
            this.payDate = payDate;
            paychecks = new Dictionary<int, PayCheck>();

        }

        public void Execute()
        {
            List<int> empIds = PayrollDb.GetAllEmployeeIds();

            foreach (int empId in empIds)
            {
                Employee employee = PayrollDb.GetEmployee(empId);
                if (employee.IsPayDate(payDate))
                {
                    PayCheck pc = new PayCheck(payDate);
                    employee.Payday(pc);
                    paychecks[empId] = pc;
                }
            }
        }

        public PayCheck GetPaycheck(int empId)
        {
            if (paychecks.ContainsKey(empId))
                return paychecks[empId];
            else
                return null;
        }
    }
}
