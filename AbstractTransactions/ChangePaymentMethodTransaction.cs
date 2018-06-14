using PayollDomain;

namespace AbstractTransactions
{
    public abstract class ChangePaymentMethodTransaction : ChangeEmployeeTransaction
    {
        public ChangePaymentMethodTransaction(int empId) : base(empId)
        {
        }

        protected override void Change(Employee e)
        {
            e.Method = Method;
        }

        protected abstract PaymentMethod Method { get; }
    }
}
