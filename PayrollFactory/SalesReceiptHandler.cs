using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBoundary
{
    public interface SalesReceiptHandler
    {
        void AddSalesReceipt(DateTime dateTime, double amount);

    }
}
