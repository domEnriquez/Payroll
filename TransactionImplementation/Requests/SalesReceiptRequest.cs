using System;
using TransactionApplication;

namespace TransactionImplementation
{
    public class SalesReceiptRequest : Request
    {
        public SalesReceiptRequest(DateTime date, double amt, int empId)
        {
            Datetime = date;
            Amount = amt;
            EmpId = empId;
        }
        public DateTime Datetime { get; set; }
        public double Amount { get; set; }
        public int EmpId { get; set; }
    }
}