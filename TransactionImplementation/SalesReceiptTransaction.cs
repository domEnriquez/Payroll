using PayollDomain;
using PayrollBoundary;
using PayrollDatabase;
using System;
using TransactionApplication;

namespace TransactionImplementation
{
    public class SalesReceiptTransaction : Transaction
    {
        private DateTime dateTime;
        private int empId;
        private double amount;

        public SalesReceiptTransaction(SalesReceiptRequest req)
        {
            dateTime = req.Datetime;
            empId = req.EmpId;
            amount = req.Amount;
        }

        public SalesReceiptTransaction(DateTime dateTime, double amount, int empId)
        {
            this.dateTime = dateTime;
            this.amount = amount;
            this.empId = empId;
        }

        public void Execute()
        {
            Employee e = PayrollDb.GetEmployee(empId);

            if (e != null)
            {
                SalesReceiptHandler srh = e.Classification as SalesReceiptHandler;
                //CommissionedClassification cc = e.Classification as CommissionedClassification;
                if (srh != null)
                    srh.AddSalesReceipt(dateTime, amount);
                    //cc.AddSalesReceipt(new SalesReceipt(dateTime, amount));
                else
                    throw new InvalidOperationException("Tried to add sales receipt to non-commisioned employee");
            }
            else
                throw new InvalidOperationException("No such employee");
        }
    }
}
