using TransactionApplication;

namespace TransactionImplementation
{
    public class DeleteEmployeeRequest : Request
    {
        public int EmpId { get; set; }

        public DeleteEmployeeRequest(int empId)
        {
            EmpId = empId;
        }
    }
}