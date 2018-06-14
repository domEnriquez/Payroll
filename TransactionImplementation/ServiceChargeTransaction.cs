using PayollDomain;
using PayrollBoundary;
using PayrollDatabase;
using System;
using TransactionApplication;

namespace TransactionImplementation
{
    public class ServiceChargeTransaction : Transaction
    {
        private readonly int memberId;
        private DateTime time;
        private double charge;

        public ServiceChargeTransaction(ServiceChargeRequest req)
        {
            memberId = req.MemberId;
            charge = req.Charge;
            time = req.DateTime;
        }

        public ServiceChargeTransaction(int memberId, DateTime time, double charge, ServiceChargeHandler sch)
        {
            this.memberId = memberId;
            this.time = time;
            this.charge = charge;
        }

        public void Execute()
        {
            Employee e = PayrollDb.GetUnionMember(memberId);

            if (e != null)
            {
                ServiceChargeHandler sch = e.Affiliation as ServiceChargeHandler;
                if (sch != null)
                    sch.AddServiceCharge(time, charge);
                    //ua.AddServiceCharge(new ServiceCharge(time, charge));
                else
                    throw new InvalidOperationException("Tries to add service charge to union"
                                                        + "member without a union affiliation");
            }
            else
                throw new InvalidOperationException(
                "No such union member.");
        }
    }
}
