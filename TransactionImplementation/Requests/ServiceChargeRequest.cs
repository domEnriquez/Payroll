using System;
using TransactionApplication;

namespace TransactionImplementation
{
    public class ServiceChargeRequest : Request
    {
        public int MemberId { get; set; }
        public DateTime DateTime { get; set; }
        public double Charge { get; set; }

        public ServiceChargeRequest(int memeberId, DateTime dateTime, double charge)
        {
            MemberId = memeberId;
            DateTime = dateTime;
            Charge = charge;
        }
    }
}