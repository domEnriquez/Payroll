using System;

namespace PayrollBoundary
{
    public interface ServiceChargeHandler
    {
        void AddServiceCharge(DateTime time, double charge);
    }
}
