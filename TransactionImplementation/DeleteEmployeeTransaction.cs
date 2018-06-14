using PayrollDatabase;
using TransactionApplication;

namespace TransactionImplementation
{
    public class DeleteEmployeeTransaction : Transaction
    {

        private readonly int id;

        public DeleteEmployeeTransaction(int id)
        {
            this.id = id;
        }

        public DeleteEmployeeTransaction(DeleteEmployeeRequest req)
        {
            id = req.EmpId;
        }

        public void Execute()
        {
            PayrollDb.DeleteEmployee(id);
        }
    }
}
