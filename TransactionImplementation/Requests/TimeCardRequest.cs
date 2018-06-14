using System;
using TransactionApplication;

namespace TransactionImplementation
{
    public class TimeCardRequest : Request
    {
        public DateTime DateTime { get; set; }
        public double Hours { get; set; }
        public int EmpId { get; set; }

        public TimeCardRequest(DateTime dateTime, double hours, int empId)
        {
            DateTime = dateTime;
            Hours = hours;
            EmpId = empId;
        }
    }
}