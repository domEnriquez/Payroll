
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionApplication;

namespace TransactionImplementation
{
    public class ChangeHoldMethodRequest : Request
    {
        public int EmpId { get; set; }
    }
}
