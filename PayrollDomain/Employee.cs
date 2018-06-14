using System;

namespace PayollDomain
{
    public class Employee
    {
        private string address;
        private int empid;
        public string Name { get; set; }

        public Employee(int empid, string name, string address)
        {
            this.empid = empid;
            Name = name;
            this.address = address;
        }

        public PaymentClassification Classification { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public Affiliation Affiliation { get; set; }
        public bool IsPayDate(DateTime payDate)
        {
            return Schedule.IsPayDate(payDate);
        }

        public void Payday(PayCheck paycheck)
        {
            double grossPay = Classification.CalculatePay(paycheck);
            double deductions = Affiliation.CalculateDeductions(paycheck);
            double netPay = grossPay - deductions;

            paycheck.GrossPay = grossPay;
            paycheck.Deductions = deductions;
            paycheck.NetPay = netPay;

            Method.Pay(paycheck);
        }
    }
}
