using PayollDomain;
using PayrollBoundary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentImplementation
{
    public class CommissionedClassification : PaymentClassification, SalesReceiptHandler
    {
        private double hourlyRate;
        private double salary;
        private List<SalesReceipt> receipts;

        public CommissionedClassification(double hourlyRate, double salary)
        {
            this.hourlyRate = hourlyRate;
            this.salary = salary;
            receipts = new List<SalesReceipt>();
        }

        public double Salary
        {
            get
            {
                return salary;
            }
        }

        public double HourlyRate {
            get
            {
                return hourlyRate;
            }
        }

        public SalesReceipt GetSalesReceipt(DateTime dateTime)
        {
            return receipts.FirstOrDefault(r => r.Date.Equals(dateTime));
        }

        public void AddSalesReceipt(DateTime dateTime, double amount)
        {
            SalesReceipt sr = new SalesReceipt(dateTime, amount);
            receipts.Add(sr);
        }

        public override double CalculatePay(PayCheck paycheck)
        {
            throw new NotImplementedException();
        }


    }
}
