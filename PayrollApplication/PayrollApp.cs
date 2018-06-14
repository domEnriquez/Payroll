using PaymentImplementation;
using PayrollBoundary;
using RequestsFactory;
using TransactionApplication;
using TransactionImplementation;

namespace PayrollApplication
{
    public class PayrollApp : TransactionApp
    {
        public PayrollApp(TransactionSource ts) : base(ts)
        {
            PayrollFactory.paymentFactory = new PaymentFactoryImplementation();
            RequestFactory.rf = new RequestFactoryImplementation();
        }
    }
}
