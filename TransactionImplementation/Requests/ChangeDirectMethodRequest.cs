using TransactionApplication;

namespace TransactionImplementation
{
    public class ChangeDirectMethodRequest : Request
    {
        public int EmpId { get; set; }
        public string Bank { get; set; }
        public int Account { get; set; }
    }
}
