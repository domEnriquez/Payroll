using PayollDomain;

namespace PaymentImplementation
{
    public class SalariedClassification : PaymentClassification
    {
        public double Salary { get; set; }

        public SalariedClassification(double salary)
        {
            Salary = salary;
        }

        public override double CalculatePay(PayCheck paycheck)
        {
            return Salary;
        }
    }
}
