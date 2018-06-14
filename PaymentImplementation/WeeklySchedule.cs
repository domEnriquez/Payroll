using PayollDomain;
using System;

namespace PaymentImplementation
{
    public class WeeklySchedule : PaymentSchedule
    {
        public override bool IsPayDate(DateTime payDate)
        {
            return payDate.DayOfWeek == DayOfWeek.Friday;
        }
    }
}
