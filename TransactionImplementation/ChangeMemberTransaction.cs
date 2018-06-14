using AbstractTransactions;
using PayollDomain;
using PayrollBoundary;
using PayrollDatabase;

namespace TransactionImplementation
{
    public class ChangeMemberTransaction : ChangeAffiliationTransaction
    {
        private readonly int memberId;
        private readonly double dues;

        public ChangeMemberTransaction(int empId, int memberId, double dues) : base(empId)
        {
            this.memberId = memberId;
            this.dues = dues;
        }

        protected override Affiliation Affiliation
        {
            get { return PayrollFactory.paymentFactory.MakeUnionAffiliation(memberId, dues); }
        }
        protected override void RecordMembership(Employee e)
        {
            PayrollDb.AddUnionMember(memberId, e);
        }
    }
}
