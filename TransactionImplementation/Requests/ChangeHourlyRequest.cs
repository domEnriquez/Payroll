using TransactionApplication;

namespace TransactionImplementation
{
    public class ChangeHourlyRequest : Request
    {
        public int EmpId { get; set; }
        public double HourlyRate { get; set; }
    }
}
