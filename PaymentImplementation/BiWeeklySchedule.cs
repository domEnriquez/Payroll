using PayollDomain;
using System;

namespace PaymentImplementation
{
    public class BiWeeklySchedule : PaymentSchedule
    {
        public override bool IsPayDate(DateTime payDate)
        {
            throw new NotImplementedException();
        }
    }
}
