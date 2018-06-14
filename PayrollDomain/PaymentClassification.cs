using System;

namespace PayollDomain
{
    public abstract class PaymentClassification
    {
        public abstract double CalculatePay(PayCheck paycheck);
    }
}
