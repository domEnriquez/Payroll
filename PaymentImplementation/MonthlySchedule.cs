using PayollDomain;
using System;

namespace PaymentImplementation
{
    public class MonthlySchedule : PaymentSchedule
    {
        public override bool IsPayDate(DateTime payDate)
        {
            return isLastDayOfMonth(payDate);
        }

        private bool isLastDayOfMonth(DateTime date)
        {
            int m1 = date.Month;
            int m2 = date.AddDays(1).Month;

            return (m1 != m2);
        }
    }
}
