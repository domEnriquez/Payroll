using System;
using PayollDomain;
using PayrollBoundary;

namespace PaymentImplementation
{
    public class PaymentFactoryImplementation : PayrollFactory
    {
        public override PaymentMethod HoldMethod()
        {
            return new HoldMethod();
        }

        public override PaymentMethod MailMethod(string address)
        {
            return new MailMethod(address);
        }

        public override PaymentSchedule MakeBiWeeklySchedule()
        {
            return new BiWeeklySchedule();
        }

        public override PaymentClassification MakeCommissionedClassification(double hourlyRate, double salary)
        {
            return new CommissionedClassification(hourlyRate, salary);
        }

        public override PaymentClassification MakeCommissionedClassification(PaymentClassification classification)
        {
            CommissionedClassification cc = classification as CommissionedClassification;
            return cc;
        }

        public override PaymentMethod MakeDirectMethod(string bank, int account)
        {
            return new DirectMethod(bank, account);
        }

        public override PaymentMethod MakeHoldMethod()
        {
            return new HoldMethod();
        }

        public override PaymentClassification MakeHourlyClassification(double hourlyRate)
        {
            return new HourlyClassification(hourlyRate);
        }

        public override PaymentClassification MakeHourlyClassification(PaymentClassification classification)
        {
            HourlyClassification hc = classification as HourlyClassification;
            return hc;
        }
        public override PaymentClassification MakeSalariedClassification(double salary)
        {
            return new SalariedClassification(salary);
        }

        public override PaymentSchedule MakeMonthlySchedule()
        {
            return new MonthlySchedule();
        }

        public override Affiliation MakeNoAffiliation()
        {
            return new NoAffiliation();
        }

        public override Affiliation MakeUnionAffiliation(int memberId, double dues)
        {
            return new UnionAffiliation(memberId, dues);
        }

        public override Affiliation MakeUnionAffiliation(Affiliation affiliation)
        {
            UnionAffiliation ua = affiliation as UnionAffiliation;
            return ua;
        }

        public override PaymentSchedule MakeWeeklySchedule()
        {
            return new WeeklySchedule();
        }
    }
}
