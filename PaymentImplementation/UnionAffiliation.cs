using PayollDomain;
using PayrollBoundary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentImplementation
{
    public class UnionAffiliation : Affiliation, ServiceChargeHandler
    {
        public override int? MemberId { get; set; }

        public double Dues { get; set; }

        public List<ServiceCharge> ServiceCharges { get; set; }

        public UnionAffiliation(int memberId, double dues)
        {
            MemberId = memberId;
            Dues = dues;
            ServiceCharges = new List<ServiceCharge>();

        }

        public ServiceCharge GetServiceCharge(DateTime time)
        {
            return ServiceCharges.FirstOrDefault(s => s.Time.Equals(time));
        }

        public void AddServiceCharge(DateTime time, double charge)
        {
            ServiceCharge sc = new ServiceCharge(time, charge);
            ServiceCharges.Add(sc);
        }

        public override double CalculateDeductions(PayCheck paycheck)
        {
            double scAmount = 0;
            foreach (ServiceCharge sc in ServiceCharges)
                scAmount += sc.Amount;

            return Dues + scAmount;
        }


    }
}
