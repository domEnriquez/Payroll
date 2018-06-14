using AbstractTransactions;
using PayollDomain;
using PayrollBoundary;
using PayrollDatabase;

namespace TransactionImplementation
{
    public class ChangeUnaffiliatedTransaction : ChangeAffiliationTransaction
    {
        public ChangeUnaffiliatedTransaction(int empId): base(empId)
        { }

        protected override Affiliation Affiliation
        {
            get { return PayrollFactory.paymentFactory.MakeNoAffiliation(); }
        }

        protected override void RecordMembership(Employee e)
        {
            Affiliation affiliation = PayrollFactory.paymentFactory.MakeUnionAffiliation(e.Affiliation);
            if (affiliation != null && affiliation.MemberId != null)
            {
                int memberId = affiliation.MemberId.Value;
                PayrollDb.RemoveUnionMember(memberId);
            }
        }
    }
}
