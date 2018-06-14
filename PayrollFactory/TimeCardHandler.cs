using System;

namespace PayrollBoundary
{
    public interface TimeCardHandler
    {
        void AddTimeCard(DateTime date, double hours);
    }
}
