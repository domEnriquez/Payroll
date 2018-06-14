

using TransactionApplication;

namespace TransactionImplementation
{
    public class ChangeCommissionedRequest : Request
    {
        public int EmpId { get; set; }
        public double HourlyRate { get; set; }
        public double Salary { get; set; }
    }
}
