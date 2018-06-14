using System;

namespace PayollDomain
{
    public abstract class PaymentSchedule
    {
        public abstract bool IsPayDate(DateTime payDate);
    }
}
