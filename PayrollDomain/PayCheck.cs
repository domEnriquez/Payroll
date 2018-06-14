using System;

namespace PayollDomain
{
    public class PayCheck
    {

        public PayCheck(DateTime payDate)
        {
            PayDate = payDate;
        }

        public double GrossPay { get; internal set; }
        public double Deductions { get; internal set; }
        public double NetPay { get; internal set; }
        public DateTime PayDate { get; set; }
    }
}
