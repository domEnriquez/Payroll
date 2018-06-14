using PayollDomain;

namespace PaymentImplementation
{
    public class NoAffiliation : Affiliation
    {
        public override int? MemberId {
            get
            {
                return null;
            }
            set
            {
                MemberId = null;
            }
        }

        public override double CalculateDeductions(PayCheck paycheck)
        {
            return 0;
        }
    }
}
