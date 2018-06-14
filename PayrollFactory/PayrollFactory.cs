using PayollDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBoundary
{
    public abstract class PayrollFactory
    {
        public static PayrollFactory paymentFactory;
        public abstract PaymentClassification MakeCommissionedClassification(double hourlyRate, double salary);
        public abstract PaymentClassification MakeCommissionedClassification(PaymentClassification classification);
        public abstract PaymentClassification MakeHourlyClassification(double hourlyRate);
        public abstract PaymentClassification MakeHourlyClassification(PaymentClassification classification);
        public abstract PaymentClassification MakeSalariedClassification(double salary);
        public abstract PaymentSchedule MakeBiWeeklySchedule();
        public abstract PaymentSchedule MakeWeeklySchedule();
        public abstract PaymentSchedule MakeMonthlySchedule();
        public abstract PaymentMethod MakeDirectMethod(string bank, int account);
        public abstract PaymentMethod MakeHoldMethod();
        public abstract PaymentMethod HoldMethod();
        public abstract PaymentMethod MailMethod(string address);
        public abstract Affiliation MakeUnionAffiliation(int memberId, double dues);
        public abstract Affiliation MakeNoAffiliation();
        public abstract Affiliation MakeUnionAffiliation(Affiliation affiliation);
    }
}
